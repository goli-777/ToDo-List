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
               // return $"{Date.ToShortDateString()}: {Task}";
                return Task;

            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<TaskItem> allTasks = new List<TaskItem>();
        private void RefreshTaskList()
        {
            listBox1.Items.Clear();
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;
            var tasksForDate = allTasks.Where(task => task.Date == selectedDate);
            foreach (var task in tasksForDate)
            {
                listBox1.Items.Add(task);
            }
        }

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
                RefreshTaskList();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedItem is TaskItem selectedTask)
            {
                textBox1.Text = selectedTask.Task;
                monthCalendar1.SetDate(selectedTask.Date);
                allTasks.Remove(selectedTask);
                RefreshTaskList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is TaskItem selectedTask)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
                RefreshTaskList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DateTime selectedDate = monthCalendar1.SelectionStart;
            foreach (var item in allTasks)
            {
                if (item.Date == selectedDate)
                {
                    listBox1.Items.Add(item);
                }
            }
        }



 

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshTaskList();
        }
    }
}
