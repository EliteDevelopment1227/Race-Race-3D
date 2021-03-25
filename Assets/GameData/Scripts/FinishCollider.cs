using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int i = 0;
    // Update is called once per frame
    void Update()
    {
        
    }
    GameObject reachedchar;
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag.Contains("Ai"))
        {
            i++;
            collision.gameObject.tag = "Untagged";
           // FindObjectOfType<UIMANAGAER>().levelcompleteeffect();

        }
        if (collision.gameObject.tag == "Player")
        {
            i++;
            collision.gameObject.GetComponent<Player>().Finishlevel(i);
            FindObjectOfType<UIMANAGAER>().levelcompleteeffect();
            if (i == 1)
            {
                Debug.Log("Player First");
                collision.gameObject.tag = "Untagged";

            }
            stopcharachter();
        }

    }
    public void stopcharachter()
    {
        AiController[] ai = FindObjectsOfType<AiController>();
        Ai_2Controller[] ai2 = FindObjectsOfType<Ai_2Controller>();

        for(int i = 0; i < ai.Length; i++)
        {
            ai[i].SpeedofAi = 200;
        }
        for (int i = 0; i < ai2.Length; i++)
        {
            ai2[i].SpeedofAi = 200;
        }
    }
}
