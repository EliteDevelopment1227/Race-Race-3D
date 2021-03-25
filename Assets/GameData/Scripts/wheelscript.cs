using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelscript : MonoBehaviour
{
    public WheelCollider rearWheel1;
    Rigidbody rb;
    public Transform com;
    public WheelCollider frontWheel1;
    float steer_max = 20;
    float motor_max = 5;
    float brake_max = 100;

    private float steer = 0;
    private float motor = 0;
    private float brake = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    //steer = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        //    //  motor = Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1);
        //  //  brake = -1 * Mathf.Clamp(Input.GetAxis("Mouse Y"), -1, 0);
        //    Debug.Log(steer);
        //    rearWheel1.motorTorque = motor_max * motor;
        //    frontWheel1.steerAngle = steer_max * steer;
        //}

        rearWheel1.motorTorque = motor_max * 1;
        rb.centerOfMass = com.position;
    }
}
