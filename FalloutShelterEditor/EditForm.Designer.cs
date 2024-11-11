namespace FalloutShelterEditor
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHealth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAgility = new System.Windows.Forms.NumericUpDown();
            this.txtIntelligence = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLuck = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndurance = new System.Windows.Forms.NumericUpDown();
            this.txtPerception = new System.Windows.Forms.NumericUpDown();
            this.txtStrength = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCharisma = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbPets = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbWeapons = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Level = new System.Windows.Forms.GroupBox();
            this.txtLevel = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.skinColorPicker = new System.Windows.Forms.TextBox();
            this.hairColorPicker = new System.Windows.Forms.TextBox();
            this.skinColorDialog = new System.Windows.Forms.ColorDialog();
            this.hairColorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealth)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerception)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharisma)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Level.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGender);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtHealth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 201);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(79, 112);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(145, 25);
            this.cmbGender.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender";
            // 
            // txtHealth
            // 
            this.txtHealth.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHealth.Location = new System.Drawing.Point(79, 153);
            this.txtHealth.Name = "txtHealth";
            this.txtHealth.Size = new System.Drawing.Size(145, 25);
            this.txtHealth.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Health";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLastName.Location = new System.Drawing.Point(79, 72);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(145, 25);
            this.txtLastName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.Location = new System.Drawing.Point(79, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 25);
            this.txtName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAgility);
            this.groupBox2.Controls.Add(this.txtIntelligence);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtLuck);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEndurance);
            this.groupBox2.Controls.Add(this.txtPerception);
            this.groupBox2.Controls.Add(this.txtStrength);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCharisma);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(275, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 261);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "S.P.E.C.I.A.L";
            // 
            // txtAgility
            // 
            this.txtAgility.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtAgility.Location = new System.Drawing.Point(31, 178);
            this.txtAgility.Name = "txtAgility";
            this.txtAgility.Size = new System.Drawing.Size(207, 25);
            this.txtAgility.TabIndex = 25;
            // 
            // txtIntelligence
            // 
            this.txtIntelligence.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtIntelligence.Location = new System.Drawing.Point(31, 147);
            this.txtIntelligence.Name = "txtIntelligence";
            this.txtIntelligence.Size = new System.Drawing.Size(207, 25);
            this.txtIntelligence.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "A";
            // 
            // txtLuck
            // 
            this.txtLuck.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLuck.Location = new System.Drawing.Point(31, 209);
            this.txtLuck.Name = "txtLuck";
            this.txtLuck.Size = new System.Drawing.Size(207, 25);
            this.txtLuck.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 212);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "L";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "I";
            // 
            // txtEndurance
            // 
            this.txtEndurance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEndurance.Location = new System.Drawing.Point(31, 85);
            this.txtEndurance.Name = "txtEndurance";
            this.txtEndurance.Size = new System.Drawing.Size(207, 25);
            this.txtEndurance.TabIndex = 19;
            // 
            // txtPerception
            // 
            this.txtPerception.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPerception.Location = new System.Drawing.Point(30, 54);
            this.txtPerception.Name = "txtPerception";
            this.txtPerception.Size = new System.Drawing.Size(208, 25);
            this.txtPerception.TabIndex = 18;
            // 
            // txtStrength
            // 
            this.txtStrength.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStrength.Location = new System.Drawing.Point(30, 25);
            this.txtStrength.Name = "txtStrength";
            this.txtStrength.Size = new System.Drawing.Size(208, 25);
            this.txtStrength.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "E";
            // 
            // txtCharisma
            // 
            this.txtCharisma.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCharisma.Location = new System.Drawing.Point(31, 116);
            this.txtCharisma.Name = "txtCharisma";
            this.txtCharisma.Size = new System.Drawing.Size(207, 25);
            this.txtCharisma.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "C";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "P";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 17);
            this.label9.TabIndex = 11;
            this.label9.Text = "S";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbPets);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.cmbWeapons);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(507, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Equipment";
            // 
            // cmbPets
            // 
            this.cmbPets.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbPets.FormattingEnabled = true;
            this.cmbPets.Location = new System.Drawing.Point(304, 24);
            this.cmbPets.Name = "cmbPets";
            this.cmbPets.Size = new System.Drawing.Size(197, 25);
            this.cmbPets.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(272, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Pet";
            // 
            // cmbWeapons
            // 
            this.cmbWeapons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbWeapons.FormattingEnabled = true;
            this.cmbWeapons.Location = new System.Drawing.Point(71, 23);
            this.cmbWeapons.Name = "cmbWeapons";
            this.cmbWeapons.Size = new System.Drawing.Size(173, 25);
            this.cmbWeapons.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Weapon";
            // 
            // Level
            // 
            this.Level.Controls.Add(this.txtLevel);
            this.Level.Controls.Add(this.label13);
            this.Level.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Level.Location = new System.Drawing.Point(12, 215);
            this.Level.Name = "Level";
            this.Level.Size = new System.Drawing.Size(244, 58);
            this.Level.TabIndex = 3;
            this.Level.TabStop = false;
            this.Level.Text = "Level";
            // 
            // txtLevel
            // 
            this.txtLevel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLevel.Location = new System.Drawing.Point(52, 21);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(172, 25);
            this.txtLevel.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Level";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(426, 428);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 29);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(327, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 29);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hairColorPicker);
            this.groupBox4.Controls.Add(this.skinColorPicker);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 346);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(507, 64);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Appearance ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(272, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 17);
            this.label16.TabIndex = 11;
            this.label16.Text = "Hair color";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "Skin color";
            // 
            // skinColorPicker
            // 
            this.skinColorPicker.BackColor = System.Drawing.Color.WhiteSmoke;
            this.skinColorPicker.Location = new System.Drawing.Point(79, 24);
            this.skinColorPicker.Name = "skinColorPicker";
            this.skinColorPicker.Size = new System.Drawing.Size(145, 25);
            this.skinColorPicker.TabIndex = 12;
            this.skinColorPicker.Click += new System.EventHandler(this.skinColor_Click);
            // 
            // hairColorPicker
            // 
            this.hairColorPicker.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hairColorPicker.Location = new System.Drawing.Point(344, 25);
            this.hairColorPicker.Name = "hairColorPicker";
            this.hairColorPicker.Size = new System.Drawing.Size(157, 25);
            this.hairColorPicker.TabIndex = 13;
            this.hairColorPicker.Click += new System.EventHandler(this.hairColor_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(531, 469);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.Level);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Dweller";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHealth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerception)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCharisma)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Level.ResumeLayout(false);
            this.Level.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLevel)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtHealth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtAgility;
        private System.Windows.Forms.NumericUpDown txtIntelligence;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtLuck;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown txtEndurance;
        private System.Windows.Forms.NumericUpDown txtPerception;
        private System.Windows.Forms.NumericUpDown txtStrength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtCharisma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox Level;
        private System.Windows.Forms.NumericUpDown txtLevel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPets;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbWeapons;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox hairColorPicker;
        public System.Windows.Forms.TextBox skinColorPicker;
        private System.Windows.Forms.ColorDialog skinColorDialog;
        private System.Windows.Forms.ColorDialog hairColorDialog;
    }
}