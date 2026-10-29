using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 10;
    public int MaxHP;
    private float playerPositionY;
    public static Player instance;
    private bool isAlive = true;
    public int score = 0;

    [SerializeField] private GameObject peluruPrefabs;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attackSfx;

    public event Action<int, int> OnHPChanged;
    public event Action OnScoreChanged;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerPositionY = transform.position.y;
        MaxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Fire();
        CheckDie();
    }

    private void PlayerMovement()
    {
        Vector3 mousePosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, playerPositionY, 0);
    }

    private void Fire()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(peluruPrefabs, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(attackSfx);
        }
    }

    public void TakeDamage(int damage)
    {
        if(isAlive)
        {
            HP -= damage;
            OnHPChanged?.Invoke(HP, MaxHP);
            Debug.Log("HP sisa: "+HP+"/"+MaxHP);
        }
    }

    private void CheckDie()
    {
        if(HP <= 0)
        {
            isAlive = false;
            Destroy(gameObject);
            gameManager.InisiateGameOver();
        }
    }

    public void AddScore(int pointValue)
    {
        score += pointValue;
        OnScoreChanged?.Invoke();
    }
}
