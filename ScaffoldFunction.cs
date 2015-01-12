using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScaffoldScript
{
    class ScaffoldFunction
    {
        public string name = "";
        public Form activeForm = null;

        public virtual void ExecuteFunction()
        {
        }    
    }
}
