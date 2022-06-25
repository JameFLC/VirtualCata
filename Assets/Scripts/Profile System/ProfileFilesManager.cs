using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class ProfileFilesManager
{
    private static string _saveExtention = ".simp"; // dot simulation profile :)
    private static string _profileSavePath = "/profiles";

    public static void SaveProfile(ProfileData profileData, uint saveID)
    {
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + _profileSavePath + saveID + _saveExtention;

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, profileData);
        stream.Close();
    }
    public static ProfileData LoadProfileData(uint profileID)
    {

        string path = Application.persistentDataPath + _profileSavePath + profileID + _saveExtention;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ProfileData prifileData = formatter.Deserialize(stream) as ProfileData;
            stream.Close();

            return prifileData;
        }
        Debug.Log("No Profile file available");
        return null;
    }
    public static bool isProfileAvailable(int saveID)
    {
        string path = Application.persistentDataPath + _profileSavePath + saveID + _saveExtention;
        return File.Exists(path);
    }
}
