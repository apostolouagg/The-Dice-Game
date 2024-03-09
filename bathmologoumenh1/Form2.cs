using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bathmologoumenh1
{
    public partial class Form2 : Form
    {
        /* In this Form i basically check every registration info the user adds and if it's valid the registration completes.
           Else, the proper messagebox and labels appear */

        List<Users> userslist;
        List<Users> scorelist;

        Regex regex = new Regex("^[0-9]*$");

        string imagepath = "None"; //If the user doesn't choose a profile photo
        bool ex;

        //Default Scores
        string easyscore = "0";
        string mediumscore = "0";
        string hardscore = "0";
        

        public Form2(List<Users> userslist, List<Users> scorelist)
        {
            InitializeComponent();
            this.userslist = userslist;
            this.scorelist = scorelist;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
            label10.Hide();

            openFileDialog1.InitialDirectory = Application.StartupPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(userslist, scorelist);
            form1.Show();

            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("usersinfo.txt", true);
            StreamWriter sw2 = new StreamWriter("userstheme.txt", true);
            StreamWriter sw3 = new StreamWriter("usersscore.txt", true);

            try
            {
                //username
                foreach (Users user in userslist)
                {
                    if (user.username.Equals(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text))
                    {
                        throw new Exception();
                    }
                }

                //password
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    throw new Exception();
                }

                //email
                if (!textBox3.Text.EndsWith("@gmail.com"))
                {
                    ex = true;
                }

                if (!textBox3.Text.EndsWith("@unipi.gr") && ex)
                {
                    ex = false;
                    throw new Exception();
                }

                foreach (Users user in userslist)
                {
                    if (user.email.Equals(textBox3.Text))
                    {
                        throw new Exception();
                    }
                }

                //age
                if (int.Parse(textBox4.Text) < 17 || string.IsNullOrEmpty(textBox4.Text))
                {
                    throw new Exception();
                }

                //phonenumber
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    if (textBox5.Text.Any(char.IsLetter) || textBox5.Text.Length != 10 || !regex.IsMatch(textBox5.Text))
                    {
                        throw new Exception();
                    }
                }

                if (textBox5.Text == "")
                {
                    textBox5.Text = "None";
                }

                //Adding info
                Users users = new Users(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, imagepath);
                userslist.Add(users);

                sw.WriteLine(textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text + "|" + imagepath);
                sw.Close();

                sw2.WriteLine(textBox1.Text + "|" + "Bisque" + "|" + "Black");
                sw2.Close();

                Users score = new Users(textBox1.Text, easyscore, mediumscore, hardscore);
                scorelist.Add(score);

                sw3.WriteLine(textBox1.Text + "|" + easyscore + "|" + mediumscore + "|" + hardscore);
                sw3.Close();

                MessageBox.Show("User saved successfully!");

                Form1 form1 = new Form1(userslist, scorelist);
                form1.Show();

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something is incorrect or Username/Email already exists. Please try again!");
                label10.Show();
                sw.Close();
                sw2.Close();
                sw3.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //imagepath
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                imagepath = openFileDialog1.FileName;
            }
        }
    }
}
