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
        public enum Lists { Work, Personal, School }
        public class TaskItem
        {
            public string Task { get; set; }
            public DateTime Date { get; set; }
            public Lists lst;
            public override string ToString()
            {
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
            else
                MessageBox.Show("Task is empty or invalid!");
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
                allTasks.Remove(selectedTask);
                RefreshTaskList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var item in allTasks)
            {
                listBox1.Items.Add(item);
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshTaskList();
        }

        private void workToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaskItem selectedtask = (TaskItem)listBox1.SelectedItem;
            string list = sender.ToString();
            selectedtask.Task = $"{list} : {selectedtask.Task}";
            RefreshTaskList();
        }

        private void timerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerFrm frm = new TimerFrm();
            frm.Show();
        }
    }
}
