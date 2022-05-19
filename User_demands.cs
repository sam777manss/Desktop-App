using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Collections;
// Calculator is a dll file
using Calculator;

namespace HelloWorld
{
    public partial class User_demands : Form
    {
        public User_demands()
        {
            InitializeComponent();
            ShowAll();
        }

        private void User_demands_Load(object sender, EventArgs e)
        {

        }

        void ShowAll()
        {

            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                // select  start        ('" + ulogin + "')";
                string sql = "SELECT * FROM public.update";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();
                reader.Close();
                // Define a query
                // Execute the query and obtain a result set
                NpgsqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows || dr.HasRows == false)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                con.Dispose();
                con.Close();
            }

        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginRecord();
        }

        public void LoginRecord()
        {

            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                //Console.Clear();
                // select  start        ('" + ulogin + "')";
                string email = textBox1.Text;
                string sql = "SELECT * FROM public.update where email=('" + email + "')";

                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                string val;
                string[] info = new string[3];
                NpgsqlDataReader reader = command.ExecuteReader();
                int z = 0;
                while (reader.Read())
                {
                    
                    for (int x = 0; x <= 2; x++)
                    {

                        info[x] += reader[x].ToString();
                        //MessageBox.Show(reader[x].ToString());
                        z += 1;
                    }
                    if(z ==3)
                    {
                        break;
                    }
                    //Console.WriteLine(info[0]);
                    //Console.WriteLine(info[1]);
                    //do whatever you like
                }
                //MessageBox.Show(info[1]);
                //MessageBox.Show(email);
                reader.Close();
                if (info[1] == email)
                {
                    //Console.WriteLine("----------------------  We found you  -------------------------\n");

                    //Console.Write("---- ");
                    for (int x = 0; x <= 2; x++)
                    {

                            //MessageBox.Show(info[x] + "  ");


                    }
                    string name2 = info[0];
                    string email2 = info[1];
                    string password2 = info[2];

                    string sql2 = "UPDATE users SET name = '" + name2 + "', password = '" + password2 + "'  where email=('" + email2 + "')";

                    NpgsqlCommand command2 = new NpgsqlCommand(sql2, con);
                    //NpgsqlDataReader reader2 = command2.ExecuteReader();
                    int a = command2.ExecuteNonQuery();
                    if (a != 0)
                    {
                        //reader2.Close();
                        MessageBox.Show("Updation is done");
                        Delete();
                        ShowAll();
                    }
                    //ShowAll();
                    //Console.WriteLine("\n-----------------  Do you want any changes (y/n)? --------------------\n");
                    //char i = char.Parse(Console.ReadLine());
                    //if (i == 'y')
                    //{
                    //    //Console.Clear();
                    //    Console.WriteLine(" ----------------  Ok  --------------------");

                    //    Console.Write("Enter new name: ");
                    //    string name_new = Console.ReadLine();

                    //    Console.Write("Enter new password: ");
                    //    string password_new = Console.ReadLine();
                    //    // ignore email
                    //    string emaildummy = "sam@gmail.com";

                    //    InfoUser2 obj = new InfoUser2();
                    //    int j = obj.update(emaildummy, password_new, name_new);

                    //    if (j == 3)
                    //    {

                    //        string query = @"insert into public.update(name,email,password)values(('" + name_new + "'),('" + email + "'),('" + password_new + "'))";
                    //        NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                    //        int v = cmd.ExecuteNonQuery();
                    //        int n = v;
                    //        if (n == 1)
                    //        {
                    //            Console.WriteLine("Request is sended to admin");
                    //            System.Threading.Thread.Sleep(2000);
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    Console.WriteLine("Rejected");
                    //    System.Threading.Thread.Sleep(2000);
                    //}
                }
                else
                {
                    MessageBox.Show("UserNotFound");
                    ShowAll();

                }
                // close the query
                reader.Close();

            }

        }
        // delete
        public void Delete()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                con.Open();
                //Console.Write("Enter person email to delete that person: ");
                string email = textBox1.Text;
                //string sql = "SELECT * FROM public.users ";
                string sql = "DELETE FROM update WHERE email='" + email + "'";

                //NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                int v = cmd.ExecuteNonQuery();
                if (v != 0)
                {
                    MessageBox.Show("Record deleted");
                }
                //reader.Close();
                con.Close();
            }

        }
        // delete

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
