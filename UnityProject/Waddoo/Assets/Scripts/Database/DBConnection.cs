using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Database
{
    public class DBConnection : MonoBehaviour
    {
        public string addScoreURL = "https://ronaldvanegdom.nl/kernm4/scoreSystem.php";
        public string highscoreURL = "http://localhost/unity_test/display.php"; 

        //Text to display the result on
        public Text statusText;
        
        
        public IEnumerator PostScores(DBUser user)
        {
            WWWForm form = new WWWForm();
            
            form.AddField("username", user.Username);
            form.AddField("password", user.Password);
            form.AddField("score", user.Score);
            
            // Post the URL to the site and create a download object to get the result.
            UnityWebRequest wwwPost = UnityWebRequest.Post(addScoreURL, form);
            Debug.Log("Downloading content from" + wwwPost +" at " + wwwPost.url);
            yield return wwwPost.SendWebRequest(); // Wait until the download is done
            
            Debug.Log("Download complete! Content of website is :" + wwwPost.downloadHandler.text);

            statusText.text = wwwPost.downloadHandler.text;
            
            if (wwwPost.error != null)
            {
                var error = "There was an error posting the high score: " + wwwPost.error;
                print(error);
                Debug.LogWarning(error);
                statusText.text = error;
            }
        }


    }
}
