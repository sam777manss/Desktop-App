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
using System.Text.RegularExpressions;
// Calculator is a dll file
using Calculator;
using System.Runtime.InteropServices;


namespace HelloWorld
{
    public partial class Signup : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public Signup()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signup();
            void signup()
            {
                ///  -------------- for signup  start ------------ /// 

                // Console.Write("Enter name: ");
                string name = textBox1.Text;

                //Console.Write("Enter email: ");
                string email = textBox2.Text;

                //Console.Write("Enter username: ");
                string username = textBox3.Text;

                //Console.Write("Enter password: ");
                string password = textBox4.Text;

                string qualification = "b.tech";

                InfoUser2 ob = new InfoUser2(name, username, password, email, qualification);
                ob.show();

                int count = 0;
                ArrayList arr = new ArrayList();
                arr = ob.validate();
                foreach(string st in arr)
                {
                    if(st == "5")
                    {
                        count = 5;
                        break;
                    }
                    else
                    {
                        MessageBox.Show(st);
                    }
                }
                // -------------- for signup end  -------------- /// 

                if (count == 5)
                {
                    //TestConnection();
                    //CRUD2 ob1 = new CRUD2();
                    InsertRecord(email, name, username, password, qualification);

                }
                else
                {
                    MessageBox.Show("Credentials is wrong");
                }
            }
        }


        //public int validate(string name, string email, string username, string password)
        //{
        //    //Console.WriteLine("");
        //    int forName(string v)
        //    {
        //        if (v == "null" || v == "")
        //        {
        //            MessageBox.Show("Enter name:");
        //            return 0;
        //        }
        //        else if (v.Length >= 3)
        //        //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
        //        {
        //            //Console.WriteLine(Regex.Match(v, "^[a-zA-Z]*$").Success);
        //            if (Regex.Match(v, "^[a-zA-Z]*$").Success)
        //            {
        //                //MessageBox.Show("");
        //                return 1;
        //            }

        //            else
        //            {
        //                MessageBox.Show("Name must not contain Special character and numbers");
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Name length must be 3 or more");
        //            return 0;
        //        }
        //    }

        //    int forEmail(string email_id)
        //    {
        //        if (email_id == "null" || email_id == "")
        //        {
        //            MessageBox.Show("Enter email id: ");
        //            return 0;
        //        }
        //        else
        //        {

        //            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        //            Match match = regex.Match(email);

        //            if (match.Success)
        //            {
        //                //Console.Write("");
        //                return 1;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Email is invalid");
        //                return 0;
        //            }
        //        }
        //    }

        //    int forUserName(string v)
        //    {
        //        if (v == "null" || v == "")
        //        {
        //            MessageBox.Show("Enter username: ");
        //            return 0;
        //        }
        //        else if (v.Length >= 3 && v.Length <= 10)
        //        //Regex.Match(v, "^[A-Z][a-zA-Z]*$").Success
        //        {
        //            // "^[a-zA-Z0-9_]*$"
        //            string regex = @"^([a-z0-9]+)_([a-z0-9]+)$";
        //            //
        //            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9_]");

        //            //Console.WriteLine(Regex.Match(v, "^[a-zA-Z][0-9]*$").Success);
        //            if ((!Regex.IsMatch(v, regex)))
        //            {
        //                MessageBox.Show("Username Must Be AlphaNumeric + Underscrore");
        //                //Console.Write("");
        //                return 0;
        //            }

        //            else
        //            {
        //                //Console.WriteLine(v);
        //                //Console.WriteLine("Username must not contain special character");
        //                //Console.Write("");
        //                return 1;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Username length should be between 3 and 10");
        //            return 0;
        //        }
        //    }

        //    int forPassword(string passwordValue)
        //    {
        //        //Console.WriteLine("password len: " + passwordValue.Length);
        //        if (passwordValue == "" || passwordValue == "null")
        //        {
        //            MessageBox.Show("Enter password:");
        //            return 0;
        //            // passwordError = false;
        //            // return false;
        //        }

        //        else if (passwordValue.Length >= 8 && passwordValue.Length <= 20)
        //        {
        //            //Console.Write("");
        //            return 1;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Password length must be at least 8 digits and less then 20");
        //            return 0;
        //        }
        //    }


        //    int count = 0;
        //    count += forName(name);
        //    count += forEmail(email);
        //    count += forUserName(username);
        //    count += forPassword(password);
        //    //count += forQualification(qualification);
        //    count += 1;
        //    //System.Threading.Thread.Sleep(5000);
        //    return count;
        //}


        public void InsertRecord(string email, string name, string username, string password, string qualification)
        {

            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();

                string sql = "SELECT * FROM public.users where email=('" + email + "')";

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
                    MessageBox.Show("Email already exist ");
                    //System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    string query = @"insert into public.users(name,email,username,password,qualification)values(('" + name + "'),('" + email + "'), ('" + username + "'),('" + password + "'),('" + qualification + "'))";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                    int v = cmd.ExecuteNonQuery();
                    int n = v;
                    if (n == 1)
                    {
                        MessageBox.Show("Record inserted");
                        //System.Threading.Thread.Sleep(2000);
                    }
                }
                // close the query

                // select


            }

        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
