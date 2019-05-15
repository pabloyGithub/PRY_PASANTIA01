using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGIC;
using LOGIC.Complementos;

namespace PRY_PASANTIA01
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tex = textBox1.Text;

            string encriptado = encriptMD5.encriptarMD5(tex);

            textBox2.Text = encriptado.ToString();
        }
    }
}
