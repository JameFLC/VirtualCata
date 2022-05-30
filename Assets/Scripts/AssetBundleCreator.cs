#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class AssetBundleCreator : MonoBehaviour
{
    


    static string extention = "hologram";
    static string rootFloder = "Assets";
    static string bundlesFolder = "Hologrammes";



    [MenuItem ("Assets/Exportation Hologrammes")]
    static void BuildBundles()
    {
        // Create the proper folder if needed 
        if (!Directory.Exists(rootFloder + "/" + bundlesFolder)) 
        {
            Directory.CreateDirectory(rootFloder + "/" + bundlesFolder);
            Debug.Log("Created " + rootFloder + "/" + bundlesFolder + " folder");
        }
        


        RemoveBundles();
        BuildPipeline.BuildAssetBundles(rootFloder + "/" + bundlesFolder, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        CleanBundles();

        AssetDatabase.Refresh();
    }
    // Remove all assets
    static void RemoveBundles()
    {
        string[] files = Directory.GetFiles(rootFloder + "/" + bundlesFolder);

        foreach (var item in files)
        {
            File.Delete(item);
        }
    }


    static void CleanBundles()
    {

        string[] files = Directory.GetFiles(rootFloder + "/" + bundlesFolder);


       
        
        foreach (var item in files)
        {


            // Remove master assetBundle since it's not usefull in this context
            if (item.EndsWith(bundlesFolder))
            {
                File.Delete(item);
                
                continue;
            }


            // Add a custom extention to all files containing blanck extentions since they're are the exported asset bundles
            if (!item.Contains("."))
            {
                File.Move(item, item + "." + extention);
                continue;
            }

            // Remove all other useless files generated during buid process
            if (!item.Contains(".extention"))
            {
                File.Delete(item);
                continue;
            }

            
        }
    }
}
#endif