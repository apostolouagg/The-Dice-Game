using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bathmologoumenh1
{
    public partial class Form1 : Form
    {
        List<Users> userslist;
        List<Users> scorelist;

        bool usernamecorrect;
        bool passwordcorrect;
        bool userfound;
        string username;

        bool label;

        public Form1(List<Users> userslist, List<Users> scorelist)
        {
            InitializeComponent();
            this.userslist = userslist;
            this.scorelist = scorelist;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Clicked "here" to register
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            Form2 form2 = new Form2(userslist, scorelist);
            form2.Show();

            this.Hide();
        }

        //Exit
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Check Username
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (Users users in userslist)
            {
                if (users.username.Equals(textBox1.Text))
                {
                    usernamecorrect = true;
                    username = users.username;
                    userfound = true;
                    break;
                }
            }
        }

        //Check Password
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (userfound)
            {
                foreach (Users users in userslist)
                {
                    if (users.password.Equals(textBox2.Text))
                    {
                        passwordcorrect = true;
                        break;
                    }
                }
            }
        }

        //Just for appearance
        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Turquoise;
        }

        //Just for appearance
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Snow;
        }

        //Log In
        private void button1_Click_1(object sender, EventArgs e)
        {
            //Logged In
            if (usernamecorrect && passwordcorrect)
            {
                Form3 form3 = new Form3(userslist, username, scorelist);
                form3.Show();

                this.Hide();
            }
            //User not found
            else if (userfound != true)
            {
                MessageBox.Show("This user does not exist. Please try again!");
            }
            //Wrong Username or Password
            else
            {
                MessageBox.Show("Wrong Username or Password. Please try again!");
            }
        }

        //Just for appearance
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label)
            {
                label5.BackColor = Color.Snow;
                label5.ForeColor = Color.DarkSlateBlue;
                label = false;
            }
            else
            {
                label5.BackColor = Color.DarkSlateBlue;
                label5.ForeColor = Color.Snow;
                label = true;
            }
        }
    }
}
