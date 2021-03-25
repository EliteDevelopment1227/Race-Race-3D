using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBlocker : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    PlayerCharacter pc;
    void Start()
    {
        pc = FindObjectOfType<PlayerCharacter>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject obj;
    public void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Player" && !this.gameObject.name.Contains("CenterRoadBlocker"))
        {

            Debug.Log(collision.gameObject.tag);
            obj = collision.gameObject;
            obj.GetComponent<Player>().StopPlayerMOvement = false;
            obj.transform.rotation = Quaternion.Euler(obj.transform.localEulerAngles.x, 180, 0);
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
           
            obj.GetComponent<Rigidbody>().velocity = Vector3.back * 350;
            pc.setrotation();
            Invoke("HItForceend", 0.5f);
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            for(int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
            }

            if (Soundmanager.Instance)
                Soundmanager.Instance.Playsound(Soundmanager.Instance.HitObstacleSound);
        }
        if (collision.gameObject.tag=="Player" && this.gameObject.name.Contains("CenterRoadBlocker"))
        {

            obj = collision.gameObject;
            obj.GetComponent<Player>().StopPlayerMOvement = false;
            obj.transform.rotation = Quaternion.Euler(obj.transform.localEulerAngles.x, 180, 0);
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;

            obj.GetComponent<Rigidbody>().velocity = Vector3.back * 350;
            pc.setrotation();
            Invoke("HItForceend", 0.5f);
            if (Soundmanager.Instance)
                Soundmanager.Instance.Playsound(Soundmanager.Instance.HitObstacleSound);
            //  this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            // this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
    }
    float delay = 2;
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ai") && !this.gameObject.name.Contains("CenterRoadBlocker"))
        {
            //delay -= 0.2f * Time.deltaTime;
            //Debug.Log(delay);
            //if (delay < 0)
            //{
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                }
               // delay = 2;
            //}
           
        }
    }
    public void HItForceend()
    {
        obj.GetComponent<Player>().StopPlayerMOvement = true;
    }
}
