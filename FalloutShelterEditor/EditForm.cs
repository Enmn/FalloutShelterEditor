using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FalloutShelterEditor
{
    public partial class EditForm : Form
    {
        public Dictionary<string, object> ModifiedDwellerData;

        private int idDwellerData;
        uint skinColorValue;
        uint hairColorValue;

        public string DwellerName
        {
            get { return txtName.Text; }
        }

        public EditForm(Dictionary<string, object> dweller, int selectedItemIndex)
        {
            InitializeComponent();
            idDwellerData = selectedItemIndex;
            LoadDwellerDetails(dweller);
        }

        public void PopulateWeaponComboBox(string equippedWeaponId)
        {
            string csvFilePath = "Resources\\csv_weapons.csv"; // Replace with the actual path to your CSV file
            var weapons = Weapons.LoadWeaponsFromCsv(csvFilePath);

            cmbWeapons.Items.Clear();
            foreach (var weapon in weapons)
            {
                cmbWeapons.Items.Add(weapon);
            }

            cmbWeapons.DisplayMember = "Name";

            // Select the equipped weapon if it exists in the ComboBox
            if (!string.IsNullOrEmpty(equippedWeaponId))
            {
                cmbWeapons.SelectedItem = weapons.FirstOrDefault(w => w.Id == equippedWeaponId);
            }
        }

        public void PopulatePetComboBox(string equippedPetId)
        {
            string csvFilePath = "Resources\\csv_pets.csv"; // Replace with the actual path to your CSV file
            var pets = Pets.LoadPetsFromCsv(csvFilePath);

            cmbPets.Items.Clear();
            foreach (var pet in pets)
            {
                cmbPets.Items.Add(pet);
            }

            cmbPets.DisplayMember = "Name";

            // Select the equipped pet if it exists in the ComboBox
            if (!string.IsNullOrEmpty(equippedPetId))
            {
                cmbPets.SelectedItem = pets.FirstOrDefault(w => w.Id == equippedPetId);
            }
        }

        private void LoadDwellerDetails(Dictionary<string, object> dweller)
        {
            txtName.Text = dweller.ContainsKey("name") ? dweller["name"].ToString() : "";
            txtLastName.Text = dweller.ContainsKey("lastName") ? dweller["lastName"].ToString() : "";

            if (dweller.ContainsKey("health"))
            {
                var healthData = (Dictionary<string, object>)dweller["health"];
                txtHealth.Text = healthData.ContainsKey("healthValue") ? healthData["healthValue"].ToString() : "";
            }

            if (dweller.ContainsKey("experience"))
            {
                var experienceData = (Dictionary<string, object>)dweller["experience"];
                txtLevel.Text = experienceData.ContainsKey("currentLevel") ? experienceData["currentLevel"].ToString() : "";
            }

            if (dweller.ContainsKey("stats"))
            {
                var statsData = (Dictionary<string, object>)dweller["stats"];
                var statsArray = statsData.ContainsKey("stats") ? (ArrayList)statsData["stats"] : null;
                if (statsArray != null && statsArray.Count >= 8)
                {
                    txtStrength.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[0])["value"]).ToString();
                    txtPerception.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[1])["value"]).ToString();
                    txtEndurance.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[2])["value"]).ToString();
                    txtCharisma.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[3])["value"]).ToString();
                    txtIntelligence.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[4])["value"]).ToString();
                    txtAgility.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[5])["value"]).ToString();
                    txtLuck.Text = Convert.ToInt32(((Dictionary<string, object>)statsArray[6])["value"]).ToString();
                }
            }

            if (dweller.ContainsKey("gender"))
            {
                int genderValue = Convert.ToInt32(dweller["gender"]);
                cmbGender.SelectedItem = genderValue == 2 ? "Male" : "Female";
            }

            string equippedWeaponId = "";
            if (dweller.ContainsKey("equipedWeapon"))
            {
                var equippedWeapon = (Dictionary<string, object>)dweller["equipedWeapon"];
                equippedWeaponId = equippedWeapon.ContainsKey("id") ? equippedWeapon["id"].ToString() : "";
            }

            PopulateWeaponComboBox(equippedWeaponId);

            string equippedPetId = "";
            if (dweller.ContainsKey("equippedPet"))
            {
                var equippedPet = (Dictionary<string, object>)dweller["equippedPet"];
                equippedPetId = equippedPet.ContainsKey("id") ? equippedPet["id"].ToString() : "";
            }

            PopulatePetComboBox(equippedPetId);

            var skinColorObject = dweller["skinColor"];
            long skinColorLong = Convert.ToInt64(skinColorObject);
            uint skinColor = (uint)skinColorLong;
            SetBackColorFromDecimal(skinColor, skinColorPicker);

            var hairColorObject = dweller["hairColor"];
            long hairColorLong = Convert.ToInt64(hairColorObject);
            uint hairColor = (uint)hairColorLong;
            SetBackColorFromDecimal(hairColor, hairColorPicker);

            skinColorValue = skinColor;
            hairColorValue = hairColor;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Collect modified dweller data
            ModifiedDwellerData = new Dictionary<string, object>
            {
                { "id", idDwellerData },
                { "name", txtName.Text },
                { "lastName", txtLastName.Text },
                { "health", new Dictionary<string, object>
                    {
                        { "healthValue", txtHealth.Text }
                    }
                },
                { "experience", new Dictionary<string, object>
                    {
                        { "currentLevel", txtLevel.Text }
                    }
                },
                { "stats", new Dictionary<string, object>
                    {
                        { "stats", new ArrayList
                            {
                                new Dictionary<string, object> { { "value", int.Parse(txtStrength.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtPerception.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtEndurance.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtCharisma.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtIntelligence.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtAgility.Text) } },
                                new Dictionary<string, object> { { "value", int.Parse(txtLuck.Text) } }
                            }
                        }
                    }
                },
                { "gender", cmbGender.SelectedItem.ToString() == "Male" ? 2 : 1 },
                { "skinColor", skinColorValue },
                { "hairColor", hairColorValue },
                { "equipedWeapon", new Dictionary<string, object>
                    {
                        { "id", ((Weapon)cmbWeapons.SelectedItem)?.Id }
                    }
                },
                { "equippedPet", new Dictionary<string, object>
                    {
                        { "id", ((Pet)cmbPets.SelectedItem)?.Id },
                        { "type", "Pet" },
                        { "hasBeenAssigned", false },
                        { "hasRandonWeaponBeenAssigned", false },
                        { "extraData", new Dictionary<string, object>
                            {
                                { "uniqueName", "Kalluk" },
                                { "bonus", ((Pet)cmbPets.SelectedItem)?.Bonus },
                                { "bonusValue", ((Pet)cmbPets.SelectedItem)?.bonusValue }
                            }
                        }
                    }
                }
            };

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsColorDark(Color color)
        {
            // Calculate the brightness of the color
            // This formula is a commonly used way to determine if a color is light or dark
            double brightness = (color.R * 0.299 + color.G * 0.587 + color.B * 0.114) / 255;
            return brightness < 0.5;
        }

        private void skinColor_Click(object sender, EventArgs e)
        {
            // Sets the initial color select to the current text color.
            skinColorDialog.Color = skinColorPicker.BackColor;

            // Update the text box color if the user clicks OK 
            if (skinColorDialog.ShowDialog() == DialogResult.OK)
            {
                skinColorPicker.BackColor = skinColorDialog.Color;
                skinColorPicker.Text = ColorTranslator.ToHtml(skinColorDialog.Color);

                String code = "FF" + (skinColorDialog.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                uint colorArgb = Convert.ToUInt32(code, 16);

                skinColorValue = colorArgb;

                // Determine if the selected color is light or dark
                if (IsColorDark(skinColorDialog.Color))
                {
                    skinColorPicker.ForeColor = Color.White;
                }
                else
                {
                    skinColorPicker.ForeColor = Color.Black;
                }
            }
        }

        private void hairColor_Click(object sender, EventArgs e)
        {
            // Sets the initial color select to the current text color.
            hairColorDialog.Color = hairColorPicker.BackColor;

            // Update the text box color if the user clicks OK 
            if (hairColorDialog.ShowDialog() == DialogResult.OK)
            {
                hairColorPicker.BackColor = hairColorDialog.Color;
                hairColorPicker.Text = ColorTranslator.ToHtml(hairColorDialog.Color);

                String code = "FF" + (hairColorDialog.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                uint colorArgb = Convert.ToUInt32(code, 16);

                hairColorValue = colorArgb;

                // Determine if the selected color is light or dark
                if (IsColorDark(hairColorDialog.Color))
                {
                    hairColorPicker.ForeColor = Color.White;
                }
                else
                {
                    hairColorPicker.ForeColor = Color.Black;
                }
            }
        }

        private void SetBackColorFromDecimal(uint decimalColor, System.Windows.Forms.TextBox picker)
        {
            // Convert the decimal value to Color using the 32-bit ARGB format
            Color color = Color.FromArgb((int)decimalColor);

            // Set the background color and the text of the TextBox
            picker.BackColor = color;
            picker.Text = ColorTranslator.ToHtml(color);

            // Determine if the color is dark and set the ForeColor accordingly
            if (IsColorDark(color))
            {
                picker.ForeColor = Color.White;
            }
            else
            {
                picker.ForeColor = Color.Black;
            }
        }
    }
}
