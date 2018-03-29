using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class RecordData : MonoBehaviour

{

    private List<string[]> rowData = new List<string[]>();
    private List<string[]> rowData2 = new List<string[]>();
    private List<string[]> rowData3 = new List<string[]>();
    public float interval = 24;

    // Use this for initialization
    public void Start()
    {
        InvokeRepeating("Save", 0, 1f / interval);
        InvokeRepeating("Save2", 0, 1f / interval);
        InvokeRepeating("Save3", 0, 1f / interval);
    }

    void Save()
    {


        //for (int i = 0; i < 10; i++)

        string[] rowDataTemp = new string[1];

        rowDataTemp[0] = GameObject.Find("RecordCube").transform.position.x + ""; // Income
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

    void Save2()
    {


        //for (int i = 0; i < 10; i++)

        string[] rowDataTemp2 = new string[1];

        rowDataTemp2[0] = GameObject.Find("RecordCube").transform.position.y + ""; // Income
        rowData2.Add(rowDataTemp2);


        string[][] output = new string[rowData2.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData2[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath2();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    void Save3()
    {


        //for (int i = 0; i < 10; i++)

        string[] rowDataTemp3 = new string[1];

        rowDataTemp3[0] = GameObject.Find("RecordCube").transform.position.z + ""; // Income
        rowData3.Add(rowDataTemp3);


        string[][] output = new string[rowData3.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData3[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath3();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data_X.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    private string getPath2()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data_Y.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }

    private string getPath3()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" + "Saved_data_Z.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }
}