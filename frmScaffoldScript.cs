using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace ScaffoldScript
{
    public partial class frmScaffoldScript : Form
    {
        ScaffoldInterpreter interpreter = null;
  
        public frmScaffoldScript()
        {
            InitializeComponent();

            SetupScaffoldScript();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void LogMsg(string message)
        {
            txtLog.Text = String.Format ("{0} {1} {2} {3}", DateTime.Now , message, System.Environment.NewLine , txtLog.Text);
            txtLog.Update();
        }

        private void SetupScaffoldScript()
        {
            interpreter = new ScaffoldInterpreter();

            txtCurrentFunction.Text = "";
            txtScript.Text = "";

            lstFunctions.Items.Clear();

            for (int i = 0, count = interpreter.registeredFunctions.Count(); i < count; ++i)
            {
                lstFunctions.Items.Add(interpreter.registeredFunctions.ElementAt(i).Key);
            }

            SetToScriptNotExecuting();

            lstFunctions.Focus();
        }

        private void SetToScriptIsExecuting()
        {
            btnRunFunction.Enabled = false;
            btnLoadScript.Enabled = false;
            btnSaveScript.Enabled = false;
            txtScript.ReadOnly = true;

            btnStartStopScript.Text = "Stop Script";
        }

        private void SetToScriptNotExecuting()
        {
            btnRunFunction.Enabled = true;
            btnLoadScript.Enabled = true;
            btnSaveScript.Enabled = true;
            txtScript.ReadOnly = false;

            btnStartStopScript.Text = "Start Script";
        }

        private void lstFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCurrentFunction.Text = ((string)lstFunctions.SelectedItem);
        }

        private void ExecuteSelectedFunction()
        {
            string selectedFunction = txtCurrentFunction.Text;

            if (selectedFunction == "")
            {
                MessageBox.Show("Please select a valid function from the function ListBox.");
                lstFunctions.Focus();
                return;
            }

            ScaffoldFunction function = null;

            try
            {
                function = interpreter.scaffoldFunctions[selectedFunction];
            }
            catch
            {
                MessageBox.Show("Selected function is not known to Scaffold interpreter!");
                lstFunctions.Focus();
                return;
            }

            ExecuteScaffoldFunction(function);
        }

        private void btnRunFunction_Click(object sender, EventArgs e)
        {
            ExecuteSelectedFunction();
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            // Create OpenFileDialog
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".script";
            dlg.Filter = "ScaffoldScript|*.script";

            // Display OpenFileDialog by calling ShowDialog method
            DialogResult result = dlg.ShowDialog();

            // Get the selected filepath and display contents of file in a TextBox
            if (result == DialogResult.OK)
            {
                string filepath = dlg.FileName;

                // Read script into string
                System.IO.StreamReader scriptFile = new System.IO.StreamReader(filepath);
                string scriptString = scriptFile.ReadToEnd();

                scriptFile.Close();

                // Write script string into TextBox
                txtScript.Text = scriptString;
            }
        }

        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            // Create SaveFileDialog
            SaveFileDialog dlg = new SaveFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".script";
            dlg.Filter = "ScaffoldScript|*.script";

            // Display SaveFileDialog by calling ShowDialog method
            DialogResult result = dlg.ShowDialog();

            // Get the selected filepath and output TextBox to file
            if (result == DialogResult.OK)
            {
                string filepath = dlg.FileName;

                // Write script string to file
                System.IO.StreamWriter scriptFile = new System.IO.StreamWriter(filepath);
                scriptFile.WriteLine(txtScript.Text);

                scriptFile.Close();
            }
        }

        private void btnStartStopScript_Click(object sender, EventArgs e)
        {
            if ((string)(btnStartStopScript.Text) == "Start Script")
            {
                if (txtScript.Text == "")
                {
                    MessageBox.Show("Please populate TextBox with valid ScaffoldScript.");
                    txtScript.Focus();
                    return;
                }

                SetToScriptIsExecuting();

                Thread scriptThread = new Thread(new ThreadStart(ExecuteScript));
                scriptThread.Start();
            }
            else
            {
                interpreter.interrupted = true;
            }
        }

        private void ExecuteScript()
        {
            ScaffoldInterpreter interpreter = new ScaffoldInterpreter();

            bool result = interpreter.ExecuteScript(txtScript.Text);

            if (result)
            {
                LogMsg(interpreter.logBuffer);
            }
            else
            {
                LogMsg(interpreter.errorBuffer);
            }

            interpreter.interrupted = false;

            SetToScriptNotExecuting();
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            SetupScaffoldScript();

            txtLog.Text = "";
        }

        private void ExecuteScaffoldFunction(ScaffoldFunction function)
        {
            string result = interpreter.ExecuteFunction(function);

            if (result != "")
            {
                MessageBox.Show(result);
                btnRunFunction.Focus();
            }
        }

        private void lstFunctions_DoubleClick(object sender, EventArgs e)
        {
            ExecuteSelectedFunction();
        }

        private void frmScaffoldScript_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
