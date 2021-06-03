using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Hospital.ViewModel.Patient
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    class JavaScriptControlTemplate
    {
        Window prozor;
        public JavaScriptControlTemplate(Window w)
        {
            prozor = w;
        }

        /*public void RunFromJavascript(string param)
        {
            prozor.doThings(param);
        }*/
    }
}
