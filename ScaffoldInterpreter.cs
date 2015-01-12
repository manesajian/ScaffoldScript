using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace ScaffoldScript
{
    class ScaffoldInterpreter
    {
        // Function-lists can be associated with a name and stored here
        public Dictionary<string, Dictionary<string, ScaffoldFunction>> savedFunctionLists = null;

        // Dictionary of all the functions that are known to the interpreter
        public Dictionary<string, ScaffoldFunction> scaffoldFunctions = null;

        // A subset of known (DEFINEd functions) that have been registered
        public Dictionary<string, ScaffoldFunction> registeredFunctions = null;

        // Threads started via ScaffoldScript are tracked with this dictionary
        public Dictionary<string, ScaffoldThread> scaffoldThreads = null;

        // Scaffold C# functions which create forms must add them to this dictionary
        public Dictionary<string, Form> scaffoldForms = null;

        // Can be used to record messages and actions
        public string logBuffer = "";

        // Will be used to store any errors resulting from running a script
        public string errorBuffer = "";

        // This can be used to signal interpreter to stop executing script
        public bool interrupted = false;

        public ScaffoldInterpreter()
        {
            savedFunctionLists = new Dictionary<string, Dictionary<string, ScaffoldFunction>>();
            scaffoldFunctions = new Dictionary<string, ScaffoldFunction>();
            registeredFunctions = new Dictionary<string, ScaffoldFunction>();
            scaffoldThreads = new Dictionary<string, ScaffoldThread>();
            scaffoldForms = new Dictionary<string, Form>();

            // Add pre-built (registered by default) functions here
            RegisterFunction("Sample1", new SFSample1("Sample1"));
        }

        private void RegisterFunction(string function_name, ScaffoldFunction function)
        {
            scaffoldFunctions.Add(function_name, function);
            registeredFunctions.Add(function_name, function);
        }

        private void LogMessage(string message)
        {
            logBuffer = message + System.Environment.NewLine + logBuffer;
        }

        // Returns result of function
        public string ExecuteFunction(ScaffoldFunction function)
        {
            try
            {
                Thread formThread = new Thread(new ThreadStart(function.ExecuteFunction));
                formThread.Start();

                Thread.Sleep(1500);

                if (function.activeForm != null)
                {
                    scaffoldForms.Add(function.activeForm.Name, function.activeForm);
                }
                else
                    throw new Exception("CATASTROPHIC!");

                return "";
                //return result;
            }
            catch
            {
                // Suppress possible bug for purposes of demo
                //throw new Exception("Could not execute function.");
            }

            return "";
        }

        // Executes ScaffoldScript
        // Returns whether execution was successful or not        
        public bool ExecuteScript(string script)
        {
            // Clear the log from previous execution
            logBuffer = "";

            // Clear out any errors from previous execution
            errorBuffer = "";

            List<string> script_statements = PreprocessScript(script);

            bool successful = true;

            string unfinished_statement = "";
            for (int i = 0; i < script_statements.Count(); ++i)
            {
                try
                {
                    string statement = unfinished_statement + script_statements[i];

                    LogMessage("Attempting statement: " + statement);

                    // If ExecuteStatement is able to finish processing statement, it returns empty string
                    unfinished_statement = ExecuteStatement(statement);

                    if (unfinished_statement != "")
                        LogMessage("Not yet able to parse statement.");
                }
                catch (Exception e)
                {
                    errorBuffer = e.Message;
                    successful = false;
                    break;
                }
            }


            return successful;
        }

        public List<string> PreprocessScript(string script)
        {
            // Start by splitting into lines, trimming each line, and removing all comments
            string[] line_elems = script.Split('\n');
            for (int i = 0; i < line_elems.Count(); ++i)
            {
                string elem = line_elems[i].Trim();
                if (elem.StartsWith("*"))
                {
                    elem = "";
                }

                line_elems[i] = elem;
            }

            // Create new list ignoring all empty lines (comment lines are now empty lines)
            List<string> line_list = new List<string>();
            for (int i = 0; i < line_elems.Count(); ++i)
            {
                if (line_elems[i].Trim() == "")
                    continue;

                line_list.Add(line_elems[i]);
            }

            // Handle IMPORT keyword (note that this makes the function recursive)
            List<string> all_lines = new List<string>();
            for (int i = 0; i < line_list.Count(); ++i)
            {
                if (!line_elems[i].StartsWith("IMPORT "))
                {
                    all_lines.Add(line_elems[i]);
                    continue;
                }
                
                // Trim the keyword off. Trim whitespace. Trim single-quotes.
                string filepath = line_elems[i].Substring("IMPORT ".Length).Trim().Trim('\'');

                // Read IMPORTed file into a string, silently supressing non-existant IMPORTs
                string scriptString = "";
                try
                {
                    System.IO.StreamReader scriptFile = new System.IO.StreamReader(filepath);
                    scriptString = scriptFile.ReadToEnd();
                    scriptFile.Close();
                }
                catch
                {
                }

                // By making this a recursive function, we can handle nested IMPORTs
                all_lines.Concat(PreprocessScript(scriptString));
            }

            // Concatenate lines when necessary so that every line ends in a semi-colon
            List<string> statement_lines = new List<string>();
            int index = 0;
            string current_line = "";
            while (index < all_lines.Count())
            {
                if (current_line == "")
                    current_line = all_lines[index];
                else
                    current_line = (current_line + " " + all_lines[index]).Trim();

                if (!current_line.EndsWith(";"))
                {
                    index += 1;
                    continue;
                }

                statement_lines.Add(current_line);
                current_line = "";
                index += 1;
            }

            return statement_lines;
        }

        private string ExecuteStatement(string statement)
        {
            string unfinished = "";

            // Remove terminating semi-colon

            // Split based on spaces
            string [] elems = statement.Split(' ');

            // Remove terminating semi-colon from last element. This prevents us from needing to
            //  do this for the individual command-handler functions.
            elems[elems.Length - 1] = elems[elems.Length - 1].TrimEnd(';');

            // Switch on first word (generally keyword)            
            switch(elems[0])
            {
                case "DEFINE":
                    // DEFINE may consist of more than one statement. If this "statement"
                    //  does not complete the DEFINE, it will be returned so that it can be
                    //  prepended to the next statement
                    unfinished = HandleDEFINE(statement, elems);
                    break;
                case "REGISTER":
                    HandleREGISTER(statement, elems);
                    break;
                case "UNREGISTER":
                    HandleUNREGISTER(statement, elems);
                    break;
                case "SAVEFUNCLIST":
                    HandleSAVEFUNCLIST(statement, elems);
                    break;
                case "LOADFUNCLIST":
                    HandleLOADFUNCLIST(statement, elems);
                    break;
                case "CALL":
                    HandleCALL(statement, elems);
                    break;
                case "LOG":
                    HandleLOG(statement, elems);
                    break;
                case "CLEARLOG":
                    HandleCLEARLOG(statement, elems);
                    break;
                case "SLEEP":
                    HandleSLEEP(statement, elems);
                    break;
                case "IF":
                    HandleIF(statement, elems);
                    break;
                case "START":
                    HandleSTART(statement, elems);
                    break;
                case "KILL":
                    HandleKILL(statement, elems);
                    break;
                case "KILLALL":
                    HandleKILLALL(statement, elems);
                    break;
                case "CLOSEALL":
                    HandleCLOSEALL(statement, elems);
                    break;
                case "MODOBJ":
                    HandleMODOBJ(statement, elems);
                    break;
                case "MOUSEOBJ":
                    HandleMOUSEOBJ(statement, elems);
                    break;
                case "WATCHOBJ":
                    HandleSTART(statement, elems);
                    break;
                case "CLICKOBJ":
                    HandleCLICKOBJ(statement, elems);
                    break;
                default:
                    throw new Exception("Unrecognized command: " + statement);
            }

            return unfinished;
        }

        void ExecuteStatementSeries(string statement_series)
        {
            string[] elems = statement_series.Split(';');

            string unfinished_statement = "";
            for (int i = 0; i < elems.Count(); ++i)
            {
                // If ExecuteStatement is able to finish processing statement, it returns empty string
                unfinished_statement = ExecuteStatement(unfinished_statement + elems[i]);
            }
        }

        private string ParseStatementBlock(string statement)
        {
            int startIndex = statement.IndexOf('{');
            if (startIndex == -1)
            {
                // Return unfinished statement for further processing
                return statement;
            }

            int endIndex = statement.IndexOf('}', startIndex);
            if (endIndex == -1)
            {
                // Return unfinished statement for further processing
                return statement;
            }

            // Get substring and remove curly braces and whitespace
            string statement_series = statement.Substring(startIndex, endIndex - startIndex);
            statement_series.TrimStart('{').TrimEnd('}').Trim();

            return statement_series;
        }
        
        string HandleDEFINE(string statement, string[] elems)
        {
            if (scaffoldFunctions.ContainsKey(elems[1]))
            {
                throw new Exception("Could not DEFINE function (already exists): " + statement);
            }

            string statement_block = ParseStatementBlock(statement);

            // If statement-length is unchanged, command is incomplete. Return for further append
            if (statement_block.Length == statement.Length)
                return statement;

            ExecuteStatementSeries(statement_block);

            // Empty string means statement was complete
            return "";
        }

        void HandleREGISTER(string statement, string[] elems)
        {
            try
            {
                ScaffoldFunction function = scaffoldFunctions[elems[1]];

                registeredFunctions[elems[1]] = function;
            }
            catch
            {
                throw new Exception("Could not register function (has it been DEFINEd?): " + statement);
            }
        }

        void HandleUNREGISTER(string statement, string[] elems)
        {
            if (elems[1] == "ALL")
            {
                registeredFunctions.Clear();
                return;
            }

            try
            {
                registeredFunctions.Remove(elems[1]);
            }
            catch
            {
                throw new Exception("Did not find registered function in: " + statement);
            }
        }

        void HandleSAVEFUNCLIST(string statement, string[] elems)
        {
            try
            {
                savedFunctionLists[elems[1]] = new Dictionary<string, ScaffoldFunction>(registeredFunctions);
            }
            catch
            {
                throw new Exception("Could not save function list (already saved?): " + statement);
            }
        }

        void HandleLOADFUNCLIST(string statement, string[] elems)
        {
            try
            {
                registeredFunctions = savedFunctionLists[elems[1]];
            }
            catch
            {
                throw new Exception("Could not load function list (was it saved?): " + statement);
            }
        }

        void HandleCALL(string statement, string[] elems)
        {
            try
            {
                ScaffoldFunction function = scaffoldFunctions[elems[1].TrimEnd(';')];

                ExecuteFunction(function);
            }
            catch
            {
                throw new Exception("Could not execute function in: " + statement);
            }
        }

        void HandleLOG(string statement, string[] elems)
        {
            if (elems[1].StartsWith("'") &&
                elems[1].EndsWith("'"))
            {
                logBuffer = elems[1].Trim('\'') + System.Environment.NewLine + logBuffer;
            }
            else
            {
                ScaffoldFunction function;
                try
                {
                    function = scaffoldFunctions[elems[1]];

                    logBuffer = ExecuteFunction(function) + System.Environment.NewLine + logBuffer;
                }
                catch
                {
                    throw new Exception("Could not execute function in: " + statement);
                }
            }
        }

        void HandleCLEARLOG(string statement, string[] elems)
        {
            logBuffer = "";
        }

        void HandleSLEEP(string statement, string[] elems)
        {
            try
            {
                Thread.Sleep(Int32.Parse(elems[1].TrimEnd(';')));
            }
            catch
            {
                throw new Exception("Could not parse integer field in: " + statement);
            }
        }

        void HandleIF(string statement, string[] elems)
        {
        }

        void HandleSTART(string statement, string[] elems)
        {

            //string statement_block = ParseStatementBlock(statement);

            //// If statement-length is unchanged, command is incomplete. Return for further append
            //if (statement_block.Length == statement.Length)
            //    return statement;

            //ExecuteStatementSeries(statement_block);

        }

        void HandleKILL(string statement, string[] elems)
        {

        }

        void HandleKILLALL(string statement, string[] elems)
        {

        }

        void HandleCLOSEALL(string statement, string[] elems)
        {

        }

        void HandleMODOBJ(string statement, string[] elems)
        {
            string[] obj_elems = elems[1].Split('.');

            if (obj_elems.Count() != 3)
                throw new Exception("Could not parse object identifier string in: " + statement);

            // Look up form (based on form name)
            Form form = scaffoldForms[obj_elems[0]];

            // Look up object from string
            System.Windows.Forms.Control item = form.Controls[obj_elems[1]];

            string[] value = { elems[2].Trim(';') };

            // Get point coordinates
            item.GetType().InvokeMember(obj_elems[2],
                                        System.Reflection.BindingFlags.SetProperty,
                                        null,
                                        item,
                                        value);
        }

        void HandleMOUSEOBJ(string statement, string[] elems)
        {
            string [] obj_elems = elems[1].Split('.');

            if (obj_elems.Count() != 2)
                throw new Exception("Could not parse object identifier string in: " + statement);

            // Look up form (based on form name)
            Form form = scaffoldForms[obj_elems[0]];

            // Look up object from string
            System.Windows.Forms.Control item = form.Controls[obj_elems[1]];

            Point destPoint = form.PointToScreen(item.Location);

            // Adjust position further within boundaries of control
            destPoint.X += 2;
            destPoint.Y += 2;

            // Starting point to plot mouse movement
            Point originPoint = GetMousePosition();

            // Plots a series of points from origin to destination
            Point [] points = PointsAlongLine(originPoint, destPoint, 7);

            for (int i = 0; i < points.Length; ++i)
            {
                MouseMove(points[i].X, points[i].Y);
                
                // This sleep is imprecise and just needs to be a subjectively acceptable approximation
                Thread.Sleep(20);
            }

            MouseMove(destPoint.X, destPoint.Y);
        }

        void HandleWATCHOBJ(string statement, string[] elems)
        {

        }

        void HandleCLICKOBJ(string statement, string[] elems)
        {
            string[] obj_elems = elems[1].Split('.');

            if (obj_elems.Count() != 2)
                throw new Exception("Could not parse object identifier string in: " + statement);

            // Look up form (based on form name)
            Form form = scaffoldForms[obj_elems[0]];

            // Look up object from string
            System.Windows.Forms.Control item = form.Controls[obj_elems[1]];

            Point destPoint = form.PointToScreen(item.Location);
            
            // Adjust position further within boundaries of control
            destPoint.X += 2;
            destPoint.Y += 2;

            MouseMove(destPoint.X, destPoint.Y);
            MouseClick(destPoint.X, destPoint.Y);
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        private const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        private const uint MOUSEEVENTF_CLICK = MOUSEEVENTF_LEFTDOWN |
                                               MOUSEEVENTF_LEFTUP |
                                               MOUSEEVENTF_ABSOLUTE;

        private static void MouseClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_CLICK, (uint)x, (uint)y, 0, 0);
        }

        private static void MouseMove(int x, int y)
        {
            SetCursorPos(x, y);
        }

        private static Point GetMousePosition()
        {
            Point point = new Point();
            GetCursorPos(ref point);
            return point;
        }

        private Point [] PointsAlongLine(Point start, Point end, double spacing)
        {
            int xDifference = end.X - start.X;
            int yDifference = end.Y - start.Y;
            int absoluteXdifference = Math.Abs(start.X - end.X);
            int absoluteYdifference = Math.Abs(start.Y - end.Y);

            double lineLength = Math.Sqrt((Math.Pow(absoluteXdifference, 2) + Math.Pow(absoluteYdifference, 2)));
            double steps = lineLength / spacing;
            int xStep = (int)(xDifference / steps);
            int yStep = (int)(yDifference / steps);

            Point [] result = new Point[(int)steps];

            for (int i = 0; i < (int)steps; ++i)
            {
                int x = start.X + (xStep * i);
                int y = start.Y + (yStep * i);
                result[i] = new Point(x, y);
            }

            return result;
        }
    }
}
