using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int m_speed;
    [SerializeField] private int m_lookSpeed;

    private Vector3 m_moveDirection;
    private Rigidbody m_rb;


    private const string k_moveAxisNameHorizontal = "Horizontal";
    private const string k_moveAxisNameVertical = "Vertical";
    private const string k_mouseAxisNameX = "Mouse X";
    private const string k_mouseAxisNameY = "Mouse Y";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        MovePlayer();
    }

    private void Rotate()
    {
        float mouseXRotate = Input.GetAxis(k_mouseAxisNameX);
        transform.Rotate(Vector3.up, mouseXRotate * m_lookSpeed * Time.deltaTime);
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis(k_moveAxisNameHorizontal);
        float verticalMovement = Input.GetAxis(k_moveAxisNameVertical);
        m_moveDirection = new Vector3(horizontalMovement, 0, verticalMovement);
        m_moveDirection = m_moveDirection.normalized;
        transform.Translate(m_moveDirection * m_speed * Time.deltaTime);
    }
}
