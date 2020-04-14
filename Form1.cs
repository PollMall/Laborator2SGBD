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
using System.Configuration;

namespace Lab1SGBD
{
    public partial class Form1 : Form
    {
        SqlConnection connection = null;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet set1 = new DataSet();
        DataSet set2 = new DataSet();

        String childTableName;
        String[] childColumnNames;
        String[] childColumnValues;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adapter.SelectCommand = new SqlCommand("select * from Seriale",connection);
            //set1.Clear();
            //adapter.Fill(set1);
            //gridViewParent.DataSource = set1.Tables[0];
            String selectCmd = ConfigurationManager.AppSettings["selectParent"];
            adapter.SelectCommand = new SqlCommand(selectCmd,connection);
            set1.Clear();
            adapter.Fill(set1);
            gridViewParent.DataSource = set1.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var selected = gridViewParent.SelectedRows[0];
            //if(selected!=null)
            //{
            //    adapter.SelectCommand = new SqlCommand("select * from Sezoane where id_serial=@id",connection);
            //    adapter.SelectCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value=selected.Cells[0].Value;
            //    set2.Clear();
            //    adapter.Fill(set2);
            //    gridViewChild.DataSource = set2.Tables[0];
            //}

            var selected = gridViewParent.SelectedRows[0];
            if (selected != null)
            {
                childTableName = ConfigurationManager.AppSettings["childTableName"];
                childColumnNames = ConfigurationManager.AppSettings["childColumnNames"].Split(',');
                String fk = childColumnNames[childColumnNames.Length - 1];
                adapter.SelectCommand = new SqlCommand("select * from " + childTableName + " where " + fk + "=@id", connection);
                //adapter.SelectCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = selected.Cells[0].Value;
                adapter.SelectCommand.Parameters.AddWithValue("@id", selected.Cells[0].Value);
                set2.Clear();
                adapter.Fill(set2);
                gridViewChild.DataSource = set2.Tables[0];
                int last = 10;
                for(int i=1;i<childColumnNames.Length-1;i++)
                {
                    TextBox textBox = new TextBox();
                    textBox.Text = childColumnNames[i];
                    textBox.Name = childColumnNames[i];
                    textBox.Left = 30;
                    textBox.Top = last+10;
                    last = textBox.Bottom;
                    panelChild.Controls.Add(textBox);
                }
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
                if (gridViewChild.DataSource != null)
                {
                    var selected = gridViewChild.SelectedRows[0];

                    if (selected != null)
                    {
                        //            adapter.DeleteCommand = new SqlCommand("delete from Sezoane where id_sezon=@id", connection);
                        //            adapter.DeleteCommand.Parameters.AddWithValue("@id", SqlDbType.Int).Value = selected.Cells[0].Value;
                        //            connection.Open();
                        //            adapter.DeleteCommand.ExecuteNonQuery();
                        //            connection.Close();
                        //            MessageBox.Show("S-a sters!");
                        //            afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);
                        String pkText = childColumnNames[0] + "=@" + childColumnNames[0];

                        adapter.DeleteCommand = new SqlCommand("delete from " + childTableName + " where " +pkText,connection);
                        adapter.DeleteCommand.Parameters.AddWithValue("@" + childColumnNames[0], selected.Cells[0].Value);

                        connection.Open();
                        adapter.DeleteCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("S-a sters!");
                        afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);
                    }
                    else
                    {
                        MessageBox.Show("Trebuie sa selectati o inregistrare");
                    }
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista!");
                }
            }
            catch(Exception ex)
            {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }

