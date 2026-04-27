using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

            if (textBox1.Text == "Type Your Task Here...")
                textBox1.Text = "";
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.TrimStart();


            if (textBox1.Text == "")
            {
                checkedListBox1.Focus();
                textBox1.Text = "Type Your Task Here...";
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() != "" && textBox1.Text != "Type Your Task Here...")
            {
                if (!dtTask.Checked)
                {
                    MessageBox.Show("Please enter the date of task");
                }
                else
                {
                    checkedListBox1.Items.Add(textBox1.Text.Trim()+"            "+dtTask.Text);
                    lblPendingTasks.Text = checkedListBox1.Items.Count.ToString();
                    textBox1.Text = "Type Your Task Here...";
                    dtTask.Checked = false;
                }
            }



        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    checkedListBox2.Items.Add(checkedListBox1.Items[i]);
                    notifyIcon1.Icon = SystemIcons.Information;
                    notifyIcon1.BalloonTipIcon= ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "Task Completed";
                    notifyIcon1.BalloonTipText = "Task : "+ checkedListBox1.Items[i].ToString()+" Completed";
                    notifyIcon1.ShowBalloonTip(1000);
                    checkedListBox2.SetItemChecked(checkedListBox2.Items.Count - 1, true);
                    checkedListBox1.Items.RemoveAt(i);
                    lblPendingTasks.Text = checkedListBox1.Items.Count.ToString();

                    i--;

                    lblCompletedTasks.Tag = (Convert.ToInt16(lblCompletedTasks.Tag) + 1).ToString();
                    lblCompletedTasks.Text = lblCompletedTasks.Tag.ToString();

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {

                checkedListBox1.SetItemChecked(i, true);

            }
            checkedListBox1_SelectedIndexChanged(checkedListBox1, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblPendingTasks.Text = "0";
            for (int i = checkedListBox1.Items.Count - 1; i >= 0; i--)
            {

                checkedListBox1.Items.RemoveAt(i);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetSelected(i))
                {
                    checkedListBox1.Items.RemoveAt(i);
                    lblPendingTasks.Text = checkedListBox1.Items.Count.ToString();
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtTask.MinDate = DateTime.Now;
            dtTask.Checked = false;
        }

        int ChangeColor = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ChangeColor==1)
            {
                label1.BackColor = Color.Red;
                label1.ForeColor = Color.DarkBlue;
            }
            if(ChangeColor==2)
            {
                label1.BackColor = Color.Black;
                label1.ForeColor = Color.Red;
            }
            if(ChangeColor==3)
            {
                label1.BackColor = Color.Brown;
                label1.ForeColor = Color.Purple;

            }
            if (ChangeColor==4)
            {
                label1.BackColor = Color.Blue;
                label1.ForeColor = Color.Pink;

            }
            if (ChangeColor==5)
            {
                label1.BackColor = Color.DarkSeaGreen;
                label1.ForeColor = Color.SkyBlue;

            }
            ChangeColor++;

            if (ChangeColor == 6)
            {
                ChangeColor = 1;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
           checkedListBox2.Items.Clear();
            lblCompletedTasks.Text = "0";
            lblCompletedTasks.Tag = "0";
        }
    }
}
