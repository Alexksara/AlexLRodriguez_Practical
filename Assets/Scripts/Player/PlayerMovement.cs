using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private float smoothing = 5f;


    [SerializeField] private int groundLayer = 3;
    [SerializeField] private float rayDistance = 100f;

    private Vector3 M_rotation;
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
        RotatePlayer();
        MovePlayer();
    }


    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxisRaw(K_moveAxisNameHorizontal);
        float verticalMovement = Input.GetAxisRaw(K_moveAxisNameVertical);

        M_moveDirection.Set(horizontalMovement, 0, verticalMovement);

        M_moveDirection = M_moveDirection.normalized * speed * Time.deltaTime;

        M_rb.MovePosition((this.transform.position + M_moveDirection));
    }

    private void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,rayDistance,groundLayer))
        {
            Vector3 rotateVector = hit.point -transform.position;
            rotateVector.y = 0;
            Quaternion playerRotation = Quaternion.LookRotation(rotateVector);
            M_rb.MoveRotation(playerRotation);
        }
    }
}
