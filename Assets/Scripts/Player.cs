using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public int MaxHP;
    private float playerPositionY;
    public static Player instance;

    [SerializeField] private GameObject peluruPrefabs;
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
}
