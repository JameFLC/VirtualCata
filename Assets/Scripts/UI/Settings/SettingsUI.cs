using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(UIFade))]
public class SettingsUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI hotelTypeText;
    [SerializeField] private Button hotelTypeFancyButton;
    [SerializeField] private Button hotelTypeNormalButton;//
    [SerializeField] private Button hotelTypeCheapButton;
    [Space]
    [SerializeField] protected TextMeshProUGUI hotelFullnessText;
    [SerializeField] private Slider hotelFullnessSlider;
    [Space]
    [SerializeField] protected TextMeshProUGUI lightsTypeText;
    [SerializeField] private Button lightsTypeOnButton;
    [SerializeField] private Button lightsTypeOffButton;

    [Space]
    [SerializeField] protected TextMeshProUGUI evacuationTypeText;
    [SerializeField] private Button evacuationOrderedButton;
    [SerializeField] private Button evacuationDisorderedButton;

    [Space]
    [SerializeField] protected TextMeshProUGUI evacuationDirectionText;
    [SerializeField] private Button evacuationDirectionLeftButton;
    [SerializeField] private Button evacuationDirectionRightButton;

    [Space]
    [SerializeField] protected TextMeshProUGUI smokeSpeedText;
    [SerializeField] private Slider smokeSpeedSlider;
    [SerializeField] private bool tenTimes = true;
    [Space]
    [SerializeField] private Button dismissButton;
    [SerializeField] private Button validateButton;


    private ProfileData _currentProfile = new ProfileData();
    private uint _currentProfileID = 0;
    private UIFade _UIFade;

    private void Start()
    {

        // Sliders
        FullnessSliderSubrscribe();
        SmokeSliderSubrscribe();

        // Hotel Types
        hotelTypeFancyButton.onClick.AddListener(() => UpdateHotelType(0));
        hotelTypeNormalButton.onClick.AddListener(() => UpdateHotelType(1));//
        hotelTypeCheapButton.onClick.AddListener(() => UpdateHotelType(2));

        // Lights Types
        lightsTypeOnButton.onClick.AddListener(() => UpdateHotelLights(0));
        lightsTypeOffButton.onClick.AddListener(() => UpdateHotelLights(1));

        // Evacuation Types
        evacuationOrderedButton.onClick.AddListener(() => UpdateEvacuationType(0));
        evacuationDisorderedButton.onClick.AddListener(() => UpdateEvacuationType(1));

        // Evacuation Direction
        evacuationDirectionLeftButton.onClick.AddListener(() => UpdateEvacuationDirection(_currentProfile.evacuationDirection - 1));
        evacuationDirectionRightButton.onClick.AddListener(() => UpdateEvacuationDirection(_currentProfile.evacuationDirection + 1));

        // Dismis Button
        dismissButton.onClick.AddListener(() => _UIFade.HideUI());

        // Validate Button
        validateButton.onClick.AddListener(() => {

            _UIFade.HideUI();
            SaveParametters(_currentProfileID);
        });
        LoadProfile(ProfileFilesManager.LoadProfileData(0));
        _UIFade = GetComponent<UIFade>();

    }

    public void ShowParametters(int profileID)
    {
        if (profileID < 0)
        {
            Debug.LogError("Negative Profile ID used");
            return;
        }
        _currentProfileID = (uint)profileID;
        _UIFade.ShowUI();

        ProfileData newProfile;
        newProfile = ProfileFilesManager.LoadProfileData((uint)profileID);
        if (newProfile != null)
            LoadProfile(newProfile);
        else
            LoadProfile(new ProfileData());
    }

    private void SaveParametters(uint profileID)
    {
        ProfileFilesManager.SaveProfile(_currentProfile, profileID);
    }
    private void LoadProfile(ProfileData profileData)
    {
        if (profileData != null)
        {
            _currentProfile = profileData;
            UpdateHotelType(_currentProfile.hotelType);
            UpdateHotelFullness(_currentProfile.hotelFullness);
            UpdateHotelLights(_currentProfile.hotelLights);
            UpdateEvacuationType(_currentProfile.evacuationType);
            UpdateEvacuationDirection(_currentProfile.evacuationDirection);
            UpdateSmokeDuration(_currentProfile.smokeDuration);
        }
        else
        {
            Debug.Log("No profileData Available to load from menu");
        }
    }


    public uint GetCurrentProfileID()
    {
        return _currentProfileID;
    }



    public void UpdateHotelType(uint type)
    {
        _currentProfile.hotelType = type;
        if (type == 0)
        {
            hotelTypeText.text = "Haut de gamme";
        }
        else
        {
            if (type == 1)
            {
                hotelTypeText.text = "Normal";//
            }
            else
            {
                hotelTypeText.text = "Délabré";
            }
        }
        
    }
    public void UpdateHotelFullness(uint percent)
    {
        _currentProfile.hotelFullness = percent;
        hotelFullnessText.text = percent.ToString("0.#") + "%";
        hotelFullnessSlider.onValueChanged.RemoveAllListeners();
        hotelFullnessSlider.value = (percent / 10);
        FullnessSliderSubrscribe();

    }
    public void UpdateHotelLights(uint type)
    {
        _currentProfile.hotelLights = type;
        if (type == 0)
        {
            lightsTypeText.text = "Allumées";
        }
        else
        {
            lightsTypeText.text = "Éteintes";
        }
    }
    public void UpdateEvacuationType(uint type)
    {
        _currentProfile.evacuationType = type;
        if (type == 0)
        {
            evacuationTypeText.text = "Ordonnée";
        }
        else
        {
            evacuationTypeText.text = "Panique";
        }
    }
    public void UpdateEvacuationDirection(uint value)
    {
        const uint DIRECTION_NUMBER = 4;
        value %= DIRECTION_NUMBER;

        _currentProfile.evacuationDirection = value;

        switch (value)
        {
            default:
            case 0:
                evacuationDirectionText.text = "Distance";
                break;
            case 1:
                evacuationDirectionText.text = "Gauche";
                break;
            case 2:
                evacuationDirectionText.text = "Droite";
                break;
            case 3:
                evacuationDirectionText.text = "Aléatoire";
                break;
        }
    }


    public void UpdateSmokeDuration(uint seconds)
    {
        _currentProfile.smokeDuration = seconds;
        smokeSpeedText.text = seconds.ToString() + "s";
        smokeSpeedSlider.onValueChanged.RemoveAllListeners();
        smokeSpeedSlider.value = (seconds / 10);
        SmokeSliderSubrscribe();
    }


    private void FullnessSliderSubrscribe()
    {
        hotelFullnessSlider.onValueChanged.AddListener((value) =>
        {
            uint percent = (uint)Mathf.RoundToInt((value - hotelFullnessSlider.minValue) / hotelFullnessSlider.maxValue * 100);
            UpdateHotelFullness(percent);
        });
    }
    private void SmokeSliderSubrscribe()
    {
        smokeSpeedSlider.onValueChanged.AddListener((value) =>
        {
            uint seconds = (uint)Mathf.RoundToInt(value);
            if (tenTimes)
                seconds *= 10;
            UpdateSmokeDuration(seconds);
        });
    }
}
