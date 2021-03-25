using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Contains("Ai") )
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * 3000;
        }
        if (collision.gameObject.tag.Contains("Player"))
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            collision.gameObject.GetComponent<Player>().SpeedofPlayerinz = 600;
            collision.gameObject.GetComponent<Player>().minimumspeed = 600;
            if (Soundmanager.Instance)
                Soundmanager.Instance.Playsound(Soundmanager.Instance.Playerinair);
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
           // Time.timeScale = 1;
           // Time.fixedDeltaTime = 0.02F;
            collision.gameObject.GetComponent<Player>().SpeedofPlayerinz = 150;
            collision.gameObject.GetComponent<Player>().minimumspeed = 50;

        }
    }
}
