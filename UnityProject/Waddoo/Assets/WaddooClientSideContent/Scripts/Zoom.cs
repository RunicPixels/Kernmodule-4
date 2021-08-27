using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {
    public float zoomSpeed = 4f;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.touchCount == 2) {
            Camera camera = Camera.main;
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (camera.orthographic) {
                // ... change the orthographic size based on the change in distance between the touches.
                camera.orthographicSize += deltaMagnitudeDiff * zoomSpeed * 0.005f;

                // Make sure the orthographic size never drops below zero.
                camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 2f, 8f);
            }
            else {
                // Otherwise change the field of view based on the change in distance between the touches.
                camera.fieldOfView += deltaMagnitudeDiff * zoomSpeed * 0.01f;

                // Clamp the field of view to make sure it's between 0 and 180.
                camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 26f, 110f);
            }
        }
    }
}
