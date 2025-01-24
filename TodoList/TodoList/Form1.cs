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
        public int count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
        private void AddTaskBtn_Click(object sender, EventArgs e)
        {
            count++;
            int y = 200 + (count * 50);
            if (count > 0)
            {
                TextBox txtbox = new TextBox();
                this.Controls.Add(txtbox);
                txtbox.Multiline = true;
                txtbox.Width = 260;
                txtbox.Name = "txtbox"+count;
                txtbox.Location = new Point(8,y);
            }
        }

       
    }
}
