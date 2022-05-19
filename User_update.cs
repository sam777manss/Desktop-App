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
    public partial class User_update : Form
    {
        public User_update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailck = textBox3.Text;
            int mailCount =  LoginRecord(emailck);
            if(mailCount == 1)
            {
                //MessageBox.Show("I need this");
                // start
                using (NpgsqlConnection con = GetConnection())


                {
                    con.Open();
                    //Console.Clear();
                    //Console.Clear();
                    //Console.WriteLine(" ----------------  Ok  --------------------");

                    //Console.Write("Enter new name: ");
                    string name_new = textBox1.Text;

                    //Console.Write("Enter new password: ");
                    string password_new = textBox2.Text;

                    // ignore email
                    string emaildummy = "sam@gmail.com";

                    InfoUser2 obj = new InfoUser2();
                    int j = update2(emaildummy, password_new, name_new);

                    if (j == 3)
                    {

                        string query = @"insert into public.update(name,email,password)values(('" + name_new + "'),('" + emailck + "'),('" + password_new + "'))";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                        int v = cmd.ExecuteNonQuery();
                        int n = v;
                        if (n == 1)
                        {
                            MessageBox.Show("Request is sended to admin");
                            //System.Threading.Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credentials is wrong");
                    }


                }
                // end
            }
            else
            {
                MessageBox.Show("User Info is Wrong");
            }

            int LoginRecord(string email)
            {
                using (NpgsqlConnection con = GetConnection())


                {
                    con.Open();

                    string sql = "SELECT * FROM public.users where email=('" + email + "') ";

                    NpgsqlCommand command = new NpgsqlCommand(sql, con);
                    string val;
                    string[] info = new string[6];
                    NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        for (int x = 0; x <= 5; x++)
                        {

                            info[x] += reader[x].ToString();


                        }
                        //Console.WriteLine(info[0]);
                        //Console.WriteLine(info[1]);
                        //do whatever you like
                    }
                    reader.Close();
                    if (info[1] == email)
                    {
                        //Console.WriteLine("----------------------  We found you  -------------------------\n");

                        //MessageBox.Show("---- ");

                        //Console.WriteLine("\n-----------------  Do you want any changes (y/n)? --------------------\n");
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("UserNotFound");
                        return 0;
                    }
                    //Console.WriteLine("");
                    // close the query
                    reader.Close();
                    // select


                }
            }
        
        }

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

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void User_update_Load(object sender, EventArgs e)
        {

        }
    }
}
