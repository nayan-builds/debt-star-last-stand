using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePhaseController : MonoBehaviour
{
    public MusicController MusicController;
    public ShopController Shop;
    public GameObject CombatCamera;
    public ManualTurret ManualTurretScript;
    public GameObject BuildCamera;
    public GameObject BuildPhaseUI;
    public GameObject CombatPhaseUI;
    public TextMeshProUGUI WaveText;
    public TextMeshProUGUI EnemiesRemainingText;
    int wave = 0;
    public int EnemiesRemaining = 0;
    int enemiesToSpawn = 0;

    public List<EnemySpawn> EnemySpawnPoints = new List<EnemySpawn>();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MusicController = GameObject.Find("Music Controller").GetComponent<MusicController>();
        StartBuildPhase();
    }

    public void StartNextWave()
    {
        Cursor.lockState = CursorLockMode.Locked;
        BuildPhaseUI.SetActive(false);
        CombatPhaseUI.SetActive(true);
        ManualTurretScript.enabled = true;
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
        ManualTurretScript.enabled = false;
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

    public void SetEnemiesInWave(int wave)
    {
        EnemiesRemaining = 10 + wave * wave * 2;
        enemiesToSpawn = EnemiesRemaining;
        SetEnemiesRemainingText(EnemiesRemaining);
    }

    public void AddMoneyForWave(int wave)
    {
        //5% interest
        Shop.Money = Mathf.CeilToInt(100 + wave * wave * 50 + Shop.Money * 0.05f);
        Shop.UpdateMoneyText();
    }


}


