using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            c.Start(5);
            c.RaiseCustomEvent += C_RaiseCustomEvent;
        }

        private void C_RaiseCustomEvent(object sender, CustomEventArgs e)
        {
            MessageBox.Show(e.Message,"", MessageBoxButtons.OK);
        }
    }
}
