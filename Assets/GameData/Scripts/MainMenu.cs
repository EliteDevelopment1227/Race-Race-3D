using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fillbar;
    public float speedoffiling;
    void Start()
    {
        
    }
    float fill1amout;
    // Update is called once per frame
    void Update()
    {
         fill1amout += 0.5f * Time.deltaTime;
        if (fill1amout <= 1)
        {
            fillbar.fillAmount = fill1amout;
        }
        else
        {
            Debug.Log(fill1amout);
            SceneManager.LoadScene("1");
        }
        
    }
}
