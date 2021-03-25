using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VacuumShaders.CurvedWorld;

public class Instatiator : MonoBehaviour
{
    // Start is called before the first frame update
    public List< GameObject> InstatiateObject=new List<GameObject>();
    public int chunkSize;
    void Start()
    {
        //InvokeRepeating("StartInstiate", 0, 15);
        StartInstiate();
    }

    // Update is called once per frame
    void StartInstiate()
    {
        for(int i = 0; i < InstatiateObject.Count; i++)
        {
            GameObject obj = (GameObject)Instantiate(InstatiateObject[i]);

            obj.transform.position = new Vector3(0, 0, i * chunkSize);
        }
    }
}
