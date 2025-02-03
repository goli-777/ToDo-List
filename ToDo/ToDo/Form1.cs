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
    public partial class Form1 : Form
    {
        public class TaskItem
        {
            public string Task { get; set; }
            public DateTime Date { get; set; }
            public override string ToString()
            {
                return $"{Date.ToShortDateString()}: {Task}";
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<TaskItem> allTasks = new List<TaskItem>();

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(text))
            {
                DateTime date = monthCalendar1.SelectionStart;
                TaskItem taskItem = new TaskItem { Task = text, Date = date };
                allTasks.Add(taskItem);
                listBox1.Items.Add(taskItem);
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem != null)
            {
                string SelectedTask = listBox1.SelectedItem.ToString();
                string[] trim = SelectedTask.Split(':');
                if (trim.Length > 1)
                {
                    string text = trim[0].ToString();
                    string date = trim[1].ToString();
                    textBox1.Text = text;
                    monthCalendar1.SetDate(DateTime.Parse(date));
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show("task deleted successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DateTime selectedDate = monthCalendar1.SelectionStart;
            foreach (var item in allTasks)
            {
                if (item.Date == selectedDate)
                    listBox1.Items.Add(item);
            }
        }
    }
}
