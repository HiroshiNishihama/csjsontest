using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsFormsApp1.BC;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private AppManage setting;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setting = new AppManage();
            textBoxHost.Text = setting.hostip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setting.hostip = textBoxHost.Text;
            setting.save();
        }
    }
}
