using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    public GameObject CombatCamera;
    public ManualTurret manualTurretScript;
    public GameObject BuildCamera;
    public MusicController MusicController;
    public GameObject BuildPhaseUI;
    public GameObject CombatPhaseUI;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI EnemiesRemainingText;
    public TextMeshProUGUI MoneyText;
    int wave = 0;
    public int EnemiesRemaining = 0;
    int money = 0;
    int enemiesToSpawn = 0;

    public List<EnemySpawn> EnemySpawnPoints = new List<EnemySpawn>();

    public Buildable SelectedBuildable = Buildable.Block;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartBuildPhase();
    }

    public void StartNextWave()
    {
        Cursor.lockState = CursorLockMode.Locked;
        BuildPhaseUI.SetActive(false);
        CombatPhaseUI.SetActive(true);
        manualTurretScript.enabled = true;
        CombatCamera.SetActive(true);
        BuildCamera.SetActive(false);
        MusicController.StartCombatMusic();
        Globals.Phase = GamePhase.Combat;

        wave++;
        SetEnemiesInWave(wave);
        SetWaveText(wave);

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].SpawnEnemy();
        enemiesToSpawn--;
        if (enemiesToSpawn > 0)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    public void EndWave()
    {
        //Stop Battle Music
        MusicController.StopMusic();
        //Play Victory Sound

        StartCoroutine(PlayVictorySound());
    }

    IEnumerator PlayVictorySound()
    {
        MusicController.PlayVictoryMusic();
        yield return new WaitForSeconds(MusicController.VictoryMusicLength);
        StartBuildPhase();
    }

    public void StartBuildPhase()
    {
        //Allow player to build
        //Start Build Phase Music
        Cursor.lockState = CursorLockMode.Locked;
        BuildPhaseUI.SetActive(true);
        CombatPhaseUI.SetActive(false);
        manualTurretScript.enabled = false;
        CombatCamera.SetActive(false);
        BuildCamera.SetActive(true);
        MusicController.StartBuildMusic();
        Globals.Phase = GamePhase.Build;

        AddMoneyForWave(wave);
    }

    public void SetWaveText(int wave)
    {
        WaveText.text = "Wave: " + wave;
    }

    public void DecrementEnemiesRemaining()
    {
        EnemiesRemaining--;
        SetEnemiesRemainingText(EnemiesRemaining);
        if (EnemiesRemaining == 0)
        {
            EndWave();
        }
    }

    public void SetEnemiesRemainingText(int enemiesRemaining)
    {
        EnemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
    }

    public void SetMoneyText(int money)
    {
        MoneyText.text = "$" + money;
    }

    public void SetEnemiesInWave(int wave)
    {
        EnemiesRemaining = 10 + wave * wave * 2;
        enemiesToSpawn = EnemiesRemaining;
        SetEnemiesRemainingText(EnemiesRemaining);
    }

    public void AddMoneyForWave(int wave)
    {
        money = 100 + wave * wave * 50;
        SetMoneyText(money);
    }

    public void SetSelectedBuildable(string buildable)
    {
        if (buildable == "Block")
        {
            SelectedBuildable = Buildable.Block;
        }
        else if (buildable == "Turret")
        {
            SelectedBuildable = Buildable.Turret;
        }
    }
}

public enum Buildable
{
    Block,
    Turret
}
