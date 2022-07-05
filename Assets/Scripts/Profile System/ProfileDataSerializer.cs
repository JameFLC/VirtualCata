using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileDataSerializer : MonoBehaviour
{
    
    public static string Serialize(ProfileData profileData)
    {
        if (profileData != null)
        { 
            return "ProfileData object data : " + "Hotel Type : " + profileData.hotelType + ", Lights Type: " + profileData.hotelLights + ",  Hotel fullness: " + profileData.hotelFullness + ", Evacuation direction : " + profileData.evacuationDirection + ", Evacuation type : " + profileData.evacuationType + ",  Smoke Duration : " + profileData.smokeDuration;
        }
        else
        {
            return "ProfileData object is null";
        }
    }
}
