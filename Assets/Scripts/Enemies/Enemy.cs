using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected int score;
    [SerializeField] protected NavMeshAgent navMesh;

    protected GameObject player;
    protected PlayerHealth playerHealth;
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Die();
        }

        if(player != null && health > 0 )
        {
            navMesh.SetDestination(player.transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Initialize(GameObject target)
    {
        player = target;
        playerHealth = player.GetComponent<PlayerHealth>();
        navMesh = GetComponent<NavMeshAgent>();
    }

    public virtual void Die()
    {
        ScoreManager.Instance.AddScore(score);
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
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        Destroy(this.gameObject);
    }
}
