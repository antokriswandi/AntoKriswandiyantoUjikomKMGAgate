using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameBtn()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void CreditBtn()
    {
        SceneManager.LoadScene("Credit");
    }

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
