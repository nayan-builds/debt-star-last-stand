using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    public GameObject CombatCamera;
    public ManualTurret manualTurretScript;
    public GameObject BuildCamera;
    public MusicController MusicController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartBuildPhase();
    }

    void StartNextWave()
    {
        //Spawn enemies
        //Start Battle Music
        manualTurretScript.enabled = true;
        CombatCamera.SetActive(true);
        BuildCamera.SetActive(false);
        MusicController.StartCombatMusic();
        Globals.Phase = GamePhase.Combat;
    }

    void EndWave()
    {
        //Stop Battle Music
        //Play Victory Sound
        StartBuildPhase();
    }

    void StartBuildPhase()
    {
        //Allow player to build
        //Start Build Phase Music
        manualTurretScript.enabled = false;
        CombatCamera.SetActive(false);
        BuildCamera.SetActive(true);
        MusicController.StartBuildMusic();
        Globals.Phase = GamePhase.Build;
    }
}
