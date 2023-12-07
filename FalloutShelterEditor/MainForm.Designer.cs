namespace FalloutShelterEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtVault = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Caps = new System.Windows.Forms.NumericUpDown();
            this.Food = new System.Windows.Forms.NumericUpDown();
            this.Energy = new System.Windows.Forms.NumericUpDown();
            this.Water = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Caps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Energy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Water)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVault
            // 
            this.txtVault.Location = new System.Drawing.Point(54, 12);
            this.txtVault.Name = "txtVault";
            this.txtVault.Size = new System.Drawing.Size(195, 20);
            this.txtVault.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 244);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(93, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(174, 244);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vault";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Caps";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Food";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Energy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Water";
            // 
            // Caps
            // 
            this.Caps.Location = new System.Drawing.Point(54, 56);
            this.Caps.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Caps.Name = "Caps";
            this.Caps.Size = new System.Drawing.Size(195, 20);
            this.Caps.TabIndex = 14;
            // 
            // Food
            // 
            this.Food.Location = new System.Drawing.Point(54, 98);
            this.Food.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Food.Name = "Food";
            this.Food.Size = new System.Drawing.Size(195, 20);
            this.Food.TabIndex = 15;
            // 
            // Energy
            // 
            this.Energy.Location = new System.Drawing.Point(54, 141);
            this.Energy.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Energy.Name = "Energy";
            this.Energy.Size = new System.Drawing.Size(195, 20);
            this.Energy.TabIndex = 16;
            // 
            // Water
            // 
            this.Water.Location = new System.Drawing.Point(54, 185);
            this.Water.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.Water.Name = "Water";
            this.Water.Size = new System.Drawing.Size(195, 20);
            this.Water.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 276);
            this.Controls.Add(this.Water);
            this.Controls.Add(this.Energy);
            this.Controls.Add(this.Food);
            this.Controls.Add(this.Caps);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtVault);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout Shelter Editor";
            ((System.ComponentModel.ISupportInitialize)(this.Caps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Food)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Energy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Water)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVault;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown Caps;
        private System.Windows.Forms.NumericUpDown Food;
        private System.Windows.Forms.NumericUpDown Energy;
        private System.Windows.Forms.NumericUpDown Water;
    }
}

