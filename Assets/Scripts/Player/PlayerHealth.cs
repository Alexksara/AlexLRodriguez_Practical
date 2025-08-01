using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int M_health;
    [SerializeField] private int M_maxHealth = 100;

    [SerializeField] private TextMeshProUGUI healthText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        M_health = M_maxHealth;
        healthText.text = "HP: " + M_health;
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(M_health -= damage,0,M_maxHealth);
        healthText.text = "HP: " + M_health;

        if(M_health <= 0)
        {
            GameManager.Instance.PlayerDeath();
        }
    }
}
