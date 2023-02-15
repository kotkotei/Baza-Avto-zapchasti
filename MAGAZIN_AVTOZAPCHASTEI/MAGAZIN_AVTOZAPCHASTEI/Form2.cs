using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAGAZIN_AVTOZAPCHASTEI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
       

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                try
                {
                    if (textBox1.Text.Trim() == "")
                    {
                        textBox1.Focus();
                        throw new Exception("Введите Вид");
                    }
                    else if (textBox2.Text.Trim().Length==0)
                    {
                        textBox2.Focus();
                        throw new Exception("Введите Наименование");
                    }
                    else if (textBox3.Text.Trim().Length == 0)
                    {
                        textBox2.Focus();
                        throw new Exception("Введите бренд");
                    }
                    else if (textBox3.Text.Trim().Length == 0)
                    {
                        textBox2.Focus();
                        throw new Exception("Введите Цену");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.Cancel = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                pictureBox1.Load(s);
                label5.Text = s;
            }
        }
    }
}
