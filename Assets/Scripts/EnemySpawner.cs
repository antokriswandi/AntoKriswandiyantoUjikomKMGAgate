using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] private float spawninterfal = 2f;
    [SerializeField] private Player player;
    private float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawninterfal)
        {
            SpawnEnemy(Random.Range(0, enemyList.Count));
            timer = 0;
        }
    }

    private void SpawnEnemy(int enemyIndex)
    {
        float xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x;
        float xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0, 0)).x;
        float yPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        float randPosX = Random.Range(xMin, xMax);
        Vector3 spawnPosition = new Vector3(randPosX, yPos, 0);
        Instantiate(enemyList[enemyIndex], spawnPosition, Quaternion.identity).Initialize(player);
    }
}
