using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private string enemyTag = "Enemy";

    [SerializeField] private TextMeshProUGUI healthText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthText.text = "HP: " + health;
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(health -= damage,0,maxHealth);
        healthText.text = "HP: " + health;

        if(health <= 0)
        {
            GameManager.Instance.PlayerDeath();
        }
    }
}
