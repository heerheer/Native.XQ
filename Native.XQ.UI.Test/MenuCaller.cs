using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.XQ.SDK.Event.EventArgs;
using Native.XQ.SDK.Interfaces;

namespace Native.XQ.UI.Test
{
    public class MenuCaller : IXQCallMenu
    {
        public static Form1 form;
        [STAThread]
        public void CallMenu(object sender, XQEventArgs e)
        {
            if (form == null)
            {
                form = new Form1();
                form.Show();
                form.FormClosed += Form_FormClosed;
            }
            else
            {
                form.Activate();
            }
            
        }

        private void Form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            form = null;
        }
    }
}
