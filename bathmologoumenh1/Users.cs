using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bathmologoumenh1
{
    public class Users
    {
        public string username;
        public string password;
        public string email;
        public string age;
        public string phonenumber;
        public string imagepath;
        public string easyscore;
        public string mediumscore;
        public string hardscore;


        public Users(string username, string password, string email, string age, string phonenumber, string imagepath)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.age = age;
            this.phonenumber = phonenumber;
            this.imagepath = imagepath;
        }

        public Users(string username, string easyscore, string mediumscore, string hardscore)
        {
            this.username = username;
            this.easyscore = easyscore;
            this.mediumscore = mediumscore;
            this.hardscore = hardscore;
        }
    }
}
