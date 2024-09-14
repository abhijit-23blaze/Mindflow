using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [Header("Player Visualization")]
    [SerializeField] private Transform playerVisual;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;

    [Header("Ground Check")]
    [SerializeField] private float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    private bool _grounded;


    [SerializeField] private Transform orientation;

    private float _horizontalInput;
    private float _vertivalInput;


    private Vector3 _moveDirection;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerVisual.GetComponent<MeshRenderer>().enabled = false;
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void Update()
    {
        // ground check
        _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);


        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _vertivalInput = Input.GetAxisRaw("Vertical");
        SpeedControl();


        if (_grounded)
        {
            _rb.drag = groundDrag;
        }
        else 
        {
            _rb.drag = 0;
        }
    }

    private void FixedUpdate() 
    {
        _moveDirection = orientation.forward * _vertivalInput + orientation.right * _horizontalInput;

        _rb.AddForce(10f * moveSpeed * _moveDirection.normalized, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }
}
