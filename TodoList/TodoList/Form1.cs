using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            TextBox txtbox = new TextBox();
            this.Controls.Add(txtbox);
            txtbox.Multiline = true;
            txtbox.Width = 380;
            txtbox.Name = "txtbox1";
           txtbox.Location = new Point(12, 303);
            
        }
    }
}
