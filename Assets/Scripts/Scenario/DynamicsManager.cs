using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DynamicsManager : MonoBehaviour
{
    [SerializeField] private FloorLoader floorLoader;
    [SerializeField] private DynamicsMover dynamicsMover;
    [SerializeField] private NPC_Manager NPCManager;
    [SerializeField] private Transform evacuationParent;
    [SerializeField] private IODataExporterCSV CSVExporter;
    [SerializeField] private SceneTransitionFade sceneTransitionSimple;
    [SerializeField] private MoveTo smokeMover;
    [SerializeField] private bool enableNPCAtTheBeginning = false;
    [SerializeField] private UnityEvent onEvacuationBegin;
    [SerializeField] private EndingAlertDisplayer endingAlert;
    //[SerializeField] private IODataRecorderManager dataRecorderMang;
    private ProfileData _simulatedProfile;
    private const float STEP_DELAY = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (floorLoader == null || dynamicsMover == null || NPCManager == null || evacuationParent == null || CSVExporter == null || sceneTransitionSimple == null || smokeMover == null)
        {
            Debug.LogError("Components Missing");
            Destroy(this);
        }
        _simulatedProfile = ProfileFilesManager.LoadProfileData(ProfileStorageManager.instance.GetSimulatedProfileID());
        
        Debug.Log("Start "+ProfileDataSerializer.Serialize(_simulatedProfile));
        
        ToggleFire(false);
    }
    public void LaunchBeginning()
    {
        StartCoroutine(BeggininngSequence());
    }
    public void LaunchSimulation()
    {
        StartCoroutine(SimulationSequence());
    }
    public void EndSimulation()
    {
        StartCoroutine(EndSequence());
    }
    private void ToggleFire(bool enabled)
    {
        evacuationParent.gameObject.SetActive(enabled);
    }
    IEnumerator BeggininngSequence()
    {
        
        //floorLoader.FloorLoading(_simulatedProfile.hotelType, 0, true);
        yield return new WaitForSeconds(STEP_DELAY);
        dynamicsMover.MoveToBegining();
        if (enableNPCAtTheBeginning)
        {
            SetupNPCs();
        }
    }
    IEnumerator SimulationSequence()
    {
        if (_simulatedProfile.hotelLights != 0) // If the lighs are off
        {
            //floorLoader.FloorLoading(_simulatedProfile.hotelType, _simulatedProfile.hotelLights, true); // Load new floor

        }

        yield return new WaitForSeconds(STEP_DELAY/2);
        Debug.Log("Evacuation Begin");
        ToggleFire(true);
        
        dynamicsMover.MoveToSimulation(_simulatedProfile.hotelLights);
        Debug.Log("Simulation Sequence "+ProfileDataSerializer.Serialize(_simulatedProfile));
        IODataRecorderManager.EnableAllRecorders();
        
        if (enableNPCAtTheBeginning == false)
        {
            SetupNPCs();
        }
        yield return new WaitForSeconds(STEP_DELAY/2);
        onEvacuationBegin.Invoke();


        EventManager.instance.StartAlarm();



        smokeMover.duration = _simulatedProfile.smokeDuration;
        smokeMover.BeginMoveEase();
        yield return new WaitForSeconds(STEP_DELAY / 2);

        if (_simulatedProfile.hotelLights != 0)
        {
            //floorLoader.FloorLoading(_simulatedProfile.hotelType, 0, false); // Unload new floor
            Debug.Log("Old Floor Unload");
        }
    }

    IEnumerator EndSequence()
    {
        IODataRecorderManager.DisableAllRecorders();
        CSVExporter.ExportCSVFile();


        ViewFader.instance.FadeIn();

        yield return new WaitForSeconds(ViewFader.instance.GetDuration() + 0.1f);

        dynamicsMover.MoveToEnd();

        ViewFader.instance.FadeOut();

        endingAlert.DisplayEndingAlert();



        const float WAIT_FOR_MAIN_MENU = 20;
        yield return new WaitForSeconds(WAIT_FOR_MAIN_MENU);
        const int MAIN_MENU_SCENE_ID = 0;
        sceneTransitionSimple.GoToSceneByIndex(MAIN_MENU_SCENE_ID);
        floorLoader.UnloadAll();
    }
    private void SetupNPCs()
    {
        NPCManager.ToggleNPCs(true, true);
        NPCManager.SetupNPCExits(_simulatedProfile.evacuationDirection, _simulatedProfile.evacuationType);
        NPCManager.RemoveNPCs(_simulatedProfile.hotelFullness);
        Debug.Log("NPC Loading with " + _simulatedProfile.hotelFullness +"% fullness");
    }
}
