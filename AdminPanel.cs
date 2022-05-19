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
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    public partial class AdminPanel : Form
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
        public AdminPanel()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup ob = new Signup();
            ob.Show();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete ob = new Delete();
            ob.Show();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            ShowAll();
            void ShowAll()
            {

                using (NpgsqlConnection con = GetConnection())


                {
                    con.Open();
                    // select  start        ('" + ulogin + "')";
                    string sql = "SELECT * FROM public.users";

                    NpgsqlCommand command = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                    // Define a query
                    // Execute the query and obtain a result set
                    NpgsqlDataReader dr = command.ExecuteReader();
                    if(dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
                    }
                    con.Dispose();
                    con.Close();
                }

            }
        
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=sameer;Database=postgres");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update ob = new Update();
            ob.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_demands ob = new User_demands();
            ob.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
