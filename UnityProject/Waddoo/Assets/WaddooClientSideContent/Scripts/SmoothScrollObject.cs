using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothScrollObject : MonoBehaviour {
    public float distance = 1;

    [HideInInspector]
    public RectTransform rectTransform;

    //private Image image;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        //SetCurrentImage();
    }

    /*public void SetCurrentImage() {
        image = GetComponent<Image>();
    }*/
}
