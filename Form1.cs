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
          
            if(textBox1.Text== "Type Your Task Here...")
            textBox1.Text = "";
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text= textBox1.Text.TrimStart();


            if (textBox1.Text =="")
            {
                checkedListBox1.Focus();
                textBox1.Text = "Type Your Task Here...";
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text.Trim()!="" && textBox1.Text!= "Type Your Task Here...")
            {
                checkedListBox1.Items.Add(textBox1.Text.Trim());
                textBox1.Text = "Type Your Task Here...";
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    checkedListBox2.Items.Add(checkedListBox1.Items[i]);
                    checkedListBox2.SetItemChecked(checkedListBox2.Items.Count - 1, true);
                    checkedListBox1.Items.RemoveAt(i);
                    i--;

                    lblCompletedTasks.Tag = (Convert.ToInt16(lblCompletedTasks.Tag) + 1).ToString();
                    lblCompletedTasks.Text=lblCompletedTasks.Tag.ToString();

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
            for (int i = checkedListBox1.Items.Count-1; i >=0; i--)
            {

                checkedListBox1.Items.RemoveAt(i);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i=0;i<checkedListBox1.Items.Count;i++)
            {
                if (checkedListBox1.GetSelected(i))
                {
                    checkedListBox1.Items.RemoveAt(i);
                }
            }
        }
    }
}
