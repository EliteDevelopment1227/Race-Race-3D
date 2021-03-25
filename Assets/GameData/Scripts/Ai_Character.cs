using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Character : MonoBehaviour
{

    public Transform AiPlayer;
    //  public float RotationOnY;
    UIMANAGAER ui;
    private void Awake()
    {
       
    }
    void Start()
    {
        ui = FindObjectOfType<UIMANAGAER>();
        GameObject crow = Instantiate(ui.aicrown, new Vector3(this.transform.position.x, ui.aicrown.transform.position.y, this.transform.position.z), ui.aicrown.transform.rotation);
        crow.transform.SetParent(this.transform);
        crow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = AiPlayer.position + new Vector3(0, 1.1f, 0);
    }
   
    
}
