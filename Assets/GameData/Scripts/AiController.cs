using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AiController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float SpeedofAi;
    bool onGround;
    // public float Speedofrotation;
    public Transform mycharacter;
   public bool stopAi;
    AnimationController animcontroller;
    private void Awake()
    {
        animcontroller = this.GetComponent<AnimationController>();
    }
    void Start()
    {
        stopAi = true;
        onGround = false;
        rb = GetComponent<Rigidbody>();
    }
    int centerdir = 50;
    int[] dir = new int[2] { 50, -50 };
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y < -24)
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

        if (onGround && stopAi && animcontroller.go)
        {
            this.rb.velocity = Vector3.forward * SpeedofAi;
        }
        else if(onGround && animcontroller.go)
        {
            this.rb.velocity = Vector3.forward * 100;
        }
        RaycastHit hit;

        if(Physics.Raycast(this.transform.position,Vector3.forward,out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "LeftRoadBlocker" && Vector3.Distance(this.transform.position,hit.point) < 30 && stopAi)
            {
               // this.rb.velocity = Vector3.forward * 80;
                this.transform.DORotate(new Vector3(0, 50, 0), 0.4f).OnComplete(SetDefaultrotation);
                mycharacter.DORotate(new Vector3(0, 50, 0), 0.4f);
                stopAi = false;
            }
            if (hit.collider.gameObject.tag == "CenterRoadBlocker" && Vector3.Distance(this.transform.position, hit.point) < 30 && stopAi)
            {
               // this.rb.velocity = Vector3.forward * 80;
                 this.transform.DORotate(new Vector3(0, centerdir, 0), 0.4f).OnComplete(SetDefaultrotation);
                mycharacter.transform.DORotate(new Vector3(0, centerdir, 0), 0.4f);
                stopAi = false;
            }
            if (hit.collider.gameObject.tag == "RightRoadBlocker" && Vector3.Distance(this.transform.position, hit.point) < 30 && stopAi)
            {
              //  this.rb.velocity = Vector3.forward * 80;
                this.transform.DORotate(new Vector3(0, -50, 0), 0.4f).OnComplete(SetDefaultrotation);
                mycharacter.transform.DORotate(new Vector3(0, -50, 0), 0.4f);
                stopAi = false;
            }
        }
        if (myrotate)
        {
            rotate();
         
        }
    }
    public void SetDefaultrotation()
    {
        this.transform.DORotate(new Vector3(0, 0, 0), 0.4f);
        mycharacter.transform.DORotate(new Vector3(0, 0, 0), 0.4f);
        stopAi = true;
    }
    void rotate()
    {
        rb.rotation = Quaternion.Euler(new Vector3(0, rb.transform.localEulerAngles.y, 0) + new Vector3(0, 1, 0) * 10);
        mycharacter.rotation= Quaternion.Euler(new Vector3(0, rb.transform.localEulerAngles.y, 0) + new Vector3(0, 1, 0) * 10);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            myrotate = false;
        }
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
            animcontroller.Runanimation();
        }
        if (collision.gameObject.tag == "Finishcollider")
        {
            onGround = false;
            myrotate = true;
            rb.velocity = Vector3.zero;
            animcontroller.Dance2animation();
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
    bool myrotate = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftTrigger")
        {
            stopAi = false;
            this.transform.DORotate(new Vector3(0, 30, 0), 0.3f).OnComplete(SetDefaultrotation);
            mycharacter.transform.DORotate(new Vector3(0, 30, 0), 0.3f);
            centerdir = dir[Random.Range(0, 2)];
        } if (other.gameObject.tag == "RightTrigger")
        {
            stopAi = false;
            this.transform.DORotate(new Vector3(0, -30, 0), 0.3f).OnComplete(SetDefaultrotation);
            mycharacter.transform.DORotate(new Vector3(0, -30, 0), 0.3f);
            centerdir = dir[Random.Range(0, 2)];
        }

        if (other.gameObject.tag == "leftwall")
        {
            Debug.Log("left rotate wall");
            this.rb.velocity = Vector3.zero;
            this.rb.velocity = Vector3.up * 30 + Vector3.right * 10;//, ForceMode.VelocityChange);
            myrotate = true;
            stopAi = false;
            Invoke("Startplayer", 2);

        }
        if (other.gameObject.tag == "rightwall")
        {
            Debug.Log("right rotate wall");

            this.rb.velocity = Vector3.zero;
            this.rb.velocity = Vector3.up * 30 + Vector3.left * 10;//), ForceMode.VelocityChange);
            myrotate = true;
            stopAi = false;
            Invoke("Startplayer", 2);
        }

    }
    private void Startplayer()
    {
        stopAi = true;
        this.transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        mycharacter.DORotate(new Vector3(0, 180, 0), 0.5f);
    }
}
