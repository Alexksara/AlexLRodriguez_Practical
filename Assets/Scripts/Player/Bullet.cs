using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private int damage = 10;

    public void Initialize()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
        Debug.Log("shooting");
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }    
        Destroy(this.gameObject);
    }
}
