using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timer = 10;
    [SerializeField] private Image timerBar;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text scoreTextFinal;
    private float maxTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerBar.fillAmount = 1;
        maxTimer = timer;
        gameOverPanel.SetActive(false);
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
        InisiateGameOver();
    }

    private void UpdateTimerBar()
    {
        float normalized = (float) timer / maxTimer;
        timerBar.fillAmount = normalized;
    }

    public void InisiateGameOver()
    {
        hudPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        scoreTextFinal.text = "Score: "+player.score;
        Destroy(enemySpawner);
        Destroy(player);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
