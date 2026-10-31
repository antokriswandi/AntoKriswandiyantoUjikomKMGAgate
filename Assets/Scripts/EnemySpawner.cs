using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // karena prefabs enemy ada 3, jadi kita bikin pake list!
    [SerializeField] private List<Enemy> enemyList = new List<Enemy>();

    // variabel buat ngatur berapa detik sekali enemy dispawn
    [SerializeField] private float spawninterfal = 2f; // set defaultnya 2 detik

    // referensi object player, kita butuh buat jalanin fungsi TakeDamage sama AddScrore
    [SerializeField] private Player player;

    // set timer dimulai dari 0
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime; // timer bertambah 1 setiap detik
        if(timer >= spawninterfal) // jika timer udah lebih dari spawn interfal
        {
            SpawnEnemy(Random.Range(0, enemyList.Count)); // spawn musuh (indexnya dirandom)
            timer = 0; // set timer balik ke 0
        }
    }

    // fungsi ngespawn musuh
    private void SpawnEnemy(int enemyIndex)
    {
        // ngebatesin sisi kiri layar biar musuh ga dispawn mepet dipinggir, kita kasih jarak 5% dari batas kiri layar.
        float xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0, 0)).x;

        // ngebatesin sisi kanan layar, kita kasih jarak 5% dari batas kanan layar, biar musuh ga mepet frame
        float xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0, 0)).x;

        // ini biar musuh dispawn tepat digaris atas frame
        float yPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        // kita random posisi x nya, set batas paling kiri dan paling kanan
        float randPosX = Random.Range(xMin, xMax);

        // gabungin jadi vector 3
        Vector3 spawnPosition = new Vector3(randPosX, yPos, 0);

        // spawn, sambil kirim referensi object player ke prefabs enemy yg dispawn
        // teknik ini namanya Dependency Injection (kata AI)
        Instantiate(enemyList[enemyIndex], spawnPosition, Quaternion.identity).Initialize(player);
    }
}
