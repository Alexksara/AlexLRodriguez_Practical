using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputAction M_inputs;
    [SerializeField] private int speed;
    [SerializeField] private float smoothing = 5f;

    private Vector3 M_rotation;
    private Vector3 M_moveDirection;
    private Rigidbody M_rb;


    [SerializeField] private const string K_moveAxisNameHorizontal = "Horizontal";
    [SerializeField] private const string K_moveAxisNameVertical = "Vertical";
    [SerializeField] private const string K_moveAxisNameMouseX = "Mouse X";
    [SerializeField] private const string K_moveAxisNameMouseY = "Mouse Y";

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

        M_moveDirection.Set(verticalMovement, 0, horizontalMovement);

        M_moveDirection = M_moveDirection.normalized * speed * Time.deltaTime;

        M_rb.MovePosition((this.transform.position + M_moveDirection));
    }

    //private void RotatePlayer()
    //{
    //    float mouseX = Input.GetAxisRaw(K_moveAxisNameMouseX);
    //    float mouseY = Input.GetAxisRaw(K_moveAxisNameMouseY);

    //    M_rotation.Set(mouseX, mouseY,0f);

    //    M_rotation = M_rotation.normalized * speed * Time.deltaTime;

    //    this.transform.rotation = Vector3.Lerp(this.transform.rotation, M_rotation, smoothing * Time.deltaTime);
    //}

}
