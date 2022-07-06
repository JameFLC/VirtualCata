using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IODataExporterCSV : MonoBehaviour
{
    [SerializeField] string bundlesFolder = "CSV";
    [SerializeField] string fileName = "data";
    string extention = "csv";

    

    public void ExportCSVFile()
    {
        setupPath();
        ExportCSV(GenerateCSV());
    }
    public void LogCSVFile()
    {
        Debug.Log(GenerateCSV());
    }


    private string setupPath()
    {
        string filePath = getPath() + bundlesFolder;
        // Create the proper folder if needed 
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
            Debug.Log("Created " + filePath + " folder");
        }
        return filePath;
    }

    private string GenerateCSV()
    {
        List<IODataRecorder> recorderList = IODataRecorderManager.getAllRecorders();

        string CSVText = "";

        foreach (var recorder in recorderList)
        {
            IOData newData = recorder.getData();
            CSVText += newData.SerializeData(recorder.getUpdateDelay());
        }
        return CSVText;
    }
    
    private void ExportCSV(string CSVText)
    {
        string exportPath = setupPath() + "/" + fileName + GetTime() + "." + extention;
        Debug.Log(exportPath);
        File.WriteAllText(exportPath, CSVText);
        StartCoroutine(WaitToTranspose(exportPath));
    }

    private static string GetTime()
    {
        return System.DateTime.Now.ToString("_dddd-dd-MMMM-yyyy") + "_" + System.DateTime.Now.ToString("HH")+"h"+ System.DateTime.Now.ToString("mm");
    }

    private string getPath() // from https://forum.unity.com/threads/write-data-from-list-to-csv-file.643561/
    {
#if UNITY_EDITOR
        return Application.dataPath + "/";

#elif UNITY_ANDROID
        return Application.persistentDataPath;
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/";
#else
        return Application.dataPath +"/";
#endif
    }
    private IEnumerator WaitToTranspose(string csvFile)
    {
        yield return new WaitForSeconds(10);
        CSVTransposer.Transpose(csvFile);
    }
}
