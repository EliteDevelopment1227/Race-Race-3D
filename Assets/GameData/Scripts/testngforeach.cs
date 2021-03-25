using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testngforeach : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> cubes = new List<Transform>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = FindObjectOfType<Player>().transform.position - new Vector3(0, 0, 20);
    }
   
}
