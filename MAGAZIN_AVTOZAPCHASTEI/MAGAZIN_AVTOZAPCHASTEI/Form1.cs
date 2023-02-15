using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.IO;


namespace MAGAZIN_AVTOZAPCHASTEI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            datUpdate();
          //  string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
          //  SqlConnection conn = new SqlConnection(str);
          //  conn.Open();
          //  string q = "select * from [dbo].[MAG_AVTO] order by [brend] Asc";
          //  /*SqlCommand com = new SqlCommand(q, conn);
          //SqlDataReader read = com.ExecuteReader();
          //while (read.Read())
          //{
          //dataGridView1.RowCount += 1;
          //dataGridView1[0, dataGridView1.RowCount - 1].Value = read.GetValue(0);
          //dataGridView1[1, dataGridView1.RowCount - 1].Value = read.GetValue(1);
          //dataGridView1[2, dataGridView1.RowCount - 1].Value = read.GetValue(2);
          //dataGridView1[3, dataGridView1.RowCount - 1].Value = read.GetValue(3);
          //dataGridView1[4, dataGridView1.RowCount - 1].Value = read.GetValue(4);

            //}*/

            //  SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            //  DataSet ds = new DataSet();
            //  adapter.Fill(ds);
            //  dataGridView2.DataSource = ds.Tables[0];
            //  conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string p = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = 0;

            string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string q = "select * from [dbo].[MAG_AVTO] order by [" + p + "] Asc";
            SqlCommand com = new SqlCommand(q, conn);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                dataGridView1.RowCount += 1;
                dataGridView1[0, dataGridView1.RowCount - 1].Value = read.GetValue(0);
                dataGridView1[1, dataGridView1.RowCount - 1].Value = read.GetValue(1);
                dataGridView1[2, dataGridView1.RowCount - 1].Value = read.GetValue(2);
                dataGridView1[3, dataGridView1.RowCount - 1].Value = read.GetValue(3);
                dataGridView1[4, dataGridView1.RowCount - 1].Value = read.GetValue(4);

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pois = textBox1.Text.Trim();
            string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string q = "select * from [dbo].[MAG_AVTO] where [brend ] like '%" + pois + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            conn.Close();
           
        }
        public void datUpdate()
        {
            string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string q = "select * from[dbo].[MAG_AVTO]";
            SqlDataAdapter adapter = new SqlDataAdapter(q, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            conn.Close();
            dataGridView2.Columns[0].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = dataGridView2.SelectedRows[0].Index;//ноиер текущей строки 
            int id = Convert.ToInt32(dataGridView2[0, n].Value);
            string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string q = "DELETE FROM [dbo].[MAG_AVTO]   WHERE id=" + id;
            SqlCommand com = new SqlCommand(q, conn);

            com.ExecuteNonQuery();
            conn.Close();
            datUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string patch = f.label5.Text ;
                FileInfo fileInfo = new FileInfo(patch);
                string newPath = Directory.GetCurrentDirectory()+ "\\phota\\"+fileInfo.Name;
                fileInfo.CopyTo(newPath, true);
             

                
                    string vid = f.textBox1.Text.Trim();
                    string name_tover = f.textBox2.Text.Trim();
                    string brend = f.textBox3.Text.Trim();
                    string price = f.numericUpDown1.Value.ToString();
                
               

                string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string q = "INSERT INTO [dbo].[MAG_AVTO]([Vid],[tovar_name],[brend],[price],[photo])VALUES('"+vid+"', '"+name_tover+"', '"+brend+"', "+price+", '"+ fileInfo.Name + "')";
                SqlCommand com = new SqlCommand(q, conn);
                com.ExecuteNonQuery();
                conn.Close();
                datUpdate();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int n = dataGridView2.SelectedRows[0].Index;//ноиер текущей строки 
            int id = Convert.ToInt32(dataGridView2[0, n].Value);
              
            string str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string q = "SELECT * FROM[dbo].[MAG_AVTO] where id ="+id;
            SqlCommand com = new SqlCommand(q, conn);
            SqlDataReader read = com.ExecuteReader();
            Form2 f = new Form2();
            while (read.Read())
            {
                f.textBox1.Text = read.GetValue(1).ToString();
                f.textBox2.Text = read.GetValue(2).ToString();
                f.textBox3.Text = read.GetValue(3).ToString();
                f.numericUpDown1.Value = Convert.ToInt32(read.GetValue(4));
                f.pictureBox1.Load(Directory.GetCurrentDirectory() + "\\phota\\" + read.GetValue(5));
                f.label5.Text = Directory.GetCurrentDirectory() + "\\phota\\" + read.GetValue(5);


                /*dataGridView1.RowCount += 1;
                dataGridView1[0, dataGridView1.RowCount - 1].Value = read.GetValue(0);
                dataGridView1[1, dataGridView1.RowCount - 1].Value = read.GetValue(1);
                dataGridView1[2, dataGridView1.RowCount - 1].Value = read.GetValue(2);
                dataGridView1[3, dataGridView1.RowCount - 1].Value = read.GetValue(3);
                dataGridView1[4, dataGridView1.RowCount - 1].Value = read.GetValue(4);
                */
            }
            conn.Close();
            if(f.ShowDialog()== DialogResult.OK)

            {
                string vid = f.textBox1.Text.Trim();
                string name_tover = f.textBox2.Text.Trim();
                string brend = f.textBox3.Text.Trim();
                string price = f.numericUpDown1.Value.ToString();

                str = "Data Source=DESKTOP-P82H1D3\\SQLEXPRESS;Initial Catalog=MAGAZIN_AVTOZAPCHASTEI;Integrated Security=True; TrustServerCertificate=True";
                 conn = new SqlConnection(str);

                string patch = f.label5.Text;
                FileInfo fileInfo = new FileInfo(patch);
                string newPath = Directory.GetCurrentDirectory() + "\\phota\\" + fileInfo.Name;
                fileInfo.CopyTo(newPath, true);       
                conn.Open();
                 q = "UPDATE [dbo].[MAG_AVTO]SET[Vid] = '"+vid+"',[tovar_name] = '"+name_tover+"',[brend] = '"+brend+"',[price] = '"+price+"',[photo] = '"+ fileInfo.Name + " 'WHERE id = "+id;
                 com = new SqlCommand(q, conn);
                com.ExecuteNonQuery();
                conn.Close();
                datUpdate();
            }
        }


    }
}

