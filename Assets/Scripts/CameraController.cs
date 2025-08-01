using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform M_player;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float smoothing = 5f;
    [SerializeField] private int speed = 20;

    private Vector3 M_rotation = Vector3.zero;
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
