using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timer = 10;
    [SerializeField] private Image timerBar;
    private float maxTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerBar.fillAmount = 1;
        maxTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        StartCoroutine(TimerGame());
        UpdateTimerBar();
    }

    IEnumerator TimerGame()
    {
        yield return new WaitForSeconds(timer);
        Debug.Log("Waktu Habis!!");
    }

    private void UpdateTimerBar()
    {
        float normalized = (float) timer / maxTimer;
        timerBar.fillAmount = normalized;
    }
}
