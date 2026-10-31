using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 6f;
    [SerializeField] private int addPointValue = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private bool isAlive;
    private const string PELURUTAG_NAME = "Peluru";
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            AttackDown();
            OnMaxPositionY();
        }
    }

    private void AttackDown()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(PELURUTAG_NAME) && isAlive)
        {
            OnColliderWithPeluru(collision.gameObject);
        }

        if(collision.CompareTag("Player"))
        {
            OnColliderWithPlayer();
        }
    }

    public void Initialize(Player playerReference)
    {
        player = playerReference;
    }

    private void OnColliderWithPeluru(GameObject peluru)
    {
        player.AddScore(addPointValue);
        Destroy(peluru);
        Destroy(gameObject);
        isAlive = false;
    }

    private void OnMaxPositionY()
    {
        float yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, -0.1f, 0)).y;
        if(transform.position.y < yMax)
        {
            Destroy(gameObject);
            player.TakeDamage(damage);
        }
    }

    private void OnColliderWithPlayer()
    {
        player.TakeDamage(damage);
        Destroy(gameObject);
        isAlive = false;
    }
}
