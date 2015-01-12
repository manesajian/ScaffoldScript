namespace ScaffoldScript
{
    partial class Sample1
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
            this.btnClearPatients = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.btnRandomPatient = new System.Windows.Forms.Button();
            this.txtTotalPatients = new System.Windows.Forms.TextBox();
            this.lblTotalPatients = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClearPatients
            // 
            this.btnClearPatients.ForeColor = System.Drawing.Color.Red;
            this.btnClearPatients.Location = new System.Drawing.Point(514, 11);
            this.btnClearPatients.Name = "btnClearPatients";
            this.btnClearPatients.Size = new System.Drawing.Size(81, 23);
            this.btnClearPatients.TabIndex = 1;
            this.btnClearPatients.Text = "Clear Patients";
            this.btnClearPatients.UseVisualStyleBackColor = true;
            this.btnClearPatients.Click += new System.EventHandler(this.btnClearPatients_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(183, 41);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(432, 96);
            this.txtOutput.TabIndex = 2;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(23, 16);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 3;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(86, 13);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(91, 20);
            this.txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(86, 65);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(91, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(22, 68);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "Last Name";
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.Location = new System.Drawing.Point(86, 91);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.Size = new System.Drawing.Size(91, 20);
            this.txtDateOfBirth.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date of Birth";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(86, 117);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(91, 20);
            this.txtPatientID.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Patient ID";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(86, 39);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(91, 20);
            this.txtMiddleName.TabIndex = 14;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Location = new System.Drawing.Point(12, 42);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(69, 13);
            this.lblMiddleName.TabIndex = 13;
            this.lblMiddleName.Text = "Middle Name";
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Location = new System.Drawing.Point(183, 11);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(75, 23);
            this.btnAddPatient.TabIndex = 15;
            this.btnAddPatient.Text = "Add Patient";
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // btnRandomPatient
            // 
            this.btnRandomPatient.Location = new System.Drawing.Point(264, 11);
            this.btnRandomPatient.Name = "btnRandomPatient";
            this.btnRandomPatient.Size = new System.Drawing.Size(91, 23);
            this.btnRandomPatient.TabIndex = 16;
            this.btnRandomPatient.Text = "Random Patient";
            this.btnRandomPatient.UseVisualStyleBackColor = true;
            this.btnRandomPatient.Click += new System.EventHandler(this.btnRandomPatient_Click);
            // 
            // txtTotalPatients
            // 
            this.txtTotalPatients.Location = new System.Drawing.Point(439, 13);
            this.txtTotalPatients.Name = "txtTotalPatients";
            this.txtTotalPatients.Size = new System.Drawing.Size(60, 20);
            this.txtTotalPatients.TabIndex = 18;
            // 
            // lblTotalPatients
            // 
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Location = new System.Drawing.Point(361, 16);
            this.lblTotalPatients.Name = "lblTotalPatients";
            this.lblTotalPatients.Size = new System.Drawing.Size(72, 13);
            this.lblTotalPatients.TabIndex = 17;
            this.lblTotalPatients.Text = "Total Patients";
            // 
            // Sample1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 152);
            this.Controls.Add(this.txtTotalPatients);
            this.Controls.Add(this.lblTotalPatients);
            this.Controls.Add(this.btnRandomPatient);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.txtMiddleName);
            this.Controls.Add(this.lblMiddleName);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateOfBirth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnClearPatients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Sample1";
            this.Text = "Sample1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearPatients;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.Button btnRandomPatient;
        private System.Windows.Forms.TextBox txtTotalPatients;
        private System.Windows.Forms.Label lblTotalPatients;
    }
}