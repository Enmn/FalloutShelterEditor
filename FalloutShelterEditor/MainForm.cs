using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FalloutShelterEditor
{
    public partial class MainForm : Form
    {
        private string path; // Path to the Fallout Shelter save file
        private readonly Vault vault; // Instance of the Vault class responsible for managing game data

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
        }

        // btnLoad_Click event: Handle the load button click
        private void btnLoad_Click(object sender, EventArgs e)
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
                if (readResult == false || vault.IsEmpty()) {}
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

        // btnSave_Click event: Handle the save button click
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Update Vault data based on UI controls
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

        // btnExit_Click event: Handle the exit button click
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }
    }
}