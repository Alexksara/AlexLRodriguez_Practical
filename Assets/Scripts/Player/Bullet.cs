using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int M_speed = 5;
    [SerializeField] private int M_damage = 10;

    public void Initialize()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * M_speed, ForceMode.Impulse);
        Debug.Log("shooting");
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(M_damage);
        }    
        Destroy(this.gameObject);
    }
}
