using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int M_speed;

    private Vector3 M_moveDirection;
    private Rigidbody M_rb;


    private const string K_moveAxisNameHorizontal = "Horizontal";
    private const string K_moveAxisNameVertical = "Vertical";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        M_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxisRaw(K_moveAxisNameHorizontal);
        float verticalMovement = Input.GetAxisRaw(K_moveAxisNameVertical);

        M_moveDirection.Set(horizontalMovement, 0, verticalMovement);

        M_moveDirection = M_moveDirection.normalized * M_speed * Time.deltaTime;

        M_rb.MovePosition((this.transform.position + M_moveDirection));
    }
}
