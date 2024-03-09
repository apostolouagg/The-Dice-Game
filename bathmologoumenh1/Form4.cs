using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bathmologoumenh1
{
    public partial class Form4 : Form
    {
        List<Users> userslist; //List with the users' info
        List<Users> scorelist; //List with the users' name and personal scores on each level
        Random random;
        Label mylabel = new Label();
        string username; 
        string player; 
        int max;
        int levelselection;
        int randomimage;
        int score = 0;
        int time;
        int clickdice = 0;
        bool clickpicturebox;
        bool restart;

        public Form4(List<Users> userslist, string username, List<Users> scorelist)
        {
            InitializeComponent();

            this.userslist = userslist;
            this.username = username;
            this.scorelist = scorelist;
        }

        //Exit when not playing
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(userslist, username, scorelist);
            form3.Show();

            this.Close();
        }

        //When Form4 opens
        //Basically setting the appearance of Form4
        private void Form4_Load(object sender, EventArgs e)
        {
            button1.Hide();
            button3.Hide();

            random = new Random();

            label10.Text = clickdice.ToString();
            label12.Text = score.ToString();
            label14.Text = "-";
            label17.Text = "-";
            label18.Text = "-";

            timer1.Enabled = true;
            timer2.Enabled = true;

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;

            //Personal scores appear
            foreach (Users score in scorelist)
            {
                if (score.username.Equals(username))
                {
                    label6.Text = score.easyscore;
                    label7.Text = score.mediumscore;
                    label8.Text = score.hardscore;
                    break;
                }
            }

        }

        //Easy
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            levelselection = 1; //Number of easy level
            timer1.Interval = 1000; //Time interval of easy level
            time = 60; //Time given in easy level
            label14.Text = time.ToString(); //Showing given time so the user knows the first differences of the levels

            //Finding the max score so i can find the top user of the level
            max = -1;
            foreach (Users score in scorelist)
            {
                if (int.Parse(score.easyscore) > max)
                {
                    max = int.Parse(score.easyscore);
                    player = score.username;
                }
            }

            label17.Text = player;
            label18.Text = max.ToString();
            score = 1; //Because the dice you click at the beggining gives 1 point
        }

        //Medium
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            levelselection = 2; //Number of medium level
            timer1.Interval = 850; //Time interval of medium level
            time = 45; //Time given in medium level
            label14.Text = time.ToString(); //Showing given time so the user knows the first differences of the levels

            //Finding the max score so i can find the top user of the level
            max = -1;
            foreach (Users score in scorelist)
            {
                if (int.Parse(score.mediumscore) > max)
                {
                    max = int.Parse(score.mediumscore);
                    player = score.username;
                }
            }

            label17.Text = player;
            label18.Text = max.ToString();
            score = 1; //Because the dice you click at the beggining gives 1 point
        }

        //Hard
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            levelselection = 3; //Number of hard level
            timer1.Interval = 700; //Time interval of hard level
            time = 30; //Time given in hard level
            label14.Text = time.ToString(); //Showing given time so the user knows the first differences of the levels

            //Finding the max score so i can find the top user of the level
            max = -1;
            foreach (Users score in scorelist)
            {
                if (int.Parse(score.hardscore) > max)
                {
                    max = int.Parse(score.hardscore);
                    player = score.username;
                }
            }

            label17.Text = player;
            label18.Text = max.ToString();
            score = 1; //Because the dice you click at the beggining gives 1 point
        }

        //Exit while playing
        //Different than the other Exit button because it appears while you play and it has options
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            var answer = MessageBox.Show("Are you sure you want to exit? Any made progress will be lost.", "Exit Game", MessageBoxButtons.YesNo);

            if (answer == DialogResult.Yes)
            {
                Form3 form3 = new Form3(userslist, username, scorelist);
                form3.Show();

                this.Close();
            }
            else
            {
                mylabel.Show();
                restart = true;
            }
        }

        //Restart button
        //It basically sets everything like it was in the beggining
        private void button1_Click(object sender, EventArgs e)
        {
            restart = true;

            timer1.Enabled = false;
            timer2.Enabled = false;

            clickdice = 0;
            score = 0;

            if (levelselection == 1)
            {
                time = 60;
            }
            else if (levelselection == 2)
            {
                time = 45;
            }
            else
            {
                time = 30;
            }

            mylabel.Text = "Choose level and click the dice to start playing.";
            mylabel.Show();
            label10.Text = clickdice.ToString();
            label12.Text = score.ToString();
            label14.Text = time.ToString();

            button3.Show();
            button2.Hide();

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            pictureBox1.Enabled = true;
        }

        //Timer1
        //Time of the picturebox movement
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Easy
            if (levelselection == 1 && clickpicturebox) //Checks if the player chose level and clicked the dice
            {
                //Changes place and number of the dice
                randomimage = random.Next(1, 7);
                pictureBox1.ImageLocation = "gameimages/dice_" + randomimage.ToString() + ".png";

                int x1, y1;
                x1 = random.Next(panel1.Width - pictureBox1.Width);
                y1 = random.Next(panel1.Height - pictureBox1.Height);
                pictureBox1.Location = new Point(x1, y1);

                label10.Text = clickdice.ToString(); //Updates the "Times clicked the dice" section
                label12.Text = score.ToString(); //Updates the "Score" section
            }
            //Medium
            else if (levelselection == 2 && clickpicturebox) //Checks if the player chose level and clicked the dice
            {
                //Changes place and number of the dice
                randomimage = random.Next(1, 7);
                pictureBox1.ImageLocation = "gameimages/dice_" + randomimage.ToString() + ".png";

                int x1, y1;
                x1 = random.Next(panel1.Width - pictureBox1.Width);
                y1 = random.Next(panel1.Height - pictureBox1.Height);
                pictureBox1.Location = new Point(x1, y1);

                label10.Text = clickdice.ToString(); //Updates the "Times clicked the dice" section
                label12.Text = score.ToString(); //Updates the "Score" section
            }
            //Hard
            else if(levelselection == 3 && clickpicturebox) //Checks if the player chose level and clicked the dice
            {
                //Changes place and number of the dice
                randomimage = random.Next(1, 7);
                pictureBox1.ImageLocation = "gameimages/dice_" + randomimage.ToString() + ".png";

                int x1, y1;
                x1 = random.Next(panel1.Width - pictureBox1.Width);
                y1 = random.Next(panel1.Height - pictureBox1.Height);
                pictureBox1.Location = new Point(x1, y1);

                label10.Text = clickdice.ToString(); //Updates the "Times clicked the dice" section
                label12.Text = score.ToString(); //Updates the "Score" section
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        //Panel
        //Shows my label
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            mylabel.Text = "Choose level and click the dice to start playing.";
            mylabel.Location = new System.Drawing.Point(380, 190);
            mylabel.Size = new System.Drawing.Size(412, 28);
            mylabel.ForeColor = System.Drawing.Color.Black;
            mylabel.BackColor = System.Drawing.Color.Transparent;
            mylabel.Font = new Font("MS Reference Sans Serif", 12, FontStyle.Bold);
            panel1.Controls.Add(mylabel);
        }

        //Click Dice
        private void picturebox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Buttons that you can use while playing
            button1.Show(); //"Restart" button
            button3.Show(); //"Exit" (while playing) button

            //Buttons that you cannot use while playing
            button2.Hide(); //"Exit" button

            score += randomimage; //Adds the score
            clickdice++; //Adds the times the dice was clicked
            clickpicturebox = true; //The dice is clicked

            //Click dice to start when restart button is clicked
            if (restart)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                mylabel.Hide();
                restart = false;
            }

            //Making sure the player chooses level
            if (levelselection != 1 && levelselection != 2 && levelselection != 3)
            {
                MessageBox.Show("Choose level first!"); //Reminder
                restart = true; //Using the code of the "Restart" button so that everything stays the same 
                clickpicturebox = false; /* The dice shouldn't start even though it's clicked because the player didn't choose level. Without this condition, when the player
                                          finally chooses level after the Reminder (MessageBox) appears, the dice starts moving on it's own. (which is wrong)*/
            }
            else
            {
                //When the game my label hides and the player cannot change level
                mylabel.Hide();

                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
            }
        }

        //Timer2
        //Time of the game
        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((levelselection == 1 || levelselection == 2 || levelselection == 3) && clickpicturebox)
            {
                time--;
                label14.Text = time.ToString();

                //What happens when the time runs out
                if (time == 0)
                {
                    //Disabel timers and dice
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    pictureBox1.Enabled = false;

                    //If there's a new personal Highscore i update the file and the scorelist on the level chosen and immediatelly showing it to the user
                    //Easy
                    if (levelselection == 1)
                    {
                        button3.Hide(); //"Exit" (while playing) button
                        button2.Show(); //"Exit" button

                        time = 60; //time is set like it was in the beggining
                        label14.Text = time.ToString();

                        StreamReader sr = new StreamReader("usersscore.txt");
                        string s = sr.ReadLine();

                        while (s != null)
                        {
                            if (s.StartsWith(username))
                            {
                                if (score > int.Parse(s.Split('|')[1]))
                                {
                                    MessageBox.Show("NEW PERSONAL HIGHSCORE!!!");

                                    sr.Close();
                                    File.WriteAllText("usersscore.txt", File.ReadAllText("usersscore.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + s.Split('|')[3], username + "|" + score.ToString() + "|" + s.Split('|')[2] + "|" + s.Split('|')[3]));

                                    foreach (Users score in scorelist)
                                    {
                                        if (score.username.Equals(username))
                                        {
                                            score.easyscore = this.score.ToString();
                                            break;
                                        }
                                    }

                                    label6.Text = score.ToString(); //Shows new score

                                    break;
                                }
                            }

                            s = sr.ReadLine();
                        }
                    }
                    //Medium
                    else if (levelselection == 2)
                    {
                        button3.Hide(); //"Exit" (while playing) button
                        button2.Show(); //"Exit" button

                        time = 45; //time is set like it was in the beggining
                        label14.Text = time.ToString();

                        StreamReader sr = new StreamReader("usersscore.txt");
                        string s = sr.ReadLine();

                        while (s != null)
                        {
                            if (s.StartsWith(username))
                            {
                                if (score > int.Parse(s.Split('|')[2]))
                                {
                                    MessageBox.Show("NEW PERSONAL HIGHSCORE!!!");

                                    sr.Close();
                                    File.WriteAllText("usersscore.txt", File.ReadAllText("usersscore.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + s.Split('|')[3], username + "|" + s.Split('|')[1] + "|" + score.ToString() + "|" + s.Split('|')[3]));

                                    foreach (Users score in scorelist)
                                    {
                                        if (score.username.Equals(username))
                                        {
                                            score.mediumscore = this.score.ToString();
                                            break;
                                        }
                                    }

                                    label7.Text = score.ToString(); //Shows new score

                                    break;
                                }
                            }

                            s = sr.ReadLine();
                        }
                    }
                    //Hard
                    else
                    {
                        button3.Hide(); //"Exit" (while playing) button
                        button2.Show(); //"Exit" button

                        time = 30; //time is set like it was in the beggining
                        label14.Text = time.ToString();

                        StreamReader sr = new StreamReader("usersscore.txt");
                        string s = sr.ReadLine();

                        while (s != null)
                        {
                            if (s.StartsWith(username))
                            {
                                if (score > int.Parse(s.Split('|')[3]))
                                {
                                    MessageBox.Show("NEW PERSONAL HIGHSCORE!!!");

                                    sr.Close();
                                    File.WriteAllText("usersscore.txt", File.ReadAllText("usersscore.txt").Replace(username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + s.Split('|')[3], username + "|" + s.Split('|')[1] + "|" + s.Split('|')[2] + "|" + score.ToString()));

                                    foreach (Users score in scorelist)
                                    {
                                        if (score.username.Equals(username))
                                        {
                                            score.hardscore = this.score.ToString();
                                            break;
                                        }
                                    }

                                    label8.Text = score.ToString(); //Shows new score

                                    break;
                                }
                            }

                            s = sr.ReadLine();
                        }
                    }

                    MessageBox.Show("Click the Restart button if you want to play again!");
                }
            }
        }
    }
}
