using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int m_health;
    [SerializeField] private int m_maxHealth = 100;

    [SerializeField] private TextMeshProUGUI healthText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_health = m_maxHealth;
        healthText.text = "HP: " + m_health;
    }

    public void TakeDamage(int damage)
    {
        Mathf.Clamp(m_health -= damage,0,m_maxHealth);
        healthText.text = "HP: " + m_health;

        if(m_health <= 0)
        {
            GameManager.Instance.PlayerDeath();
        }
    }
}
