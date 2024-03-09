using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace bathmologoumenh1
{
    public partial class Form3 : Form
    {
        /* Most of the things in this Form are for the sake of its appearance */

        List<Users> userslist;
        List<Users> scorelist;

        string username; //Getting it from constructor
        int time = 1; //The seconds the user has to wait
        string imagepath; //path of profile image

        Label mylabel = new Label(); //My label

        public Form3(List<Users> userslist, string username, List<Users> scorelist)
        {
            InitializeComponent();

            this.userslist = userslist;
            this.username = username;
            this.scorelist = scorelist;
        }

        //What happens everytime the user logs in or exits the game
        private void Form3_Load(object sender, EventArgs e)
        {
            //Loads almost every info about the user
            StreamReader sr = new StreamReader("userstheme.txt");
            string s = sr.ReadLine();

            foreach (Users user in userslist)
            {
                if (user.username.Equals(username) && s.StartsWith(username))
                {
                    label2.Text = user.username;
                    label8.Text = user.password;
                    label9.Text = user.email;
                    label10.Text = user.age;
                    label11.Text = user.phonenumber;

                    if (user.imagepath.Equals("None"))
                    {
                        pictureBox1.Image = Properties.Resources.Screenshot_2; //Default profile picture
                    }
                    else
                    {
                        pictureBox1.ImageLocation = user.imagepath;
                    }

                    //For the Form's appearance sake
                    this.BackColor = Color.FromName(s.Split('|')[1]);
                    listBox1.BackColor = Color.FromName(s.Split('|')[1]);

                    //Main Menu
                    label1.ForeColor = Color.FromName(s.Split('|')[2]);
                    label2.ForeColor = Color.FromName(s.Split('|')[2]);
                    label3.ForeColor = Color.FromName(s.Split('|')[2]);
                    label4.ForeColor = Color.FromName(s.Split('|')[2]);
                    label5.ForeColor = Color.FromName(s.Split('|')[2]);
                    label6.ForeColor = Color.FromName(s.Split('|')[2]);
                    label7.ForeColor = Color.FromName(s.Split('|')[2]);
                    label8.ForeColor = Color.FromName(s.Split('|')[2]);
                    label9.ForeColor = Color.FromName(s.Split('|')[2]);
                    label10.ForeColor = Color.FromName(s.Split('|')[2]);
                    label11.ForeColor = Color.FromName(s.Split('|')[2]);
                    label13.ForeColor = Color.FromName(s.Split('|')[2]);
                    listBox1.ForeColor = Color.FromName(s.Split('|')[2]);

                    //Account Settings
                    label14.ForeColor = Color.FromName(s.Split('|')[2]);
                    label15.ForeColor = Color.FromName(s.Split('|')[2]);
                    label16.ForeColor = Color.FromName(s.Split('|')[2]);
                    label17.ForeColor = Color.FromName(s.Split('|')[2]);
                    label18.ForeColor = Color.FromName(s.Split('|')[2]);
                    label19.ForeColor = Color.FromName(s.Split('|')[2]);
                    label20.ForeColor = Color.FromName(s.Split('|')[2]);
                    label21.ForeColor = Color.FromName(s.Split('|')[2]);
                    radioButton1.ForeColor = Color.FromName(s.Split('|')[2]);
                    radioButton2.ForeColor = Color.FromName(s.Split('|')[2]);
                    radioButton3.ForeColor = Color.FromName(s.Split('|')[2]);

                    mylabel.Text = "Logged In Successfully!";
                    mylabel.Location = new System.Drawing.Point(220, 180);
                    mylabel.Size = new System.Drawing.Size(412, 28);
                    mylabel.ForeColor = System.Drawing.Color.FromName(s.Split('|')[2]);
                    mylabel.BackColor = System.Drawing.Color.Transparent;
                    mylabel.Font = new Font("MS Reference Sans Serif", 12, FontStyle.Bold);
                    this.Controls.Add(mylabel);

                    break;
                }

                s = sr.ReadLine();
            }
            sr.Close();

            //When Form3 opens
            //My label is visible right now
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();

            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();

            pictureBox1.Hide();
            pictureBox2.Hide();

            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();

            listBox1.Hide();

            timer1.Enabled = true;
            mylabel.Show();
        }

        //Account Settings (label12 color, cursor on label)
        //For the Form's appearance sake
        private void label12_MouseMove(object sender, MouseEventArgs e)
        {
            label12.ForeColor = Color.DodgerBlue;
        }

        //Account Settings (label12 color, cursor on Form)
        //For the Form's appearance sake
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label12.ForeColor = Color.DeepSkyBlue;
        }

        //Account Settings
        //For the Form's appearance sake
        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            //Main Menu
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label22.Hide();

            listBox1.Hide();

            button2.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            pictureBox1.Hide();

            //Account Settings
            pictureBox2.Show();
            button1.Show();
            button3.Show();;

            label14.Show();
            label15.Show();
            label16.Show();
            label17.Show();
        }

        //PLAY button
        //Gets you to Form4 with the info it needs
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(userslist, username, scorelist);
            form4.Show();

            this.Hide();
        }

        //Timer
        //For the Form's appearance sake
        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;

            //When "Logged In Successfully"(My label) disappears the Main Menu is visible
            if (time == 0)
            {
                timer1.Enabled = false;
                mylabel.Hide();

                //Main Menu
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                label10.Show();
                label11.Show();
                label12.Show();
                label13.Show();
                label22.Show();

                listBox1.Show();

                button2.Show();
                button4.Show();
                button5.Show();
                button6.Show();

                pictureBox1.Show();
            }
        }

        //Log Out button (Settings)
        //Gets you back to Form1
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(userslist, scorelist);
            form1.Show();

            this.Close();
        }

        //Back button (Settings)
        //Gets you back to Main Menu from Settings
        //For the Form's appearance sake
        private void button3_Click(object sender, EventArgs e)
        {
            //Main Menu
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label12.Show();
            label13.Show();
            label22.Show();

            listBox1.Show();

            button2.Show();
            button4.Show();
            button5.Show();
            button6.Show();

            pictureBox1.Show();

            //Account Settings
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();

            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();

            pictureBox2.Hide();
            button1.Hide();
            button3.Hide();
        }

        //White theme (radiationbutton1)
        //For the Form's appearance sake
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Form
            this.BackColor = Color.Bisque;
            listBox1.BackColor = Color.Bisque;

            //Main Menu
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            label10.ForeColor = Color.Black;
            label11.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            label22.ForeColor = Color.Black;
            listBox1.ForeColor = Color.Black;

            //Account Settings
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;
            label17.ForeColor = Color.Black;
            label18.ForeColor = Color.Black;
            label19.ForeColor = Color.Black;
            label20.ForeColor = Color.Black;
            label21.ForeColor = Color.Black;
            radioButton1.ForeColor = Color.Black;
            radioButton2.ForeColor = Color.Black;
            radioButton3.ForeColor = Color.Black;

            //Theme Color Save
            Color theme1 = Color.Bisque;
            string themecolor1 = theme1.Name;

            //Labels Color Save
            Color title1 = Color.Black;
            string titlecolor1 = title1.Name;

            StreamReader sr = new StreamReader("userstheme.txt");
            string s = sr.ReadLine();
            sr.Close();

            //Updating file with the new themes
            File.WriteAllText("userstheme.txt", File.ReadAllText("userstheme.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2], username + "|" + themecolor1 + "|" + titlecolor1));
        }

        //Dark Theme (radiationbutton2)
        //For the Form's appearance sake
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Form
            this.BackColor = Color.DarkSlateGray;
            listBox1.BackColor = Color.DarkSlateGray;

            //Main Menu
            label1.ForeColor = Color.Snow;
            label2.ForeColor = Color.Snow;
            label3.ForeColor = Color.Snow;
            label4.ForeColor = Color.Snow;
            label5.ForeColor = Color.Snow;
            label6.ForeColor = Color.Snow;
            label7.ForeColor = Color.Snow;
            label8.ForeColor = Color.Snow;
            label9.ForeColor = Color.Snow;
            label10.ForeColor = Color.Snow;
            label11.ForeColor = Color.Snow;
            label13.ForeColor = Color.Snow;
            label22.ForeColor = Color.Snow;
            listBox1.ForeColor = Color.Snow;

            //Account Settings
            label14.ForeColor = Color.Snow;
            label15.ForeColor = Color.Snow;
            label16.ForeColor = Color.Snow;
            label17.ForeColor = Color.Snow;
            label18.ForeColor = Color.Snow;
            label19.ForeColor = Color.Snow;
            label20.ForeColor = Color.Snow;
            label21.ForeColor = Color.Snow;
            radioButton1.ForeColor = Color.Snow;
            radioButton2.ForeColor = Color.Snow;
            radioButton3.ForeColor = Color.Snow;

            //Theme Color Save
            Color theme2 = Color.DarkSlateGray;
            string themecolor2 = theme2.Name;

            //Labels Color Save
            Color title2 = Color.Snow;
            string titlecolor2 = title2.Name;

            StreamReader sr = new StreamReader("userstheme.txt");
            string s = sr.ReadLine();
            sr.Close();

            //Updating file with the new themes
            File.WriteAllText("userstheme.txt", File.ReadAllText("userstheme.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2], username + "|" + themecolor2 + "|" + titlecolor2));
        }

        //Change Theme Theme (label15)
        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Show();

            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();
        }

        //Check my personal score (label16)
        private void label16_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();

            foreach (Users score in scorelist)
            {
                if (score.username.Equals(username))
                {
                    label19.Text = score.easyscore;
                    label20.Text = score.mediumscore;
                    label21.Text = score.hardscore;
                }
            }

            label18.Show();
            label19.Show();
            label20.Show();
            label21.Show();
        }

        //Change profile picture (label17)
        private void label17_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();

            label18.Hide();
            label19.Hide();
            label20.Hide();
            label21.Hide();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                imagepath = openFileDialog1.FileName;

                StreamReader sr = new StreamReader("usersinfo.txt");
                string s = sr.ReadLine();
                sr.Close();

                File.WriteAllText("usersinfo.txt", File.ReadAllText("usersinfo.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + s.Split('|')[3] + "|" + s.Split('|')[4] + "|" + s.Split('|')[5], username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + s.Split('|')[3] + "|" + s.Split('|')[4] + "|" + imagepath));
            }
        }

        //Blue Theme (radiationbutton3)
        //For the Form's appearance sake
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Form
            this.BackColor = Color.DarkSlateBlue;
            listBox1.BackColor = Color.DarkSlateBlue;

            //Main Menu
            label1.ForeColor = Color.Snow;
            label2.ForeColor = Color.Snow;
            label3.ForeColor = Color.Snow;
            label4.ForeColor = Color.Snow;
            label5.ForeColor = Color.Snow;
            label6.ForeColor = Color.Snow;
            label7.ForeColor = Color.Snow;
            label8.ForeColor = Color.Snow;
            label9.ForeColor = Color.Snow;
            label10.ForeColor = Color.Snow;
            label11.ForeColor = Color.Snow;
            label13.ForeColor = Color.Snow;
            label22.ForeColor = Color.Snow;
            listBox1.ForeColor = Color.Snow;

            //Account Settings
            label14.ForeColor = Color.Snow;
            label15.ForeColor = Color.Snow;
            label16.ForeColor = Color.Snow;
            label17.ForeColor = Color.Snow;
            label18.ForeColor = Color.Snow;
            label19.ForeColor = Color.Snow;
            label20.ForeColor = Color.Snow;
            label21.ForeColor = Color.Snow;
            radioButton1.ForeColor = Color.Snow;
            radioButton2.ForeColor = Color.Snow;
            radioButton3.ForeColor = Color.Snow;

            //Theme Color Save
            Color theme3 = Color.DarkSlateBlue;
            string themecolor3 = theme3.Name;

            //Labels Color Save
            Color title3 = Color.Snow;
            string titlecolor3 = title3.Name;

            StreamReader sr = new StreamReader("userstheme.txt");
            string s = sr.ReadLine();
            sr.Close();

            //Updating file with the new themes
            File.WriteAllText("userstheme.txt", File.ReadAllText("userstheme.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2], username + "|" + themecolor3 + "|" + titlecolor3));
        }


        /* The 3 buttons bellow update the leaderboard (listbox) by sorting the players based on their score in each level */

        //Easy (Button)
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var scoreboard1 = new List<int>();

            foreach (Users score in scorelist)
            {
                scoreboard1.Add(int.Parse(score.easyscore));
            }

            scoreboard1.Sort();
            scoreboard1.Reverse();

            foreach (var score in scoreboard1)
            {
                foreach (Users scores in scorelist)
                {
                    if (score == int.Parse(scores.easyscore))
                    {
                        if (!listBox1.Items.Contains(scores.username))
                        {
                            listBox1.Items.Add(scores.username);
                        }
                    }
                }
            }
        }

        //Medium (Button)
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var scoreboard2 = new List<int>();

            foreach (Users score in scorelist)
            {
                scoreboard2.Add(int.Parse(score.mediumscore));
            }

            scoreboard2.Sort();
            scoreboard2.Reverse();

            foreach (var score in scoreboard2)
            {
                foreach (Users scores in scorelist)
                {
                    if (score == int.Parse(scores.mediumscore))
                    {
                        if (!listBox1.Items.Contains(scores.username))
                        {
                            listBox1.Items.Add(scores.username);
                        }
                    }
                }
            }
        }

        //Hard (Button)
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var scoreboard3 = new List<int>();

            foreach (Users score in scorelist)
            {
                scoreboard3.Add(int.Parse(score.hardscore));
            }

            scoreboard3.Sort();
            scoreboard3.Reverse();

            foreach (var score in scoreboard3)
            {
                foreach (Users scores in scorelist)
                {
                    if (score == int.Parse(scores.hardscore))
                    {
                        if (!listBox1.Items.Contains(scores.username))
                        {
                            listBox1.Items.Add(scores.username);
                        }
                    }
                }
            }
        }
    }
}
