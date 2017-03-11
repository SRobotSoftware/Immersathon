using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;
    private float powerInput;
    private float turnInput;
    private Rigidbody drumRigidBody;
    // Use this for initialization
    void Awake()
    {
        drumRigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

    }
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            Debug.DrawRay(transform.position, hit.point, Color.red);
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            drumRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
        drumRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
        drumRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
    }
}