using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab1SGBD
{
    public partial class Form1 : Form
    {
        public SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IF3JUU7;Initial Catalog=Netflix2;Integrated Security=True");
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet set1 = new DataSet();
        DataSet set2 = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.SelectCommand = new SqlCommand("select * from Seriale",connection);
            set1.Clear();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.InsertCommand = new SqlCommand("insert into Seriale(nume,categorie_varsta,nr_sezoane) values (@n,@c,@nr)", connection);
                adapter.InsertCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = textBox1.Text;
                adapter.InsertCommand.Parameters.Add("@c", SqlDbType.Int).Value = Int32.Parse(textBox2.Text);
                adapter.InsertCommand.Parameters.Add("@nr", SqlDbType.Int).Value = Int32.Parse(textBox3.Text);
                connection.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("S-a adaugat!");
                button1_Click(sender,e);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selected = dataGridView1.SelectedRows[0];
            if(selected!=null)
            {
                adapter.SelectCommand = new SqlCommand("select * from Sezoane where id_serial=@id",connection);
                adapter.SelectCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value=selected.Cells[0].Value;
                set2.Clear();
                adapter.Fill(set2);
                dataGridView2.DataSource = set2.Tables[0];
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource != null)
                {
                    var selected = dataGridView2.SelectedRows[0];

                    if (selected != null)
                    {
                        adapter.DeleteCommand = new SqlCommand("delete from Sezoane where id_sezon=@id", connection);
                        adapter.DeleteCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = selected.Cells[0].Value;
                        connection.Open();
                        adapter.DeleteCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("S-a sters!");
                        afis_dataGridView2((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                    }
                    else
                    {
                        MessageBox.Show("Trebuie sa selectati un sezon");
                    }
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista cu sezoanele!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void afis_dataGridView2(int id_serial)
        {
            adapter.SelectCommand = new SqlCommand("select * from Sezoane where id_serial=@id_serial", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id_serial", SqlDbType.Int).Value = id_serial;
            set2.Clear();
            adapter.Fill(set2);
            dataGridView2.DataSource = set2.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource != null)
                {
                    if (numeSezonTxtBox.TextLength == 0 || nrSezonTxtBox.TextLength == 0 || nrEpisoadeSezonTxtBox.TextLength == 0 || descriereSezonTxtBox.TextLength == 0)
                    {
                        MessageBox.Show("Trebuie sa completati toate campurile!");
                    }
                    else
                    {

                        var selected = dataGridView2.SelectedRows[0];
                        if (selected != null)
                        {
                            adapter.UpdateCommand = new SqlCommand("update Sezoane set nume=@nume,nr_sezon=@nr_sezon,nr_episoade=@nr_episoade,descriere=@descriere where id_sezon=@id_sezon", connection);
                            adapter.UpdateCommand.Parameters.AddWithValue("@nume", SqlDbType.VarChar).Value = numeSezonTxtBox.Text;
                            adapter.UpdateCommand.Parameters.AddWithValue("@nr_sezon", SqlDbType.Int).Value = Int32.Parse(nrSezonTxtBox.Text);
                            adapter.UpdateCommand.Parameters.AddWithValue("@nr_episoade", SqlDbType.Int).Value = Int32.Parse(nrEpisoadeSezonTxtBox.Text);
                            adapter.UpdateCommand.Parameters.AddWithValue("@descriere", SqlDbType.VarChar).Value = descriereSezonTxtBox.Text;
                            adapter.UpdateCommand.Parameters.AddWithValue("@id_sezon", SqlDbType.Int).Value = selected.Cells[0].Value;
                            connection.Open();
                            adapter.UpdateCommand.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show("S-a facut update!");
                            afis_dataGridView2((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                        }
                        else
                        {
                            MessageBox.Show("Trebuie sa selectati un sezon");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista cu sezoanele!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void descriereSezonRichTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var selected = dataGridView2.SelectedRows[0];
            if (selected != null)
            {
                numeSezonTxtBox.Text = selected.Cells[1].Value.ToString();
                nrSezonTxtBox.Text = selected.Cells[2].Value.ToString();
                nrEpisoadeSezonTxtBox.Text = selected.Cells[3].Value.ToString();
                descriereSezonTxtBox.Text = selected.Cells[4].Value.ToString();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.DataSource != null)
                {
                    if (numeSezonTxtBox.TextLength == 0 || nrSezonTxtBox.TextLength == 0 || nrEpisoadeSezonTxtBox.TextLength == 0 || descriereSezonTxtBox.TextLength == 0)
                    {
                        MessageBox.Show("Trebuie sa completati toate campurile!");
                    }
                    else
                    {
                        adapter.InsertCommand = new SqlCommand("insert into Sezoane(nume,nr_sezon,nr_episoade,descriere,id_serial) values (@nume,@nr_sezon,@nr_episoade,@descriere,@id_serial)", connection);
                        adapter.InsertCommand.Parameters.AddWithValue("@nume", SqlDbType.VarChar).Value = numeSezonTxtBox.Text;
                        adapter.InsertCommand.Parameters.AddWithValue("@nr_sezon", SqlDbType.Int).Value = Int32.Parse(nrSezonTxtBox.Text);
                        adapter.InsertCommand.Parameters.AddWithValue("@nr_episoade", SqlDbType.Int).Value = Int32.Parse(nrEpisoadeSezonTxtBox.Text);
                        adapter.InsertCommand.Parameters.AddWithValue("@descriere", SqlDbType.VarChar).Value = descriereSezonTxtBox.Text;
                        adapter.InsertCommand.Parameters.AddWithValue("@id_serial", SqlDbType.Int).Value = dataGridView1.SelectedRows[0].Cells[0].Value;
                        connection.Open();
                        adapter.InsertCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("S-a inserat sezonul!");
                        afis_dataGridView2((int)dataGridView1.SelectedRows[0].Cells[0].Value);
                    }
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista cu sezoanele!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }
    }
}
