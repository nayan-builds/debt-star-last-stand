using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    void StartNextWave()
    {
        //Spawn enemies
        //Start Battle Music

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
    }
}
