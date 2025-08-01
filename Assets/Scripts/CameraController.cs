using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private const string K_moveAxisNameMouseX = "Mouse X";
    [SerializeField] private const string K_moveAxisNameMouseY = "Mouse Y";

    [SerializeField] private Transform M_player;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float smoothing = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOffset = this.transform.position - M_player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = M_player.transform.position + cameraOffset;
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
