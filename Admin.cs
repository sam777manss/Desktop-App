using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using Npgsql;
using System.Collections;
// Calculator is a dll file
using Calculator;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    public partial class Admin : Form
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
        public Admin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email3 = textBox1.Text;
            string password3 = textBox2.Text;

            // starts
            int counter = 0;
            InfoUser2 log = new InfoUser2();
            ArrayList arr = new ArrayList();
            arr = log.login(email3, password3);
            foreach(string st in arr)
            {
                if(st == "2")
                {
                    counter = 2;
                    break;
                }
                else
                {
                    MessageBox.Show(st);
                }
            }
            if (counter == 2)
            {
                using (NpgsqlConnection con = GetConnection())

                {
                    con.Open();

                    //string sql = "SELECT * FROM public.users where email=('" + email3 + "') AND password=('" + password3 + "')";
                    string sql = "SELECT * FROM public.users where email=('" + email3 + "') AND password=('" + password3 + "')";

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
                    }

                    reader.Close();
                    if (info[1] == "admin@gmail.com" && info[3] == "admin1234567")
                    {
                        CRUD2 obIn = new CRUD2();
                        bool flager = true;
                        //Console.WriteLine("--------------------------- Hi, Admin ------------------------------\n");
                        AdminPanel obj = new AdminPanel();
                        obj.Show();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Credetials is Wrong");
                    }

                }
            }
            else
            {
                //label4.Text = "Credetials is Wrong";
                MessageBox.Show("Credetials is Wrong");
            }

            // ends


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
