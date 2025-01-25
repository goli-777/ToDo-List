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
        CheckBox checkbox = new CheckBox();
        TextBox txtbox = new TextBox();


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
                this.Controls.Add(checkbox);
                this.Controls.Add(txtbox);
                checkbox.Text = "";
                txtbox.Width = 240;
                checkbox.Width = 17;
                txtbox.Name = "textbox" + count;
                checkbox.Name = "checkbox"+count;
                txtbox.Location = new Point(17,y);
                checkbox.Location = new Point(0, y);
                
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bool line = txtbox.Font.Strikeout;
            line = !line;
        }

        private void checkBox_Click(object sender, EventArgs e)
        {     
        }
    }
}
