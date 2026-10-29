using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    [SerializeField] private Image HPBar;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HPBar.fillAmount = 1;
        player.OnHPChanged += UpdateHPBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHPBar(int HP, int MaxHp)
    {
        float normalized = (float) HP / MaxHp;
        HPBar.fillAmount = normalized;
    }
}
