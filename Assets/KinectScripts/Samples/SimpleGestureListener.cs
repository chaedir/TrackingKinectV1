using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;




public class SimpleGestureListener : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    //for record data
    public RecordData record;
    /*private List<string[]> rowData = new List<string[]>();
    public float interval = 24;*/

    // GUI Text to display the gesture messages.
    public GUIText GestureInfo;
	
	// private bool to track if progress message has been displayed
	private bool progressDisplayed;
	
	
	public void UserDetected(uint userId, int userIndex)//Apabila ada user yang terdeteksi
	{
		// as an example - detect these user specific gestures
		KinectManager manager = KinectManager.Instance;

		manager.DetectGesture(userId, KinectGestures.Gestures.Jump);
		manager.DetectGesture(userId, KinectGestures.Gestures.Squat);

//		manager.DetectGesture(userId, KinectGestures.Gestures.Push);
//		manager.DetectGesture(userId, KinectGestures.Gestures.Pull);
		
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeUp);
//		manager.DetectGesture(userId, KinectWrapper.Gestures.SwipeDown);
		
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = "SwipeLeft, SwipeRight, Jump or Squat.";
		}
	}
	
	public void UserLost(uint userId, int userIndex)//Apabila user tidak kedetect
	{
		if(GestureInfo != null)
		{
			GestureInfo.GetComponent<GUIText>().text = string.Empty;
		}
	}

	public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		//GestureInfo.guiText.text = string.Format("{0} Progress: {1:F1}%", gesture, (progress * 100));

        //RISE LEFT HAND GESTURE
		if(gesture == KinectGestures.Gestures.RaiseLeftHand && progress > 0.3f)
		{
			string sGestureText = string.Format ("{0} {1:F1}% complete", gesture, progress * 100);//coba buat event apa disini
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
        //RISE RIGHT HAND GESTURE
        if (gesture == KinectGestures.Gestures.RaiseRightHand && progress > 0.3f)
        {
            string sGestureText = string.Format("{0} {1:F1}% complete", gesture, progress * 100);//coba buat event apa disini
            if (GestureInfo != null)
                GestureInfo.GetComponent<GUIText>().text = sGestureText;

            progressDisplayed = true;
        }

       else if((gesture == KinectGestures.Gestures.ZoomOut || gesture == KinectGestures.Gestures.ZoomIn) && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, zoom={1:F1}%", gesture, screenPos.z * 100);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
		else if(gesture == KinectGestures.Gestures.Wheel && progress > 0.5f)
		{
			string sGestureText = string.Format ("{0} detected, angle={1:F1} deg", gesture, screenPos.z);
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = sGestureText;
			
			progressDisplayed = true;
		}
	}

	public bool GestureCompleted (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
	{
		string sGestureText = gesture + " detected";

        //CLICK GESTURE COMPLETED
		/*if(gesture == KinectGestures.Gestures.Click)
        {
            sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
        }*/

        //RIGHT HAND GESTURE COMPLETED
        if (gesture == KinectGestures.Gestures.RaiseRightHand)
        {
            record.enabled = true;
            //RecordData r = new RecordData();
            //r.Start();
            //InvokeRepeating("Save", 0, 1f / interval);//for record data
            sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
        }

        //LEFT HAND GESTURE COMPLETED
        if (gesture == KinectGestures.Gestures.RaiseLeftHand)
        {
            //record.enabled = true;
            //RecordData r = new RecordData();
            //r.Start();
            //InvokeRepeating("Save", 0, 1f / interval);//for record data
            sGestureText += string.Format(" at ({0:F1}, {1:F1})", screenPos.x, screenPos.y);
        }


        if (GestureInfo != null)
			GestureInfo.GetComponent<GUIText>().text = sGestureText;
		
		progressDisplayed = false;
		
		return true;
	}

	public bool GestureCancelled (uint userId, int userIndex, KinectGestures.Gestures gesture, 
	                              KinectWrapper.NuiSkeletonPositionIndex joint)
	{
		if(progressDisplayed)
		{
			// clear the progress info
			if(GestureInfo != null)
				GestureInfo.GetComponent<GUIText>().text = String.Empty;
			
			progressDisplayed = false;
		}
		
		return true;
	}

    /*
    public void Save()//for record data
    {

        //for (int i = 0; i < 10; i++)

        string[] rowDataTemp = new string[1];

        rowDataTemp[0] = GameObject.Find("RecordCube").transform.position.x + ""; // Income
                                                                                  //rowDataTemp[0] = GameObject.FindWithTag("Hand_Joint").transform.position.x + ""; // Income
        rowData.Add(rowDataTemp);


        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath + "/" + "Saved_data.csv";
#endif
    }
    */
}
