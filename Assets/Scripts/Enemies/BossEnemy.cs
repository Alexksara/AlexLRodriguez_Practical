using UnityEngine;

public class BossEnemy : Enemy
{
    public override void Die()
    {
        Debug.Log("YOU WIN");
        GameManager.Instance.RestartGame();
    }

    public override void CollisionEffect()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(m_damage);
    }
}
