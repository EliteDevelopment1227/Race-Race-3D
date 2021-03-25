using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float MovingSpeed;
    void Start()
    {
        MovingSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, 0, -1 * MovingSpeed * Time.deltaTime));
    }
}
