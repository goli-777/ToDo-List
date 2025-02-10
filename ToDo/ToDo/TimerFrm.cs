using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDo
{
    public partial class TimerFrm : Form
    {
         public int hour = 0, minute = 0, second = 60;
        public TimerFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                int time = int.Parse(textBox1.Text);
                minute = (time - 1);
                timer1.Enabled = true;
            }
            else
                MessageBox.Show("You can't leave the time empty!");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
              second--;
              if (second == 0)
              {
                  second = 59;
                  minute--;
              }
              if (minute == 0)
              {
                  minute = 60;
                  hour--;
              }

            lblSecond.Text = second.ToString();
            lblMinute.Text = minute.ToString();
            lblHour.Text = hour.ToString();
        }
    }
}
