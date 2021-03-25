using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Tempai : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerMovement pm;
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    //    if (Vector3.Distance(this.transform.position, pm.transform.position) < 20)
    //    {
    //        this.GetComponent<NavMeshAgent>().SetDestination(pm.transform.position);
    //    }
    }
}
