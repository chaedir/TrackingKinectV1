using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleProjection : MonoBehaviour {

    Camera[] myCams = new Camera[3];
    void Start()
    {
        //Get Main Camera
        myCams[0] = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        //Find All other Cameras
        myCams[1] = GameObject.Find("LC").GetComponent<Camera>();
        myCams[2] = GameObject.Find("RC").GetComponent<Camera>();
        //myCams[3] = GameObject.Find("Camera4").GetComponent<Camera>();

        //Call function when new display is connected
        Display.onDisplaysUpdated += OnDisplaysUpdated;

        //Map each Camera to a Display
        mapCameraToDisplay();

        //KinectManager km = new KinectManager();
        //KinectManager.Smoothing smoothing = KinectManager.Smoothing.Aggressive;
        

    }

    void mapCameraToDisplay()
    {
        //Loop over Connected Displays
        for (int i = 0; i < Display.displays.Length; i++)
        {
            myCams[i].targetDisplay = i; //Set the Display in which to render the camera to
            Display.displays[i].Activate(); //Enable the display
        }
    }

    void OnDisplaysUpdated()
    {
        Debug.Log("New Display Connected. Show Display Option Menu....");
    }
}
