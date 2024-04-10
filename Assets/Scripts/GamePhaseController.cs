using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    public GameObject CombatCamera;
    public ManualTurret manualTurretScript;
    public GameObject BuildCamera;
    public MusicController MusicController;
    public GameObject BuildPhaseUI;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartBuildPhase();
    }

    public void StartNextWave()
    {
        //Spawn enemies
        //Start Battle Music
        Cursor.lockState = CursorLockMode.Locked;
        BuildPhaseUI.SetActive(false);
        manualTurretScript.enabled = true;
        CombatCamera.SetActive(true);
        BuildCamera.SetActive(false);
        MusicController.StartCombatMusic();
        Globals.Phase = GamePhase.Combat;
    }

    public void EndWave()
    {
        //Stop Battle Music
        //Play Victory Sound
        StartBuildPhase();
    }

    public void StartBuildPhase()
    {
        //Allow player to build
        //Start Build Phase Music
        BuildPhaseUI.SetActive(true);
        manualTurretScript.enabled = false;
        CombatCamera.SetActive(false);
        BuildCamera.SetActive(true);
        MusicController.StartBuildMusic();
        Globals.Phase = GamePhase.Build;
    }
}
