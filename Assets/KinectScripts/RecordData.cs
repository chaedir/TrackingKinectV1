using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class RecordData : MonoBehaviour

{

    private List<string[]> rowData = new List<string[]>();
    private float interval = 24;

    // Use this for initialization
    public void Start()
    {
        InvokeRepeating("Save", 0, 1f / interval);
    }

    public void Save()
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
}