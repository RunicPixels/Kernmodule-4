using UnityEngine;

namespace Database
{
    public class DBUserManager : MonoBehaviour // Unity class to manage user data.
    {
        // Since a client can only be one user I'm gonna use a singleton to access the user. (If the client would have multiple users, I'd update this class to have a list of users and a selected active user.)
        public DBUser User { private set; get; }
    
        private void Start()
        {
            if(User == null) User = new DBUser("WARNING : NO NAME ASSIGNED!", "WARNING : NO PASSWORD ASSIGNED!"); // Placeholder data for easy debugging.
        }

        public void SetUserName(string username)
        {
            User.SetUserName(username);
            Debug.Log("Setting Username to " + User.Username);
        }

        public void SetPassword(string password)
        {
            User.SetPassword(password);
            Debug.Log("Changing password!");
        }

        public void SetScore(int score)
        {
            User.SetScore(score);
        }
    }
}
