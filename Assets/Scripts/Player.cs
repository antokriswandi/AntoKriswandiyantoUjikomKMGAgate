using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 10; // darah player
    public int MaxHP; // simpan max HP, digunakan untuk menghitung persentase bar HP
    private float playerPositionY; // untuk menyimpan posisi Y player saat ini
    private bool isAlive = true; // untuk menyimpan bool player hidup atau mati
    public int score = 0; // data score disimpan diplayer karena kepepet, harusnya di score manager

    [SerializeField] private GameObject peluruPrefabs; // prefabs peluru
    [SerializeField] private GameManager gameManager; // prefabs game manager (buat bar HP dan timer)
    [SerializeField] private AudioSource audioSource; // audio source khusus player
    [SerializeField] private AudioClip attackSfx; // clip SFX attack

    public event Action<int, int> OnHPChanged; // inisiate event buat bar HP (disubs sama game manager)
    public event Action OnScoreChanged; // inisiate event buat score (disubs sama ScoreUIManager)

    void Start()
    {
        playerPositionY = transform.position.y; // ambil posisi Y player saat ini
        MaxHP = HP;
    }

    void Update()
    {
        PlayerMovement(); // gerakin player pake cursor mouse
        Fire(); // tembak rezim
        CheckDie(); // masih idup?
    }

    // fungsi buat gerakin player pake cursor mouse
    private void PlayerMovement()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //ambil data posisi cursor
        transform.position = new Vector3(mousePosition.x, playerPositionY, 0); // ubah posisi player berdasarkan posisi cursor mouse
    }

    // fungsi ngespawn prefabs peluru
    private void Fire()
    {
        // kalo mouse kiri di klick
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(peluruPrefabs, transform.position, Quaternion.identity); //spawn peluru di posisi player
            audioSource.PlayOneShot(attackSfx); // play SFX
        }
        // ! fungsi ini hanya untuk spawn peluru di posisi player,
        // ! buat fungsi peluru bergerak ke atas ada di script Peluru.cs
    }

    // fungsi ngurangi darah
    public void TakeDamage(int damage)
    {
        // kalo player masih hidup
        if(isAlive)
        {
            HP -= damage; // darah berkurang berdasarkan damage enemy (nilai damage dikiri dari Class Enemy)
            OnHPChanged?.Invoke(HP, MaxHP); // jika event OnHPChanged nggak null (disubs sama class lain), invoke + kirim data HP dan maxHP!
        }
    }

    // cek apakah masih idup
    private void CheckDie()
    {   
        // kalo darah kurang dari 0
        if(HP <= 0)
        {
            isAlive = false; // matiin
            Destroy(gameObject); // gameobject player dihapus dari hirarki
            gameManager.InisiateGameOver(); // munculin panel game over dari class GameManager
        }
    }

    // fungsi buat tambah point (ini harusnya bikin class terpisah)
    public void AddScore(int pointValue)
    {
        score += pointValue; // tambahin score berdasarkan point enemy (data point dikirim dari class Enemy)
        OnScoreChanged?.Invoke(); // kalo OnScoreChange nggak null (disubs sama class ScoreUIManager), invoke!
    }
}
