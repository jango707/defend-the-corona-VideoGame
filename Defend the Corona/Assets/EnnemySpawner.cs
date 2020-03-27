using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject ennemyPrefab;
    private GameObject[] spawnPoints;

    public Text scoreText;
    public static int score;

    public static float timeBtwnSpawns;
    private float timer;

    private void Start()
    {
        timeBtwnSpawns = 2f;
        timer = 0;

        score = 0;
        spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        
    }
    void Update()
    {
        timer -= Time.fixedDeltaTime;
        scoreText.text = "Score: " + score;
        
        if(timer <= 0)
        {
            SpawnEnnemy();
            if (score < 2000) timer = timeBtwnSpawns - (score / 1000);
            else timer = 0.8f;
        }
        
    }

    private void SpawnEnnemy()
    {
        var random = new UnityEngine.Random();
        int i = Random.Range(0, spawnPoints.Length);
        GameObject ennemy = Instantiate(ennemyPrefab, spawnPoints[i].transform);
    }
}