        private void afis_dataGridView2(int pk)
        {
            //adapter.SelectCommand = new SqlCommand("select * from Sezoane where id_serial=@id_serial", connection);
            //adapter.SelectCommand.Parameters.AddWithValue("@id_serial", SqlDbType.Int).Value = id_serial;
            //set2.Clear();
            //adapter.Fill(set2);
            //gridViewChild.DataSource = set2.Tables[0];

            adapter.SelectCommand = new SqlCommand("select * from "+childTableName+" where "+childColumnNames[childColumnNames.Length-1]+"=@"+ childColumnNames[childColumnNames.Length-1], connection);
            adapter.SelectCommand.Parameters.AddWithValue("@"+ childColumnNames[childColumnNames.Length - 1], pk);
            set2.Clear();
            adapter.Fill(set2);
            gridViewChild.DataSource = set2.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewChild.DataSource != null)
                {
                    for (int i = 1; i < childColumnNames.Length - 1; i++)
                    {
                        if (panelChild.Controls[childColumnNames[i]].Text == "")
                        {
                            MessageBox.Show("Trebuie sa completati toate campurile!");
                            return;
                        }
                    }
                    //        else
                    //        {

                    //            var selected = gridViewChild.SelectedRows[0];
                    //            if (selected != null)
                    //            {
                    //                adapter.UpdateCommand = new SqlCommand("update Sezoane set nume=@nume,nr_sezon=@nr_sezon,nr_episoade=@nr_episoade,descriere=@descriere where id_sezon=@id_sezon", connection);
                    //                adapter.UpdateCommand.Parameters.AddWithValue("@nume", SqlDbType.VarChar).Value = numeSezonTxtBox.Text;
                    //                adapter.UpdateCommand.Parameters.AddWithValue("@nr_sezon", SqlDbType.Int).Value = Int32.Parse(nrSezonTxtBox.Text);
                    //                adapter.UpdateCommand.Parameters.AddWithValue("@nr_episoade", SqlDbType.Int).Value = Int32.Parse(nrEpisoadeSezonTxtBox.Text);
                    //                adapter.UpdateCommand.Parameters.AddWithValue("@descriere", SqlDbType.VarChar).Value = descriereSezonTxtBox.Text;
                    //                adapter.UpdateCommand.Parameters.AddWithValue("@id_sezon", SqlDbType.Int).Value = selected.Cells[0].Value;
                    //                connection.Open();
                    //                adapter.UpdateCommand.ExecuteNonQuery();
                    //                connection.Close();
                    //                MessageBox.Show("S-a facut update!");
                    //                afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);
                    //            }
                    //            else
                    //            {
                    //                MessageBox.Show("Trebuie sa selectati un sezon");
                    //            }
                    //        }

                    var selected = gridViewChild.SelectedRows[0];
                    if (selected != null)
                    {
                        String cols = "";
                        for(int i = 1; i < childColumnNames.Length - 2; i++)
                        {
                            cols += childColumnNames[i] + "=@" + childColumnNames[i]+",";
                        }
                        cols += childColumnNames[childColumnNames.Length-2] + "=@" + childColumnNames[childColumnNames.Length - 2];
                        String pkText = childColumnNames[0] + "=@" + childColumnNames[0];
                        adapter.UpdateCommand = new SqlCommand("update "+childTableName+" set "+cols+" where "+pkText, connection);

                        for (int i = 1; i < childColumnNames.Length-1; i++)
                        {
                            adapter.UpdateCommand.Parameters.AddWithValue("@"+childColumnNames[i], panelChild.Controls[childColumnNames[i]].Text);
                        }
                        adapter.UpdateCommand.Parameters.AddWithValue("@"+childColumnNames[0], selected.Cells[0].Value);

                        connection.Open();
                        adapter.UpdateCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("S-a facut update!");
                        afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);
                    }
                    else
                    {
                        MessageBox.Show("Trebuie sa selectati o inregistrare");
                    }
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista!");
                }
            }
            catch (Exception ex)
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
            var selected = gridViewChild.SelectedRows[0];
            if (selected != null)
            {
                //    numeSezonTxtBox.Text = selected.Cells[1].Value.ToString();
                //    nrSezonTxtBox.Text = selected.Cells[2].Value.ToString();
                //    nrEpisoadeSezonTxtBox.Text = selected.Cells[3].Value.ToString();
                //    descriereSezonTxtBox.Text = selected.Cells[4].Value.ToString();

                for(int i = 1; i < selected.Cells.Count - 1; i++)
                {
                    panelChild.Controls[childColumnNames[i]].Text = selected.Cells[i].Value.ToString();
                }
            }
    }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewChild.DataSource != null)
                {
                    for (int i = 1; i < childColumnNames.Length - 1; i++)
                    {
                        if(panelChild.Controls[childColumnNames[i]].Text=="")
                        {
                            MessageBox.Show("Trebuie sa completati toate campurile!");
                            return;
                        }
                    }
                    //else
                    //{
                    //            adapter.InsertCommand = new SqlCommand("insert into Sezoane(nume,nr_sezon,nr_episoade,descriere,id_serial) values (@nume,@nr_sezon,@nr_episoade,@descriere,@id_serial)", connection);
                    //            adapter.InsertCommand.Parameters.AddWithValue("@nume", SqlDbType.VarChar).Value = numeSezonTxtBox.Text;
                    //            adapter.InsertCommand.Parameters.AddWithValue("@nr_sezon", SqlDbType.Int).Value = Int32.Parse(nrSezonTxtBox.Text);
                    //            adapter.InsertCommand.Parameters.AddWithValue("@nr_episoade", SqlDbType.Int).Value = Int32.Parse(nrEpisoadeSezonTxtBox.Text);
                    //            adapter.InsertCommand.Parameters.AddWithValue("@descriere", SqlDbType.VarChar).Value = descriereSezonTxtBox.Text;
                    //            adapter.InsertCommand.Parameters.AddWithValue("@id_serial", SqlDbType.Int).Value = gridViewParent.SelectedRows[0].Cells[0].Value;
                    //            connection.Open();
                    //            adapter.InsertCommand.ExecuteNonQuery();
                    //            connection.Close();
                    //            MessageBox.Show("S-a inserat sezonul!");
                    //            afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);

                    String columnText = ConfigurationManager.AppSettings["childColumnValues"];
                    childColumnValues = columnText.Split(',');
                    String cols = "";
                    for(int i = 0; i < childColumnValues.Length-1; i++)
                    {
                        cols += childColumnValues[i].Split('@')[1] + ",";
                    }
                    cols += childColumnValues[childColumnValues.Length-1].Split('@')[1];

                    adapter.InsertCommand = new SqlCommand("insert into " + childTableName + "("+ cols +") values ("+ columnText +")",connection);
                    for(int i = 0; i < childColumnValues.Length-1; i++)
                    {
                        adapter.InsertCommand.Parameters.AddWithValue(childColumnValues[i], panelChild.Controls[childColumnValues[i].Split('@')[1]].Text);
                    }
                    adapter.InsertCommand.Parameters.AddWithValue(childColumnValues[childColumnValues.Length - 1], gridViewParent.SelectedRows[0].Cells[0].Value);

                    connection.Open();
                    adapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("S-a inserat!");
                    afis_dataGridView2((int)gridViewParent.SelectedRows[0].Cells[0].Value);
                    //}
                }
                else
                {
                    MessageBox.Show("Nu aveti nicio lista!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            connection = new SqlConnection(connectionString);
            if (connection != null)
            {
                showParent.Visible = true;
                gridViewChild.Visible = true;
                panelChild.Visible = true;
                deleteChild.Visible = true;
                updateChild.Visible = true;
                addChild.Visible = true;
                labelChild.Visible = true;
                labelParent.Visible = true;
                connectBtn.Visible = false;
                labelParent.Text = ConfigurationManager.AppSettings["parentTableName"];
                labelChild.Text = ConfigurationManager.AppSettings["childTableName"];
            }
        }
    }
}
