using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FalloutShelterEditor
{
    public partial class MainForm : Form
    {
        private string path; // Path to the Fallout Shelter save file
        private readonly Vault vault; // Instance of the Vault class responsible for managing game data
        private Dictionary<string, object> modifiedDwellerData;

        public MainForm()
        {
            vault = new Vault(); // Initialize Vault instance
            path = null; // Initialize the path variable to null
            InitializeComponent(); // Initialize the form components
        }

        private void UpdateUIWithVaultData()
        {
            // Update UI with Vault data
            this.Text = "Fallout Shelter Editor - " + path;
            txtVault.Text = StringHelper.IntegerToString(vault.Get("vault", "VaultName"));
            Caps.Text = vault.Get("vault", "storage", "resources", "Nuka").ToString();
            Food.Text = vault.Get("vault", "storage", "resources", "Food").ToString();
            Energy.Text = vault.Get("vault", "storage", "resources", "Energy").ToString();
            Water.Text = vault.Get("vault", "storage", "resources", "Water").ToString();

            MrHandy.Text = vault.Get("vault", "storage", "resources", "MrHandy").ToString();
            Lunchbox.Text = vault.Get("vault", "storage", "resources", "Lunchbox").ToString();
            StimPacks.Text = vault.Get("vault", "storage", "resources", "StimPack").ToString();
            RadAways.Text = vault.Get("vault", "storage", "resources", "RadAway").ToString();
            Quantum.Text = vault.Get("vault", "storage", "resources", "NukaColaQuantum").ToString();

            VaultMode.SelectedText = vault.Get("vault", "VaultMode").ToString();
            VaultTheme.SelectedIndex = (int)(vault.Get("vault", "VaultTheme"));

            DwellersViewList();

            btnSave.Enabled = true; // Enable the save button
        }

        // UpdateVault method: Update Vault instance with values from UI controls
        private void UpdateVault()
        {
            // Set values for different resources in the Vault
            vault.Set(decimal.Parse(txtVault.Text), "vault", "VaultName");
            vault.Set(decimal.Parse(Caps.Text), "vault", "storage", "resources", "Nuka");
            vault.Set(decimal.Parse(Food.Text), "vault", "storage", "resources", "Food");
            vault.Set(decimal.Parse(Energy.Text), "vault", "storage", "resources", "Energy");
            vault.Set(decimal.Parse(Water.Text), "vault", "storage", "resources", "Water");

            vault.Set(decimal.Parse(MrHandy.Text), "vault", "storage", "resources", "MrHandy");
            vault.Set(decimal.Parse(Lunchbox.Text), "vault", "storage", "resources", "Lunchbox");
            vault.Set(decimal.Parse(StimPacks.Text), "vault", "storage", "resources", "StimPack");
            vault.Set(decimal.Parse(RadAways.Text), "vault", "storage", "resources", "RadAway");
            vault.Set(decimal.Parse(Quantum.Text), "vault", "storage", "resources", "NukaColaQuantum");

            vault.Set(VaultMode.Text, "vault", "VaultMode");
            vault.Set(VaultTheme.SelectedIndex, "vault", "VaultTheme");

            UpdateDweller();
        }

        public void DwellersViewList()
        {
            var dwellers = (ArrayList)vault.Get("dwellers", "dwellers");
            if (dwellers != null)
            {
                foreach (Dictionary<string, object> dweller in dwellers)
                {
                    // Extract the necessary fields
                    string name = dweller.ContainsKey("name") ? dweller["name"].ToString() : "";
                    string lastName = dweller.ContainsKey("lastName") ? dweller["lastName"].ToString() : "";
                    string fullName = $"{name} {lastName}";

                    string rarity = dweller.ContainsKey("rarity") ? dweller["rarity"].ToString() : "";
                    int level = dweller.ContainsKey("experience") && ((Dictionary<string, object>)dweller["experience"]).ContainsKey("currentLevel")
                        ? Convert.ToInt32(((Dictionary<string, object>)dweller["experience"])["currentLevel"])
                        : 0;

                    string health = "";
                    if (dweller.ContainsKey("health"))
                    {
                        var healthData = (Dictionary<string, object>)dweller["health"];
                        int currentHealth = healthData.ContainsKey("healthValue") ? Convert.ToInt32(Convert.ToDouble(healthData["healthValue"])) : 0;
                        int maxHealth = healthData.ContainsKey("maxHealth") ? Convert.ToInt32(Convert.ToDouble(healthData["maxHealth"])) : 0;
                        health = $"{currentHealth} / {maxHealth}";
                    }

                    int happiness = dweller.ContainsKey("happiness") && ((Dictionary<string, object>)dweller["happiness"]).ContainsKey("happinessValue")
                        ? Convert.ToInt32(Convert.ToDouble(((Dictionary<string, object>)dweller["happiness"])["happinessValue"]))
                        : 0;

                    string gender = dweller.ContainsKey("gender")
                        ? (Convert.ToInt32(dweller["gender"]) == 2 ? "Male" : "Female")
                        : "";

                    // Extract stats array and initialize S.P.E.C.I.A.L values
                    int s = 0, p = 0, e = 0, c = 0, i = 0, a = 0, l = 0;
                    if (dweller.ContainsKey("stats"))
                    {
                        var statsData = (Dictionary<string, object>)dweller["stats"];
                        var statsArray = statsData.ContainsKey("stats") ? (ArrayList)statsData["stats"] : null;
                        if (statsArray != null && statsArray.Count >= 8)
                        {
                            s = Convert.ToInt32(((Dictionary<string, object>)statsArray[0])["value"]);
                            p = Convert.ToInt32(((Dictionary<string, object>)statsArray[1])["value"]);
                            e = Convert.ToInt32(((Dictionary<string, object>)statsArray[2])["value"]);
                            c = Convert.ToInt32(((Dictionary<string, object>)statsArray[3])["value"]);
                            i = Convert.ToInt32(((Dictionary<string, object>)statsArray[4])["value"]);
                            a = Convert.ToInt32(((Dictionary<string, object>)statsArray[5])["value"]);
                            l = Convert.ToInt32(((Dictionary<string, object>)statsArray[6])["value"]);
                        }
                    }

                    string weapon = "";
                    if (dweller.ContainsKey("equipedWeapon"))
                    {
                        var equippedWeapon = (Dictionary<string, object>)dweller["equipedWeapon"];
                        weapon = equippedWeapon.ContainsKey("id") ? equippedWeapon["id"].ToString() : "";
                    }

                    // Create a new ListViewItem and add sub-items
                    ListViewItem item = new ListViewItem(fullName);
                    item.SubItems.Add(rarity);
                    item.SubItems.Add(level.ToString());
                    item.SubItems.Add(health);
                    item.SubItems.Add(happiness.ToString());
                    item.SubItems.Add(gender);
                    item.SubItems.Add(s.ToString());  // Strength
                    item.SubItems.Add(p.ToString());  // Perception
                    item.SubItems.Add(c.ToString());  // Charisma
                    item.SubItems.Add(e.ToString());  // Endurance
                    item.SubItems.Add(i.ToString());  // Intelligence
                    item.SubItems.Add(a.ToString());  // Agility
                    item.SubItems.Add(l.ToString());  // Luck
                    item.SubItems.Add(weapon);        // Equipped Weapon

                    // Store the dweller object in the Tag property for easy access later
                    item.Tag = dweller;

                    // Add the item to the ListView
                    dwellersList.Items.Add(item);
                }
            }
        }

        private void removeRocks_Click(object sender, EventArgs e)
        {
            vault.Set(new ArrayList(), "vault", "rocks");
            MessageBox.Show(this, "Removed Rocks!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void unlockAllRooms_Click(object sender, EventArgs e)
        {
            vault.Set(new ArrayList(), "unlockableMgr", "objectivesInProgress");
            vault.Set(new ArrayList(), "unlockableMgr", "completed");

            ArrayList unlocks = new ArrayList
            {
                "StorageUnlock",
                "MedbayUnlock",
                "SciencelabUnlock",
                "OverseerUnlock",
                "RadioStationUnlock",
                "WeaponFactoryUnlock",
                "GymUnlock",
                "DojoUnlock",
                "ArmoryUnlock",
                "ClassUnlock",
                "OutfitFactoryUnlock",
                "CardioUnlock",
                "BarUnlock",
                "GameRoomUnlock",
                "BarberShopUnlock",
                "PowerPlantUnlock",
                "WaterroomUnlock",
                "HydroponicUnlock",
                "NukacolaUnlock",
                "DesignFactoryUnlock"
            };
            vault.Set(unlocks, "unlockableMgr", "claimed");
            MessageBox.Show(this, "Unlocked Rooms!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void unlockAllRecipes_Click(object sender, EventArgs e)
        {
            ArrayList recipes = new ArrayList
            {
                "Shotgun_Rusty",
                "Railgun",
                "LaserPistol_Focused",
                "PlasmaThrower_Boosted",
                "PlasmaThrower_Overcharged",
                "PipePistol_LittleBrother",
                "CombatShotgun_Hardened",
                "Flamer_Rusty",
                "LaserRifle_Tuned",
                "HuntingRifle_OlPainless",
                "PlasmaRifle_Focused",
                "PipeRifle",
                "JunkJet_Tactical",
                "InstitutePistol_Improved",
                "BBGun_RedRocket",
                "032Pistol_Hardened",
                "InstitutePistol_Apotheosis",
                "InstitutePistol_Scattered",
                "InstituteRifle_Excited",
                "PipeRifle_Long",
                "GatlingLaser",
                "PlasmaThrower_DragonsMaw",
                "PlasmaRifle",
                "AssaultRifle_Rusty",
                "AlienBlaster_Destabilizer",
                "Fatman_Guided",
                "Melee_RaiderSword",
                "SniperRifle_Hardened",
                "Melee_BaseballBat",
                "PlasmaRifle_MeanGreenMonster",
                "032Pistol_WildBillsSidearm",
                "GaussRifle",
                "LaserRifle_WaserWifle",
                "InstitutePistol_Scoped",
                "Flamer_Pressurized",
                "AssaultRifle_ArmorPiercing",
                "Railgun_Rusty",
                "Minigun_Hardened",
                "InstituteRifle_VirgilsRifle",
                "JunkJet_Electrified",
                "Flamer_Hardened",
                "GatlingLaser_Focused",
                "Magnum_Hardened",
                "Railgun_Railmaster",
                "Melee_PoolCue",
                "Minigun_Enhanced",
                "GaussRifle_Rusty",
                "JunkJet_RecoilCompensated",
                "Pistol_LoneWanderer",
                "MissilLauncher",
                "LaserPistol",
                "InstitutePistol_Incendiary",
                "BBGun_ArmorPiercing",
                "Rifle_ArmorPiercing",
                "AssaultRifle_Enhanced",
                "LaserRifle_Rusty",
                "CombatShotgun",
                "GatlingLaser_Tuned",
                "SawedOffShotgun_Hardened",
                "PlasmaThrower_Agitated",
                "Magnum_Blackhawk",
                "AssaultRifle_Infiltrator",
                "PlasmaPistol_MPLXNovasurge",
                "HuntingRifle_ArmorPiercing",
                "Railgun_Enhanced",
                "SniperRifle_Enhanced",
                "GaussRifle_Accelerated",
                "PlasmaThrower_Tactical",
                "CombatShotgun_Rusty",
                "PipeRifle_Bayoneted",
                "GaussRifle_Hardened",
                "PlasmaThrower",
                "AlienBlaster_Focused",
                "SawedOffShotgun_Kneecapper",
                "Flamer_Enhanced",
                "Railgun_Hardened",
                "GaussRifle_Magnetro4000",
                "PipePistol_Auto",
                "SniperRifle_ArmorPiercing",
                "PipeRifle_NightVision",
                "MissilLauncher_Enhanced",
                "PipeRifle_Calibrated",
                "LaserMusket",
                "Rifle_Hardened",
                "Fatman_Enhanced",
                "JunkJet",
                "PlasmaRifle_Amplified",
                "Minigun_Rusty",
                "Melee_FireHydrantBat",
                "GatlingLaser_Amplified",
                "JunkJet_Flaming",
                "Shotgun_DoubleBarrelled",
                "LaserPistol_Amplified",
                "AlienBlaster_Amplified",
                "InstituteRifle_NightVision",
                "SniperRifle_VictoryRifle",
                "PlasmaPistol",
                "Minigun_LeadBelcher",
                "Melee_ButcherKnife",
                "AssaultRifle",
                "Shotgun_Hardened",
                "MissilLauncher_Hardened",
                "LaserRifle_Focused",
                "AlienBlaster",
                "Melee_Pickaxe",
                "032Pistol_ArmorPiercing",
                "SniperRifle",
                "Pistol_ArmorPiercing",
                "PlasmaPistol_Tuned",
                "Melee_KitchenKnife",
                "AssaultRifle_Hardened",
                "Fatman_Hardened",
                "Shotgun_FarmersDaughter",
                "CombatShotgun_CharonsShotgun",
                "AlienBlaster_Rusty",
                "GatlingLaser_Vengeance",
                "InstituteRifle_Long",
                "JunkJet_TechniciansRevenge",
                "LaserPistol_SmugglersEnd",
                "Flamer_Burnmaster",
                "SniperRifle_Rusty",
                "InstituteRifle",
                "MissilLauncher_MissLauncher",
                "InstituteRifle_Targeting",
                "Fatman_Rusty",
                "Rifle_LincolnsRepeater",
                "PipeRifle_BigSister",
                "Fatman",
                "GatlingLaser_Rusty",
                "Fatman_Mirv",
                "PlasmaPistol_Focused",
                "Shotgun_Enhanced",
                "PipePistol_Scoped",
                "Minigun",
                "InstitutePistol",
                "ProfessorSpecial",
                "PiperSpecial",
                "AllNightware_Lucky",
                "KnightSpecial",
                "BowlingShirt",
                "HunterGear_Bounty",
                "BattleArmor_Sturdy",
                "ColonelSpecial",
                "UtilityJumpsuit_Sturdy",
                "DooWopOutfit",
                "PowerArmor_51f",
                "PowerArmor_MkVI",
                "PowerArmor_51d",
                "PowerArmor_51a",
                "BishopSpecial",
                "FlightSuit_Advanced",
                "SodaFountainDress",
                "HandymanJumpsuit_Expert",
                "HandymanJumpsuit_Advanced",
                "GreaserSpecial",
                "ThreedogSpecial",
                "WastelandSurgeon_Doctor",
                "PowerArmor_T45f",
                "CromwellSpecial",
                "PowerArmor_T45d",
                "WandererArmor_Sturdy",
                "LifeguardOutfit",
                "WrestlerSpecial",
                "EngineerSpecial",
                "MilitaryJumpsuit_Officer",
                "PrestonSpecial",
                "HazmatSuit_Heavy",
                "CombatArmor_Heavy",
                "RaiderArmor_Sturdy",
                "SlasherSpecial",
                "AlistairSpecial",
                "SurvivorSpecial",
                "AllNightware_Naughty",
                "InstituteJumper_Advanced",
                "SurgeonSpecial",
                "MayorSpecial",
                "RiotGear_Sturdy",
                "ScifiSpecial",
                "MetalArmor_Sturdy",
                "BOSUniform",
                "SynthArmor_Heavy",
                "Vest",
                "BittercupSpecial",
                "SoldierSpecial",
                "UtilityJumpsuit_Heavy",
                "HunterGear_Mutant",
                "AbrahamSpecial",
                "EulogyJonesSpecial",
                "PowerArmor_MkIV",
                "BaseballUniform",
                "PowerArmor_T60a",
                "PowerArmor_T60d",
                "FormalWear_Lucky",
                "PowerArmor_T60f",
                "Swimsuit",
                "LabCoat_Expert",
                "LabCoat_Advanced",
                "EmpressSpecial",
                "LibrarianSpecial",
                "KingSpecial",
                "MilitaryJumpsuit_Commander",
                "ScribeRobe",
                "BOSUniform_Expert",
                "LucasSpecial",
                "PrinceSpecial",
                "WandererArmor_Heavy",
                "RadiationSuit_Expert",
                "ScientistScrubs_Commander",
                "HazmatSuit_Sturdy",
                "MetalArmor_Heavy",
                "ButchSpecial",
                "ComedianSpecial",
                "RaiderArmor_Heavy",
                "FlightSuit_Expert",
                "SportsfanSpecial",
                "RothchildSpecial",
                "LabCoat",
                "BattleArmor",
                "BattleArmor_Heavy",
                "CombatArmor",
                "CombatArmor_Sturdy",
                "WandererArmor",
                "RaiderArmor",
                "WastelandSurgeon",
                "HunterGear_Treasure",
                "RiotGear",
                "RiotGear_Heavy",
                "SequinDress",
                "WastelandSurgeon_Settler",
                "HandymanJumpsuit",
                "MechanicJumpsuit",
                "InstituteJumper_Expert",
                "UtilityJumpsuit",
                "AllNightware",
                "WorkDress",
                "MilitaryJumpsuit",
                "FormalWear",
                "FormalWear_Fancy",
                "CheckeredShirt",
                "SweaterVest",
                "PowerArmor",
                "PowerArmor_MkI",
                "ScribeRobe_Initiate",
                "ScribeRobe_Elder",
                "RadiationSuit_Advanced",
                "RadiationSuit",
                "MoviefanSpecial",
                "NinjaSuit",
                "FlightSuit",
                "HazmatSuit",
                "BOSUniform_Advanced",
                "ScientistScrubs_Officer",
                "ScientistScrubs",
                "PolkaDotDress",
                "032Pistol",
                "032Pistol_Enhanced",
                "032Pistol_Rusty",
                "AlienBlaster_Tuned",
                "BBGun",
                "BBGun_Enhanced",
                "BBGun_Hardened",
                "BBGun_Rusty",
                "CombatShotgun_DoubleBarrelled",
                "CombatShotgun_Enhanced",
                "Flamer",
                "GaussRifle_Enhanced",
                "HuntingRifle",
                "HuntingRifle_Enhanced",
                "HuntingRifle_Hardened",
                "HuntingRifle_Rusty",
                "LaserPistol_Rusty",
                "LaserPistol_Tuned",
                "LaserRifle",
                "LaserRifle_Amplified",
                "Magnum",
                "Magnum_ArmorPiercing",
                "Magnum_Enhanced",
                "Magnum_Rusty",
                "Minigun_ArmorPiercing",
                "MissilLauncher_Guided",
                "MissilLauncher_Rusty",
                "PipePistol",
                "PipePistol_HairTrigger",
                "PipePistol_Heavy",
                "Pistol",
                "Pistol_Enhanced",
                "Pistol_Hardened",
                "Pistol_Rusty",
                "PlasmaPistol_Amplified",
                "PlasmaPistol_Rusty",
                "PlasmaRifle_Rusty",
                "PlasmaRifle_Tuned",
                "Railgun_Accelerated",
                "Rifle",
                "Rifle_Enhanced",
                "Rifle_Rusty",
                "SawedOffShotgun",
                "SawedOffShotgun_DoubleBarrelled",
                "SawedOffShotgun_Enhanced",
                "SawedOffShotgun_Rusty",
                "Shotgun"
            };
            vault.Set(recipes, "survivalW", "recipes");
            MessageBox.Show(this, "Unlocked Recipes!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maxSpecialAll_Click(object sender, EventArgs e)
        {
            var dwellers = (ArrayList)vault.Get("dwellers", "dwellers");
            if (dwellers != null)
            {
                for (int i = 0; i < dwellers.Count; i++)
                {
                    var dweller = dwellers[i] as Dictionary<string, object>;
                    if (dweller != null)
                    {
                        var stats = dweller["stats"] as Dictionary<string, object>;
                        var statsArray = stats["stats"] as ArrayList;
                        if (statsArray != null)
                        {
                            for (int j = 0; j < statsArray.Count; j++)
                            {
                                vault.Set(10, "dwellers", "dwellers", i.ToString(), "stats", "stats", j.ToString(), "value");
                            }
                        }
                    }
                }
            }

            MessageBox.Show("Maxed All Dwellers Stats!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maxhappinessAll_Click(object sender, EventArgs e)
        {
            var dwellers = (ArrayList)vault.Get("dwellers", "dwellers");
            if (dwellers != null)
            {
                for (int i = 0; i < dwellers.Count; i++)
                {
                    var dweller = dwellers[i] as Dictionary<string, object>;
                    if (dweller != null)
                    {
                        var happiness = dweller["happiness"] as Dictionary<string, object>;
                        if (happiness != null)
                        {
                            vault.Set(100, "dwellers", "dwellers", i.ToString(), "happiness", "happinessValue");
                        }
                    }
                }
            }

            MessageBox.Show("Maxed All Dwellers Happiness!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void healAll_Click(object sender, EventArgs e)
        {
            var dwellers = (ArrayList)vault.Get("dwellers", "dwellers");
            if (dwellers != null)
            {
                foreach (Dictionary<string, object> dweller in dwellers)
                {
                    var health = dweller["health"] as Dictionary<string, object>;
                    if (health != null)
                    {
                        vault.Set(0, "dwellers", "dwellers", dwellers.IndexOf(dweller).ToString(), "health", "radiationValue");
                        var maxHealth = health["maxHealth"]; // Assuming maxHealth is an integer
                        vault.Set(maxHealth, "dwellers", "dwellers", dwellers.IndexOf(dweller).ToString(), "health", "healthValue");
                    }
                }
            }

            MessageBox.Show("Healed All Dwellers!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void unlockthemes_Click(object sender, EventArgs e)
        {
            var themes = (ArrayList)vault.Get("survivalW", "collectedThemes", "themeList");
            if (themes != null)
            {
                foreach (Dictionary<string, object> theme in themes)
                {
                    var extraData = theme["extraData"] as Dictionary<string, object>;
                    if (extraData != null)
                    {
                        vault.Set(9, "survivalW", "collectedThemes", "themeList", themes.IndexOf(theme).ToString(), "extraData", "partsCollectedCount");
                        vault.Set(true, "survivalW", "collectedThemes", "themeList", themes.IndexOf(theme).ToString(), "extraData", "IsNew");
                    }
                }
            }

            MessageBox.Show("All themes unlocked!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearemergency_Click(object sender, EventArgs e)
        {
            var rooms = (ArrayList)vault.Get("vault", "rooms");
            if (rooms != null)
            {
                foreach (Dictionary<string, object> room in rooms)
                {
                    vault.Set("Idle", "vault", "rooms", rooms.IndexOf(room).ToString(), "currentStateName");
                    Debug.WriteLine(rooms.IndexOf(room).ToString());
                }
            }

            MessageBox.Show("Cleared Emergency on all rooms!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog
                {
                    DefaultExt = ".sav",
                    Filter = "Fallout Shelter Save|*.sav;*.bak",
                    Multiselect = false,
                    CheckFileExists = true
                };

                // Set initial directory based on whether a path is already set
                if (string.IsNullOrEmpty(path))
                {
                    // Get the local AppData path
                    string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var savePath = Path.Combine(localAppDataPath, "FalloutShelter");

                    if (Directory.Exists(savePath))
                    {
                        dialog.InitialDirectory = savePath;
                    }
                }

                // Show the file dialog and get the result
                var result = dialog.ShowDialog();
                path = dialog.FileName;

                // Read the Vault data from the selected file
                var readResult = vault.Read(path);
                if (readResult == false || vault.IsEmpty()) { }
                else
                {
                    // Call the method to update the UI with Vault data
                    UpdateUIWithVaultData();
                }
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@btLoad_Click: " + x.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateVault();
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@btSave_Click UpdateVault: " + x.Message);
                MessageBox.Show(this, x.Message, "Error when updating Vault Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    if (File.Exists(path + ".bak"))
                    {
                        // Show a confirmation dialog if a backup file already exists
                        var dialogResult = MessageBox.Show("An already existing backup file will be overwritten. Continue?", "Backup File exists", MessageBoxButtons.YesNoCancel);
                    }

                    // Write Vault data to the file and create a backup
                    if (vault.Write(path, ".bak"))
                    {
                        MessageBox.Show(this, "The Vault was updated successfully!", "Vault Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Unable to write the Save Data", "Error when Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception x)
                {
                    Debug.WriteLine(x.GetType() + "@btSave_Click Writing: " + x.Message);
                    MessageBox.Show(this, x.Message, "Error when Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }

        private void dwellersList_DoubleClick(object sender, EventArgs e)
        {
            if (dwellersList.SelectedItems.Count > 0)
            {
                var selectedItem = dwellersList.SelectedItems[0];
                var selectedItemIndex = dwellersList.SelectedItems[0].Index;
                var dweller = (Dictionary<string, object>)selectedItem.Tag;

                EditForm editForm = new EditForm(dweller, selectedItemIndex);
                editForm.ShowDialog();

                modifiedDwellerData = editForm.ModifiedDwellerData;
            }
        }

        public void UpdateDweller()
        {
            if (modifiedDwellerData != null)
            {
                var index = modifiedDwellerData["id"];
                vault.Set(modifiedDwellerData["name"], "dwellers", "dwellers", index.ToString(), "name");
                vault.Set(modifiedDwellerData["lastName"], "dwellers", "dwellers", index.ToString(), "lastName");

                var healthData = (Dictionary<string, object>)modifiedDwellerData["health"];
                vault.Set(healthData["healthValue"], "dwellers", "dwellers", index.ToString(), "health", "healthValue");

                var experienceData = (Dictionary<string, object>)modifiedDwellerData["experience"];
                vault.Set(experienceData["currentLevel"], "dwellers", "dwellers", index.ToString(), "experience", "currentLevel");

                var statsData = (Dictionary<string, object>)modifiedDwellerData["stats"];
                var statsArray = (ArrayList)statsData["stats"];
                for (int i = 0; i < statsArray.Count; i++)
                {
                    var stat = (Dictionary<string, object>)statsArray[i];
                    vault.Set(stat["value"], "dwellers", "dwellers", index.ToString(), "stats", "stats", i.ToString(), "value");
                }

                vault.Set(modifiedDwellerData["gender"], "dwellers", "dwellers", index.ToString(), "gender");

                vault.Set(modifiedDwellerData["skinColor"], "dwellers", "dwellers", index.ToString(), "skinColor");
                vault.Set(modifiedDwellerData["hairColor"], "dwellers", "dwellers", index.ToString(), "hairColor");

                var equippedWeapon = (Dictionary<string, object>)modifiedDwellerData["equipedWeapon"];
                vault.Set(equippedWeapon["id"], "dwellers", "dwellers", index.ToString(), "equipedWeapon", "id");

                var equippedPet = (Dictionary<string, object>)modifiedDwellerData["equippedPet"];
                if (equippedPet != null)
                {
                    vault.Set(equippedPet["id"], "dwellers", "dwellers", index.ToString(), "equippedPet", "id");
                    vault.Set(equippedPet["type"], "dwellers", "dwellers", index.ToString(), "equippedPet", "type");
                    vault.Set(equippedPet["hasBeenAssigned"], "dwellers", "dwellers", index.ToString(), "equippedPet", "hasBeenAssigned");
                    vault.Set(equippedPet["hasRandonWeaponBeenAssigned"], "dwellers", "dwellers", index.ToString(), "equippedPet", "hasRandonWeaponBeenAssigned");

                    var extraData = (Dictionary<string, object>)equippedPet["extraData"];
                    vault.Set(extraData["uniqueName"], "dwellers", "dwellers", index.ToString(), "equippedPet", "extraData", "uniqueName");
                    vault.Set(extraData["bonus"], "dwellers", "dwellers", index.ToString(), "equippedPet", "extraData", "bonus");
                    vault.Set(extraData["bonusValue"], "dwellers", "dwellers", index.ToString(), "equippedPet", "extraData", "bonusValue");
                }
            }
        }
    }
}