using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool flag = false;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (flag == false)
            {
                human h = new human();
                h.Name = textBox1.Text;
                h.Family = textBox2.Text;
                h.Age = Byte.Parse(textBox3.Text);
                h.National_id = textBox4.Text;
                h.register(h);
                foreach (var VARIABLE in Controls)
                {
                    if (VARIABLE.GetType().ToString()== "System.Windows.Forms.TextBox")
                    {
                        (VARIABLE as TextBox).Clear();
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = h.readall();

            }
            else
            {
                human h = new human();
                h.Name = textBox1.Text;
                h.Family = textBox2.Text;
                h.Age = Byte.Parse(textBox3.Text);
                h.National_id = textBox4.Text;
                h.update(id, h);
                foreach (var VARIABLE in Controls)
                {
                    if (VARIABLE.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        (VARIABLE as TextBox).Clear();
                    }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = h.readall();

                flag = false;
                buttonX1.Text = "Register";

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            human h = new human();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = h.readall();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            human h = new human();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = h.search(textBoxX1.Text.ToString());
            
        }

        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            //MessageBox.Show(id.ToString());
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonX1.Text = "Update";
            flag = true;
            Db db1 = new Db();
            var q = from i in db1.humen where i.id == id select i;
            if (q.Count() == 1)
            {
                human h = new human();
                h = q.Single();
                textBox1.Text = h.Name;
                textBox2.Text = h.Family;
                textBox3.Text = h.Age.ToString();
                textBox4.Text = h.National_id;

            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            human h = new human();
            h.delete(id);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = h.readall();

        }
    }
}
