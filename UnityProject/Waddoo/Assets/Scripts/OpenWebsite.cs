using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    public string websiteURL;

    public void OpenSite()
    {
        Application.OpenURL(websiteURL);
    }
}
