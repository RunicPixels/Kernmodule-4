using UnityEngine;

namespace Database
{
    public class DBLoginAndUploadScore : MonoBehaviour
    {
        
        public void Upload()
        {
            var DBConnection = DBGlobalManager.Instance.Connection;

            DBConnection.StartCoroutine(DBConnection.PostScores(DBGlobalManager.Instance.UserManager.User));

        }
    }
}
