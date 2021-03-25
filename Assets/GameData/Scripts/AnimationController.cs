using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public bool go=false;
    void Start()
    {

       // animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            go = true;
            Runanimation();
        }
    }
    public void flyinganimation()
    {
        if (go)
            animator.SetTrigger("fly");
    }
    public void Runanimation()
    {
        if (go)
            animator.SetTrigger("run");
    }
    public void Dance1animation()
    {
        if (go)
            animator.SetTrigger("dance1");
    }
    public void Dance2animation()
    {
        //if (go)
          //  animator.SetTrigger("dance2");
    }
    public void Dance3animation()
    {
      //  if (go)
          //  animator.SetTrigger("dance3");
        Debug.Log("dance3" + go);
    }
    public void Dance4animation()
    {
      //  if (go)
         //   animator.SetTrigger("dance4");
    }
}
