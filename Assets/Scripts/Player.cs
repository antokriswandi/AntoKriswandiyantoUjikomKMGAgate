using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 10;
    public int MaxHP;
    private float playerPositionY;
    public static Player instance;
    private bool isAlive = true;

    [SerializeField] private GameObject peluruPrefabs;

    public event Action<int, int> OnHPChanged;
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
        }
    }
}
