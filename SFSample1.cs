using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScaffoldScript
{
    class SFSample1 : ScaffoldFunction
    {
        public SFSample1(string function_name)
        {
            name = function_name;
        }

        public override void ExecuteFunction()
        {
            activeForm = new Sample1();
            activeForm.ShowDialog();
        }
    }
}
