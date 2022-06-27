using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DynamicsManager : MonoBehaviour
{
    [SerializeField] private FloorLoader floorLoader;
    [SerializeField] private DynamicsMover dynamicsMover;
    [SerializeField] private NPC_Manager NPCManager;
    [SerializeField] private Transform fireParent;
    [SerializeField] private IODataExporterCSV CSVExporter;
    [SerializeField] private SceneTransitionSimple sceneTransitionSimple;
    [SerializeField] private MoveTo smokeMover;
    [SerializeField] private bool enableNPCAtTheBeginning = false;
    [SerializeField] private UnityEvent onEvacuationBegin;
    private ProfileData _simulatedProfile;
    private const float STEP_DELAY = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (floorLoader == null || dynamicsMover == null || NPCManager == null || fireParent == null || CSVExporter == null || sceneTransitionSimple == null || smokeMover == null)
        {
            Debug.LogError("Components Missing");
            Destroy(this);
        }
        _simulatedProfile = ProfileFilesManager.LoadProfileData(ProfileStorageManager.instance.GetSimulatedProfileID());
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
        fireParent.gameObject.SetActive(enabled);
    }
    IEnumerator BeggininngSequence()
    {
        floorLoader.FloorLoading(_simulatedProfile.hotelType, 0, true);
        yield return new WaitForSeconds(STEP_DELAY);
        dynamicsMover.MoveToBegining(_simulatedProfile.hotelType);
        if (enableNPCAtTheBeginning)
        {
            SetupNPCs();
        }
    }
    IEnumerator SimulationSequence()
    {
        if (_simulatedProfile.hotelLights != 0) // If the lighs are off
        {
            floorLoader.FloorLoading(_simulatedProfile.hotelType, _simulatedProfile.hotelLights, true); // Load new floor

        }

        yield return new WaitForSeconds(STEP_DELAY/2);
        Debug.Log("Evacuation Begin");
        ToggleFire(true);
        
        dynamicsMover.MoveToSimulation(_simulatedProfile.hotelType, _simulatedProfile.hotelLights);
        IODataRecorderManager.EnableAllRecorders();
        
        if (enableNPCAtTheBeginning == false)
        {
            SetupNPCs();
        }
        yield return new WaitForSeconds(STEP_DELAY/2);
        onEvacuationBegin.Invoke();
        EventManager.instance.StartEvacuation();
        smokeMover.duration = _simulatedProfile.smokeDuration;
        smokeMover.BeginMoveEase();
        yield return new WaitForSeconds(STEP_DELAY / 2);

        if (_simulatedProfile.hotelLights != 0)
        {
            floorLoader.FloorLoading(_simulatedProfile.hotelType, 0, false); // Unload new floor
            Debug.Log("Old Floor Unload");
        }
    }

    IEnumerator EndSequence()
    {
        IODataRecorderManager.DisableAllRecorders();
        dynamicsMover.MoveToEnd();
        floorLoader.UnloadAll();
        CSVExporter.ExportCSVFile();
        const float WAIT_FOR_MAIN_MENU = 20;
        yield return new WaitForSeconds(WAIT_FOR_MAIN_MENU);
        const int MAIN_MENU_SCENE_ID = 0;
        sceneTransitionSimple.GoToSceneByIndex(MAIN_MENU_SCENE_ID);
    }
    private void SetupNPCs()
    {
        NPCManager.ToggleNPCs(true, true);
        NPCManager.SetupNPCExits(_simulatedProfile.evacuationDirection, _simulatedProfile.evacuationType);
        NPCManager.RemoveNPCs(_simulatedProfile.hotelFullness);
        Debug.Log("NPC Loading");
    }
}
