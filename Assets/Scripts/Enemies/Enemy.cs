using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int m_health;
    [SerializeField] protected float m_speed;
    [SerializeField] protected int m_damage;
    [SerializeField] protected int m_score;
    protected NavMeshAgent m_navMesh;

    protected GameObject player;
    protected PlayerHealth playerHealth;
    // Update is called once per frame
    void Update()
    {
        if(m_health <= 0)
        {
            Die();
        }

        if(player != null && m_health > 0 )
        {
            m_navMesh.SetDestination(player.transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        m_health -= damage;
    }

    public void Initialize(GameObject target)
    {
        player = target;
        playerHealth = player.GetComponent<PlayerHealth>();
        m_navMesh = GetComponent<NavMeshAgent>();
    }

    public virtual void Die()
    {
        ScoreManager.Instance.AddScore(m_score);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(" collision");
        if (collision.gameObject.transform == player.transform)
        {
            CollisionEffect();
            Debug.Log("player collision");
        }
    }



    public virtual void CollisionEffect()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(m_damage);
        Destroy(this.gameObject);
    }
}
