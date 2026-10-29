using System.Collections;
using UnityEngine;

public class Peluru : MonoBehaviour
{
    [SerializeField] private float peluruSpeed = 10f;
    private float timeToDestroySelf = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireUp();
        StartCoroutine(DestroySelfCoroutine());
    }

    private void FireUp()
    {
        transform.Translate(Vector3.up * peluruSpeed * Time.deltaTime);
    }

    IEnumerator DestroySelfCoroutine()
    {
        yield return new WaitForSeconds(timeToDestroySelf);
        Destroy(gameObject);
    }
}
