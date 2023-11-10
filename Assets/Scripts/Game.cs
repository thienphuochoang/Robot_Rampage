using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;
    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;
    public int enemiesLeft;
    // 1
    void Start()
    {
        singleton = this;
        StartCoroutine("increaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("updateWaveTimer");
        SpawnRobots();
    }
    // 2
    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }
    private IEnumerator updateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);
            // Spawn next wave and restart count down
            if (waveCountdown == 0)
            {
                SpawnRobots();
                waveCountdown = 30;
                gameUI.ShowNewWaveText();
            }
        }
    }
    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        // Give player bonus for clearing the wave before timer is done
        if (singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }
    public void AddRobotKillToScore()
    {
        score += 10;
        gameUI.SetScoreText(score);
    }
    IEnumerator increaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score += 1;
            gameUI.SetScoreText(score);
        }
    }
}
