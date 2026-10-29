using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 6f;
    [SerializeField] private int addPointValur = 1;
    [SerializeField] private int danage = 5;
    [SerializeField] private bool isAlive;
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
        }
    }

    private void AttackDown()
    {
        transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);
    }
}
