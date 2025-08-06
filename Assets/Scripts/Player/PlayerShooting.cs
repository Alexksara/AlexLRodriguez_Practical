using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bulletInstance = Instantiate(m_bulletPrefab, this.transform.position,this.transform.rotation);
        bulletInstance.GetComponent<Bullet>().Initialize();
    }
}
