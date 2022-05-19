using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void click_Click(object sender, EventArgs e)
        {
            Signup ob = new Signup();
            ob.Show();
            //labelHello3.Text = "Hello To Hell";
        }

        private void labelHello_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            labelHello3.Text = "Hello here";
            Admin f3 = new Admin(); // Instantiate a Form3 object.
            f3.Show(); // Show Form3 and
            //this.Close(); // closes the Form2 instance.
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            Login loger = new Login();
            loger.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
