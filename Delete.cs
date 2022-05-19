using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Npgsql;
using Calculator;
using System.Collections;

namespace HelloWorld
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string emailck = textBox1.Text;
            int count = forEmail(emailck);

            if (count == 1)
            {
                //MessageBox.Show("Ok Valid");
                Delete();
                void Delete()
                {
                    using (NpgsqlConnection con = GetConnection())
                    {
                        con.Open();
                        //Console.Write("Enter person email to delete that person: ");
                        string email = textBox1.Text;
                        //string sql = "SELECT * FROM public.users ";
                        string sql = "DELETE FROM users WHERE email='" + email + "'";

                        //NpgsqlCommand command = new NpgsqlCommand(sql, con);
                        NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                        int v = cmd.ExecuteNonQuery();
                        int n = v;
                        if (n == 1)
                        {
                            MessageBox.Show("Record deleted");
                        }
                        //reader.Close();

                    }

                }
            }
            else
            {
                MessageBox.Show("Invalid email");
            }

            // email vali
            int forEmail(string email_id)
            {
                if (email_id == "null" || email_id == "")
                {
                    Console.WriteLine("Enter email id: ");
                    return 0;
                }
                else
                {

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email_id);

                    if (match.Success)
                    {
                        Console.WriteLine("");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("Email is invalid");
                        return 0;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
    }
}
