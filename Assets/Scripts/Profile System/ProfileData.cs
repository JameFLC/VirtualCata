using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ProfileData
{
    public uint hotelType; // 0 Fancy, 1 cheap, 
    public uint hotelLights; // 0 on, 1 off
    public uint hotelFullness; // In percent
    public uint evacuationDirection; // 0 distance, 1 left, 2 reight, 3 random
    public uint evacuationType; // 0 oredered, 1 disordered
    public uint smokeDuration; // In seconds

    
    public ProfileData()
    {
        hotelType = 0;
        hotelLights = 0;
        hotelFullness = 0; 
        evacuationDirection = 0; 
        evacuationType = 0; 
        smokeDuration = 30; 
    }

    public ProfileData(uint hotelType, uint hotelLights, uint hotelFullness, uint evacuationDirection, uint evacuationType, uint smokeDuration)
    {
        this.hotelType = hotelType;
        this.hotelLights = hotelLights;
        this.hotelFullness = hotelFullness;
        this.evacuationDirection = evacuationDirection;
        this.evacuationType = evacuationType;
        this.smokeDuration = smokeDuration;
    }
}
