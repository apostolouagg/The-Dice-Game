using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bathmologoumenh1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* Creating the lists (and the files if they don't exist) so that Form1 starts with the info it needs */

            List<Users> userslist = new List<Users>();

            try
            {
                StreamReader sr = new StreamReader("usersinfo.txt");
                string s = sr.ReadLine();
                string[] arrays;

                while (s != null)
                {
                    arrays = s.Split('|');
                    userslist.Add(new Users(arrays[0], arrays[1], arrays[2], arrays[3], arrays[4], arrays[5]));
                    s = sr.ReadLine();
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                StreamWriter sw = new StreamWriter("usersinfo.txt");
                sw.Close();
            }


            List<Users> scorelist = new List<Users>();

            try
            {
                StreamReader sr = new StreamReader("usersscore.txt");
                string s = sr.ReadLine();
                string[] arrays;

                while (s != null)
                {
                    arrays = s.Split('|');
                    scorelist.Add(new Users(arrays[0], arrays[1], arrays[2], arrays[3]));
                    s = sr.ReadLine();
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                StreamWriter sw = new StreamWriter("usersscore.txt");
                sw.Close();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(userslist, scorelist));
        }
    }
}
