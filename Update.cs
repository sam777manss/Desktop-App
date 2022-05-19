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
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update();

            void Update()
            {
                using (NpgsqlConnection con = GetConnection())

                {
                    //Console.Clear();
                    con.Open();
                    //Console.Write("--------------------------- Update ------------------------------\n");
                    //MessageBox.Show(textBox1.Text + " "+ textBox2.Text + " "+ textBox3.Text);
                    //Console.WriteLine("Enter new name: ");
                    string name = textBox1.Text;

                    //Console.WriteLine("Enter new password: ");
                    string password = textBox2.Text;

                    //Console.Write("Person email : ");
                    string email = textBox3.Text;

                    InfoUser2 val = new InfoUser2();
                    int i = update2(email, password, name);
                    //MessageBox.Show("i ki value :" + i);
                    if (i == 3)
                    {
                        string sql = "UPDATE users SET name = '" + name + "', password = '" + password + "'  where email=('" + email + "')";

                        NpgsqlCommand command = new NpgsqlCommand(sql, con);
                        NpgsqlDataReader reader = command.ExecuteReader();
                        // MessageBox.Show(reader.HasRows.ToString());
                        //MessageBox.Show(reader.Read().ToString());
                        if (reader.Read())
                        {
                            MessageBox.Show("Updation is done");
                        }
                        MessageBox.Show("Updation is done");
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Re-enter values");
                    }

                }

            }
        }
        //
        public int update2(string email, string password, string name)
        {
            //Console.WriteLine("");
            int forEmail(string email_id)
            {
                if (email_id == "null" || email_id == "")
                {
                    MessageBox.Show("Enter email id: ");
                    return 0;
                }
                else
                {

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);

                    if (match.Success)
                    {
                        //Console.WriteLine("");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("Email is invalid");
                        return 0;
                    }
                }
            }

            int forPassword(string passwordValue)
            {
                //Console.WriteLine("password len: " + passwordValue.Length);
                if (passwordValue == "" || passwordValue == "null")
                {
                    MessageBox.Show("Enter password:");
                    return 0;
                    // passwordError = false;
                    // return false;
                }

                else if (passwordValue.Length >= 8 && passwordValue.Length <= 20)
                {
                    //Console.Write("");
                    return 1;
                    // passwordError = false;
                    // return false;
                }
                else
                {
                    MessageBox.Show("password length must be at least 8 digits");
                    return 0;

                }
            }

            int forName(string v)
            {
                if (v == "null" || v == "")
                {
                    MessageBox.Show("Enter name");
                    return 0;
                }
                else if (v.Length >= 3)
                //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
                {
                    //Console.WriteLine(Regex.Match(v, "^[a-zA-Z]*$").Success);
                    if (Regex.Match(v, "^[a-zA-Z]*$").Success)
                    {
                        //Console.WriteLine("");
                        return 1;
                    }

                    else
                    {
                        MessageBox.Show("Name must not contain special character and numbers");
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Name length must be 3 or more");
                    return 0;
                }
            }


            int count = 0;
            count += forEmail(email);
            count += forPassword(password);
            count += forName(name);
            return count;

        }
        //
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
