using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VacuumShaders.CurvedWorld;
using DG.Tweening;
public class Curvecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    // public curv
   private CurvedWorld_Controller CC;
    void Start()
    {
        CC = this.gameObject.GetComponent<CurvedWorld_Controller>();
        CC.pivotPoint = FindObjectOfType<Player>().transform;
        InvokeRepeating("ChangeCurve", 0,10);
      //  ChangeCurve();
    }

    // Update is called once per frame
    bool left=false,right=false,up=false,down = false;
    float lerp = 0;
    float X_Bend, X_Bias, Y_Bend, Y_Bias;
    float duration =200;
    private void Update()
    {
        if(Input.GetMouseButton(0))
            lefturn();
       //  RightTurn();
       // UpTurn();
       // DownTurn();
    }
    float temp1, temp2, temp3, temp4;
    void ChangeCurve()
    {
        int curv = Random.Range(0, 9);
        left = true;

        switch (curv)
        {
            case 0:
                {
                    
                    temp1 = 0;// CC._V_CW_Bend_X;
                    temp2 = 0;// CC._V_CW_Bias_X;
                    temp3 =  CC._V_CW_Bend_Y;
                    temp4 =  CC._V_CW_Bias_Y;

                    X_Bend = 0;
                    X_Bias = 0;
                    Y_Bend = 20;
                    Y_Bias = 100;
                   
                    lerp = 0;
                }
                 break;
            case 1:
                {
                    temp1 = CC._V_CW_Bend_X;
                    temp2 = CC._V_CW_Bias_X;
                    temp3 = CC._V_CW_Bend_Y;
                    temp4 = CC._V_CW_Bias_Y;

                    X_Bend = 0;
                    X_Bias = 0;
                    Y_Bend = 20;
                    Y_Bias = 100;

                    lerp = 0;
                }
                break;
            case 2:
                {
                    temp1 = 0;// CC._V_CW_Bend_X;
                    temp2 = 0;// CC._V_CW_Bias_X;
                    temp3 =  CC._V_CW_Bend_Y;
                    temp4 =  CC._V_CW_Bias_Y;

                    X_Bend = 0;
                    X_Bias = 0;
                    Y_Bend = -20;
                    Y_Bias = 100;
                   
                    lerp = 0;
                }
                break;
            case 3:
                {
                    temp1 = CC._V_CW_Bend_X;
                    temp2 =  CC._V_CW_Bias_X;
                    temp3 =  CC._V_CW_Bend_Y;
                    temp4 =  CC._V_CW_Bias_Y;

                    X_Bend = 0;
                    X_Bias = 0;
                    Y_Bend = -20;
                    Y_Bias = 100;
                   
                    lerp = 0;
                }
                break;
            case 4:
                {
                    temp1 =  CC._V_CW_Bend_X;
                    temp2 =  CC._V_CW_Bias_X;
                    temp3 = 0;// CC._V_CW_Bend_Y;
                    temp4 = 0;// CC._V_CW_Bias_Y;

                    X_Bend = -9;
                    X_Bias = 100;
                    Y_Bend = 0;
                    Y_Bias = 0;

                    lerp = 0;
                }
                break;
            case 5:
                {
                    temp1 =  CC._V_CW_Bend_X;
                    temp2 =  CC._V_CW_Bias_X;
                    temp3 =  CC._V_CW_Bend_Y;
                    temp4 = CC._V_CW_Bias_Y;

                    X_Bend = -9;
                    X_Bias = 100;
                    Y_Bend = 0;
                    Y_Bias = 0;

                    lerp = 0;
                }
                break;
            case 6:
                {
                    temp1 = CC._V_CW_Bend_X;
                    temp2 = CC._V_CW_Bias_X;
                    temp3 = 0;// CC._V_CW_Bend_Y;
                    temp4 = 0;// CC._V_CW_Bias_Y;

                    X_Bend = 9;
                    X_Bias = 100;
                    Y_Bend = 0;
                    Y_Bias = 0;

                    lerp = 0;
                }
                break;
            case 7:
                {
                    temp1 = CC._V_CW_Bend_X;
                    temp2 = CC._V_CW_Bias_X;
                    temp3 =  CC._V_CW_Bend_Y;
                    temp4 =  CC._V_CW_Bias_Y;

                    X_Bend = 9;
                    X_Bias = 100;
                    Y_Bend = 0;
                    Y_Bias = 0;

                    lerp = 0;
                }
                break;

            case 8:
                {
                    //temp1 = CC._V_CW_Bend_X;
                    //temp2 = CC._V_CW_Bias_X;
                    //temp3 = CC._V_CW_Bend_Y;
                    //temp4 = CC._V_CW_Bias_Y;

                    //X_Bend = 0;
                    //X_Bias = 0;
                    //Y_Bend = 0;
                    //Y_Bias = 0;

                    //lerp = 0;
                }
                break;
        }
        
    }

    public void lefturn()
    {
        lerp += Time.deltaTime                                                                                                                                                        / duration;
        if (left)
        {
                CC._V_CW_Bend_X = Mathf.Lerp(temp1, X_Bend, lerp);
                CC._V_CW_Bias_X = Mathf.Lerp (temp2,X_Bias, lerp);
                CC._V_CW_Bend_Y = Mathf.Lerp( temp3, Y_Bend, lerp);
                CC._V_CW_Bias_Y = Mathf.Lerp( temp4, Y_Bias, lerp);
        }
    }
    public void RightTurn()
    {
        if (right)
        {
            if (CC._V_CW_Bend_X != 0)
            {
                CC._V_CW_Bend_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_X != 0)
            {
                CC._V_CW_Bias_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bend_Y != 0)
            {
                CC._V_CW_Bend_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_Y != 0)
            {
                CC._V_CW_Bias_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else
            {
                right = false;
                lerp = 0;
            }
        }
    }
    public void UpTurn()
    {
        if (up)
        {
            if (CC._V_CW_Bend_X != 0)
            {
                CC._V_CW_Bend_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_X != 0)
            {
                CC._V_CW_Bias_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bend_Y != 0)
            {
                CC._V_CW_Bend_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_Y != 0)
            {
                CC._V_CW_Bias_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else
            {
                up = false;
                lerp = 0;
            }
        }
    }
    public void DownTurn()
    {
        if (down)
        {
            if (CC._V_CW_Bend_X != 0)
            {
                CC._V_CW_Bend_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_X != 0)
            {
                CC._V_CW_Bias_X = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bend_Y != 0)
            {
                CC._V_CW_Bend_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else if (CC._V_CW_Bias_Y != 0)
            {
                CC._V_CW_Bias_Y = Mathf.Lerp(CC._V_CW_Bend_X, 0, lerp);
            }
            else
            {
                down = false;
                lerp = 0;
            }
        }
    }
}
