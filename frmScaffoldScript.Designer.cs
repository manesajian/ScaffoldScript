namespace ScaffoldScript
{
    partial class frmScaffoldScript
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
            this.btnRunFunction = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.btnStartStopScript = new System.Windows.Forms.Button();
            this.btnResetAll = new System.Windows.Forms.Button();
            this.txtCurrentFunction = new System.Windows.Forms.TextBox();
            this.txtScript = new System.Windows.Forms.TextBox();
            this.lstFunctions = new System.Windows.Forms.ListBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnRunFunction
            // 
            this.btnRunFunction.Location = new System.Drawing.Point(44, 12);
            this.btnRunFunction.Name = "btnRunFunction";
            this.btnRunFunction.Size = new System.Drawing.Size(80, 23);
            this.btnRunFunction.TabIndex = 0;
            this.btnRunFunction.Text = "RunFunction";
            this.btnRunFunction.UseVisualStyleBackColor = true;
            this.btnRunFunction.Click += new System.EventHandler(this.btnRunFunction_Click);
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(168, 12);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScript.TabIndex = 1;
            this.btnLoadScript.Text = "Load Script";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Location = new System.Drawing.Point(249, 12);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(75, 23);
            this.btnSaveScript.TabIndex = 2;
            this.btnSaveScript.Text = "Save Script";
            this.btnSaveScript.UseVisualStyleBackColor = true;
            this.btnSaveScript.Click += new System.EventHandler(this.btnSaveScript_Click);
            // 
            // btnStartStopScript
            // 
            this.btnStartStopScript.Location = new System.Drawing.Point(330, 12);
            this.btnStartStopScript.Name = "btnStartStopScript";
            this.btnStartStopScript.Size = new System.Drawing.Size(75, 23);
            this.btnStartStopScript.TabIndex = 3;
            this.btnStartStopScript.Text = "Start Script";
            this.btnStartStopScript.UseVisualStyleBackColor = true;
            this.btnStartStopScript.Click += new System.EventHandler(this.btnStartStopScript_Click);
            // 
            // btnResetAll
            // 
            this.btnResetAll.ForeColor = System.Drawing.Color.Red;
            this.btnResetAll.Location = new System.Drawing.Point(427, 12);
            this.btnResetAll.Name = "btnResetAll";
            this.btnResetAll.Size = new System.Drawing.Size(75, 23);
            this.btnResetAll.TabIndex = 4;
            this.btnResetAll.Text = "Reset All";
            this.btnResetAll.UseVisualStyleBackColor = true;
            this.btnResetAll.Click += new System.EventHandler(this.btnResetAll_Click);
            // 
            // txtCurrentFunction
            // 
            this.txtCurrentFunction.Location = new System.Drawing.Point(12, 41);
            this.txtCurrentFunction.Name = "txtCurrentFunction";
            this.txtCurrentFunction.Size = new System.Drawing.Size(150, 20);
            this.txtCurrentFunction.TabIndex = 5;
            // 
            // txtScript
            // 
            this.txtScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtScript.Location = new System.Drawing.Point(168, 41);
            this.txtScript.Multiline = true;
            this.txtScript.Name = "txtScript";
            this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScript.Size = new System.Drawing.Size(334, 95);
            this.txtScript.TabIndex = 6;
            // 
            // lstFunctions
            // 
            this.lstFunctions.FormattingEnabled = true;
            this.lstFunctions.Location = new System.Drawing.Point(12, 67);
            this.lstFunctions.Name = "lstFunctions";
            this.lstFunctions.ScrollAlwaysVisible = true;
            this.lstFunctions.Size = new System.Drawing.Size(150, 69);
            this.lstFunctions.TabIndex = 7;
            this.lstFunctions.SelectedIndexChanged += new System.EventHandler(this.lstFunctions_SelectedIndexChanged);
            this.lstFunctions.DoubleClick += new System.EventHandler(this.lstFunctions_DoubleClick);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 142);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(490, 295);
            this.txtLog.TabIndex = 8;
            // 
            // frmScaffoldScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 449);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lstFunctions);
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.txtCurrentFunction);
            this.Controls.Add(this.btnResetAll);
            this.Controls.Add(this.btnStartStopScript);
            this.Controls.Add(this.btnSaveScript);
            this.Controls.Add(this.btnLoadScript);
            this.Controls.Add(this.btnRunFunction);
            this.MinimumSize = new System.Drawing.Size(530, 487);
            this.Name = "frmScaffoldScript";
            this.Text = "ScaffoldScript";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScaffoldScript_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRunFunction;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnStartStopScript;
        private System.Windows.Forms.Button btnResetAll;
        private System.Windows.Forms.TextBox txtCurrentFunction;
        private System.Windows.Forms.TextBox txtScript;
        private System.Windows.Forms.ListBox lstFunctions;
        private System.Windows.Forms.TextBox txtLog;
    }
}

