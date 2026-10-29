using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.OnScoreChanged += UpdateScoreUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: "+player.score;
    }
}
