using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int HP;
    public int MaxHP;
    private float playerPositionY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPositionY = transform.position.y;
        MaxHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 mousePosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, playerPositionY, 0);
    }
}
