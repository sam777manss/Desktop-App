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
using System.Text.RegularExpressions;
using Calculator;
using System.Runtime.InteropServices;


namespace HelloWorld
{
    public partial class Login : Form
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
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1
            //textBox2
            login();
            void login()
            {
                //Console.Write("Enter email: ");
                string email2 = textBox1.Text;

                //Console.Write("Enter password: ");
                string password2 = textBox2.Text;

                InfoUser2 log = new InfoUser2();

                int checker2 = login2(email2, password2);

                if (checker2 == 2)
                {
                    CRUD2 ob2 = new CRUD2();
                    // success
                    LoginRecord(email2, password2);
                    //MessageBox.Show(email2 + "email");
                    //MessageBox.Show(password2 + " pass");

                    MessageBox.Show("successs");
                }
                else
                {
                    MessageBox.Show("Re-enter values");
                }


            }
        }
        // login rec
        public int login2(string email, string password)
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
                        //Console.Write("");
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

                    MessageBox.Show("Password length must be at least 8 digits and less then 20");
                    return 0;
                }
            }
            int count = 0;
            count += forEmail(email);
            //Console.WriteLine(password.Length + " pass len");
            count += forPassword(password);
            return count;

        }
        //
        public void LoginRecord(string email, string password)
        {
            using (NpgsqlConnection con = GetConnection())


            {
                con.Open();
                //Console.Clear();
                // select  start        ('" + ulogin + "')";

                string sql = "SELECT * FROM public.users where email=('" + email + "') AND password =('" + password + "')";

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
                if (info[1] == email && info[3] == password)
                {
                    //Console.WriteLine("");
                    //string[] column = { "name", "email", "username", "password", "qualification", "sid" };
                    //label5.Text = "----------------------  We found you  -------------------------\n";

                    //Console.Write("---- ");

                    //if (x != 4)

                    //Console.Write(info[x] + " ---- ");
                    // label5.Text = info[x];
                    //MessageBox.Show(info[0]);
                    label5.Text = info[0];
                    label6.Text = info[1];
                    label7.Text = info[2];
                    label8.Text = info[3];
                    label9.Text = info[5];

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
                }
                // close the query
                reader.Close();
                // select


            }
        }
        //login rec
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_update ob = new User_update();
            ob.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
