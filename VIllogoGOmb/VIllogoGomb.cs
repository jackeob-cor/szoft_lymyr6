using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIllogoGOmb
{
    internal class VIllogoGomb : Button
    {
        public VIllogoGomb()
        {
            MouseEnter += VIllogoGomb_MouseEnter;
            MouseLeave += VIllogoGomb_MouseLeave;
        }

        private void VIllogoGomb_MouseLeave(object? sender, EventArgs e)
        {
            
            BackColor = SystemColors.ButtonFace;
            MouseEnter -= VIllogoGomb_MouseEnter;
        }

        private void VIllogoGomb_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.Fuchsia;
        }
    }
}
