using System;
using System.Windows.Forms;
namespace Professional_Register_form
{
    public partial class Form1 : Form
    {
        #region Essentials
        int id;
        bool b = false;
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Button1 ==> Register
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter your Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please Enter your Last Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please Enter your Age", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (b == false)
                {
                    db db1 = new db();
                    person p = new person();
                    p.register(new person { name = textBox1.Text, fname = textBox2.Text, age = Convert.ToByte(textBox3.Text) });
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = p.readall();
                }
                else
                {
                    person p = new person();
                    p.name = textBox1.Text;
                    p.fname = textBox2.Text;
                    p.age = Convert.ToByte(textBox3.Text);
                    p.update(id, p);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = p.readall();
                    button1.Text = "Register";
                    b = false;
                }
            }
        }
        #endregion

        #region Button2 ==> Search
        private void button2_Click(object sender, EventArgs e)
        {
            db db1 = new db();
            person p = new person();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = p.search(textBox4.Text);
        }
        #endregion

        #region DataGridView ==> Right Click
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                id = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }
        #endregion

        #region Tool Strip Menu ==> ویرایش
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            b = true;
            person p = new person();
            p = p.searchbyid(id);
            textBox1.Text = p.name;
            textBox2.Text = p.fname;
            textBox3.Text = p.age.ToString();
            button1.Text = "Edit";
        }
        #endregion

        #region Tool Strip Menu ==> حذف
        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            person p = new person();
            p = p.searchbyid(id);
            p.delete(id);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = p.readall();
        }
        #endregion
    }
}