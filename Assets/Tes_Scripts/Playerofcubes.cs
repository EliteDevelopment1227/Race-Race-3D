using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerofcubes : MonoBehaviour
{
    // Start is called before the first frame update;
    public float sensitivity = 0.16f;
    private float clampDelta = 20;// 42f;
    private Vector3 lastMousePos = new Vector3();
    public Rigidbody rb, camRB;
    private Vector3 CamVel;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    float wait = 0;

    public Transform target;
    public bool StopPlayerMOvement;

    private void Start()
    {

        StopPlayerMOvement = false;
    }
    void FixedUpdate()
    {
        if (!StopPlayerMOvement)
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.lastMousePos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 vector = this.lastMousePos - Input.mousePosition;
                this.lastMousePos = Input.mousePosition;
                vector = new Vector3(vector.x, 0, vector.y);
                Vector3 vector3 = Vector3.ClampMagnitude(vector, this.clampDelta);
                CamVel = Vector3.zero;
                // vector3.magnitude
                //  this.rb.AddForce(CamVel / 4.2f + (-vector3 * this.sensitivity - this.rb.velocity / 5f), ForceMode.VelocityChange);
                this.rb.velocity = transform.forward * 10;
               // rb.transform.LookAt(target);
                if (vector !=new Vector3(0, 0, 0))
                {
                    this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-vector), 10F*Time.deltaTime);
                }

               
            }
        }



    }

}
