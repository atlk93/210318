using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public string str;
        public Form2()
        {
            InitializeComponent();
            str = "테스트 문자열";
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
