using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothScroll : MonoBehaviour {
    private float begin;
    private float end;

    public SmoothScrollObject[] smoothScrollObjects;

    private bool doMove = false;

    [SerializeField]
    private float currentTime;

    private float currentPosition;

    public float duration = 1;

	// Update is called once per frame
	private void Update () {
        if (currentTime < 1 && doMove) {
            currentTime = DoMoveBehaviour(currentTime, end);
        }
        else if(doMove == true) {
            currentTime = 0;
            currentPosition = end;
            //currentPosition = end;
            doMove = false;
        }

    }

    public void DoMove(float position, float time = -1) {
        doMove = true;
        end = position;
        begin = currentPosition;

        if (time > 0) {
            duration = time;
        }
        
    }

    float DoMoveBehaviour(float t, float position) {
        t += Time.deltaTime / duration;
        foreach (SmoothScrollObject smoothScroll in smoothScrollObjects) {
            smoothScroll.rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(-begin * smoothScroll.rectTransform.rect.width * smoothScroll.distance, smoothScroll.rectTransform.localPosition.y), new Vector2(-position * smoothScroll.rectTransform.rect.width * smoothScroll.distance, smoothScroll.rectTransform.localPosition.y), t);
            if (t >= 1) {
                smoothScroll.rectTransform.anchoredPosition = new Vector2(-position * smoothScroll.rectTransform.rect.width * smoothScroll.distance, smoothScroll.rectTransform.localPosition.y);
            }
        }
        return t;
    }
}
