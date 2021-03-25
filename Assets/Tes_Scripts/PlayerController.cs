//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour
//{

//    // Use this for initialization

//    // public AnimationController thisAnim;

//    // public GroupData data;
//    bool isPlayer = true;

//    Transform thisTrans;
//    Indicator indicator;
//    public PlayerMovement movementScript;
//    private void OnEnable()
//    {
//        movementScript.enabled = false;
//    }
//    void Start()
//    {
//        thisTrans = transform;
//        killedBy = "";


//    }
//    public void SetUp()
//    {
//        data = GameManager.Instance.data[0];//get data object
//        data.groupLeader = this.gameObject;

//        ChangeMaterial(data.leaderMaterial);
//    }
//    public void startPlayer()
//    {
//        data.indicatorInstance.setUpIndicator(data);
//        movementScript.enabled = true;
//        thisAnim.currentAnimState = 2;

//    }
//    public void stopPlayer()
//    {
//        movementScript.enabled = false;
//        thisAnim.currentAnimState = 0;
//    }
//    public void ChangeMaterial(Material mat)
//    {
//        foreach (var mesh in transform.GetComponentsInChildren<SkinnedMeshRenderer>())
//        {
//            mesh.material = mat;
//        }
//    }
//    // Update is called once per frame
//    void UpdateD()
//    {

//    }



//    }
//    bool isMouseDown = false;
//    int directional = -1;
//    public static string killedBy;
//}
