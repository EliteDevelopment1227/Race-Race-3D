using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update;


    public Rigidbody rb;
    public float SpeedofPlayerinz;
    [HideInInspector]
    public float minimumspeed = 50;
    public bool StopPlayerMOvement;
    public bool onground;
    private float rotSpeed=5000;
    private PlayerCharacter PC;
    AnimationController animcontroller;
    public GameObject particlesystem;
    private void Awake()
    {
        animcontroller = this.GetComponent<AnimationController>();
        PC = FindObjectOfType<PlayerCharacter>();
    }
    private void Start()
    {
       
        StopPlayerMOvement = true;
       
    }
    public float rotX;
    void FixedUpdate()
    {
        if (onground  && StopPlayerMOvement && animcontroller.go)
        {
            

            if (Input.GetMouseButton(0))
            {
                this.rb.velocity = Vector3.forward * SpeedofPlayerinz;
            }
            else
            {
              this.rb.velocity = Vector3.forward *minimumspeed;
            }
#if UNITY_EDITOR

            if (Input.GetMouseButton(0))
            {
                rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
                rotX = rotX * Time.deltaTime;
                PC.RotationOnY = rotX;
                transform.Rotate(new Vector3(0, rotX, 0), Space.World);
            }
#elif UNITY_ANDROID

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                float rotX = touchDeltaPosition.x * rotSpeed / 18 * Mathf.Deg2Rad;
                rotX = rotX * Time.deltaTime;
                transform.Rotate(new Vector3(0, rotX, 0), Space.World);
            }
#endif
        }
        if (myrotate)
        {
            rotate();
            PC.Rotateme();
        }
    }
   public bool myrotate = false;
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onground = true;
            rb.constraints = (RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY);
        }
        
        
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onground = false;
            particlesystem.SetActive(false);

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            myrotate = false;
            Time.timeScale = 1;
             Time.fixedDeltaTime = 0.02F;
            animcontroller.Runanimation();
            PC.setrotation();
            particlesystem.SetActive(true);
            if (!onground)
            {
               // Soundmanager.Instance.Playsound(Soundmanager.Instance.GroundHit);
                this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, 180, 0);
            }
        }
        //if (collision.gameObject.tag == "Finishcollider")
        //{
        //    onground = false;
        //    myrotate = true;
        //    animcontroller.Dance1animation();
        //    rb.velocity = Vector3.zero;
        //    Camera.main.GetComponent<SmoothFollow>().stopcamera = true;
        //}
    }
    public void Finishlevel(int i)
    {
        onground = false;
        myrotate = true;
        if (i == 1)
        {
            animcontroller.Dance1animation();
        }
        else
        {
            Debug.Log("sadanim");
        }
        rb.velocity = Vector3.zero;
        Camera.main.GetComponent<SmoothFollow>().stopcamera = true;
    }
   
    void rotate()
    {
        rb.rotation = Quaternion.Euler(new Vector3(0, rb.transform.localEulerAngles.y, 0) + new Vector3(0,1,0) *10);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "leftwall")
        {
            this.rb.velocity = Vector3.zero;
            this.rb.velocity = Vector3.up * 30 + Vector3.right * 4;//, ForceMode.VelocityChange);
            myrotate = true;
            StopPlayerMOvement = false;
            Invoke("Startplayer", 2);

        }
        if (other.gameObject.tag == "rightwall")
        {
            this.rb.velocity = Vector3.zero;
            this.rb.velocity = Vector3.up * 30 + Vector3.left * 4;//), ForceMode.VelocityChange);
            myrotate = true;
            StopPlayerMOvement = false;
            Invoke("Startplayer", 2);
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rightwall" || other.gameObject.tag == "leftwall")
        {
            _1set();
        }
    }
    private void Startplayer()
    {
        StopPlayerMOvement = true;
        this.transform.DORotate(new Vector3(transform.eulerAngles.x, 180, 0), 0.5f);
        PC.setrotation();
    }
    private void _1set()
    {
        this.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

    }
}
