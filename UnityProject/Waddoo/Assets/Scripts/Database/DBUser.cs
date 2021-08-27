using UnityEngine.SocialPlatforms.Impl;

namespace Database
{
    public class DBUser // Container for User Data
    {
        public string Username { get; private set;}
        public string Password { get; private set;} // No need to hash this, because this is a client side variable and isn't a SyncVar.
        public int Score { get; private set; }


        public DBUser(string username, string password)
        {
            Username = username;
            Password = password;
            Score = 0;
        }

        public void SetUserName(string username)
        {
            Username = username;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetScore(int score)
        {
            Score = score;
        }
    }
}
