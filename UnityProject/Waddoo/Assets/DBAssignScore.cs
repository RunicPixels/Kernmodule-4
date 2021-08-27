using System.Collections;
using System.Collections.Generic;
using Database;
using UnityEngine;

public class DBAssignScore : MonoBehaviour
{
    private DBUser user;
    public DBUserManager userManager;
    private void Start()
    {
        user = userManager.User;
    }
    public void UpdateScore()
    {
        user.SetScore(Player.LocalPlayer.Score);
    }
}
