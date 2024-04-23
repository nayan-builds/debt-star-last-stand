using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public MusicController MusicController;

    void Start()
    {
        MusicController = GameObject.Find("Music Controller").GetComponent<MusicController>();
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        MusicController.StartBuildMusic();
        SceneManager.LoadScene(0);
    }
}
