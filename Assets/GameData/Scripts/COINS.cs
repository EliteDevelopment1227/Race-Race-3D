using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COINS : MonoBehaviour
{
    UIMANAGAER UI;
    public Transform target;
    bool move = false;
    bool test = true;
    void Start()
    {
        UI = FindObjectOfType<UIMANAGAER>();

    }
    void FixedUpdate()
    {
        //if (test)
        //{

        //    Vector3 screenPoint = UI.coins.transform.position + new Vector3(0, 0, 5);  //the "+ new Vector3(0,0,5)" ensures that the object is so close to the camera you dont see it
        //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
        //    target.position = worldPos;
        //    //test = false;
        //}
        //if (move)
        //{
        //    Vector3 screenPoint = UI.coins.transform.position + new Vector3(0, 0, 5);  //the "+ new Vector3(0,0,5)" ensures that the object is so close to the camera you dont see it
        //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
        //    transform.localScale = this.transform.localScale / 1.5f;
        //    transform.position = Vector3.MoveTowards(transform.position, worldPos, 50 * Time.deltaTime);

        //}
    }
    void Update()
    {
        
    }
    public GameObject particleeffect;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIMANAGAER.coin++;
            UI.Coinstext.text = "" + UIMANAGAER.coin;
            PlayerPrefs.SetInt("coin", UIMANAGAER.coin);
            if(Soundmanager.Instance)
                Soundmanager.Instance.Playsound(Soundmanager.Instance.Coincollect);
        }
        
       GameObject effect= Instantiate(UI.coingeffect, this.transform.position, UI.coingeffect.transform.rotation);
        Destroy(effect, 0.2f);
        Destroy(this.gameObject);
    }
}
