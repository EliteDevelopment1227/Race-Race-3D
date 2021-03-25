using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelsidecolliders : MonoBehaviour
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
        if (collision.gameObject.tag.Contains("Ai"))
        {
            this.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ai"))
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}

