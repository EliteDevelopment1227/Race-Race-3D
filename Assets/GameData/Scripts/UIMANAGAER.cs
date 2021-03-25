using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMANAGAER : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coingeffect;
    public GameObject fireparticle, winparticle;
    private FinishCollider finishcollider;

    public Text Coinstext, leveltext, ranktext;
    public Image fillbar;
    private Player Player;
    float currentpos, endpos;
    private RankingSystem MyrankingSystem;
    public GameObject playercrown, aicrown;
    public GameObject levelcompletepannel;
    public  static int coin;
    public GameObject Help;
    void Start()
    {
        Player = FindObjectOfType<Player>();
        finishcollider = FindObjectOfType<FinishCollider>();
        MyrankingSystem = FindObjectOfType<RankingSystem>();
        endpos = FindObjectOfType<FinishCollider>().transform.position.z;
        coin = PlayerPrefs.GetInt("coin");
        Coinstext.text = "" + coin;
        leveltext.text = SceneManager.GetActiveScene().name;
        if (SceneManager.GetActiveScene().name == "1")
        {
            Help.SetActive(true);
        }
    }
   
    // Update is called once per frame
    bool stoprank = true;

    void Update()
    {
        currentpos = Player.transform.position.z;
        float t = (float)((float)currentpos / (float)endpos);
        fillbar.fillAmount = t;
        if(stoprank)
            ranktest();
    }
    public void levelcompleteeffect()
    {
        if (stoprank)
        {
            Instantiate(fireparticle, new Vector3(Camera.main.transform.position.x, 0, finishcollider.transform.position.z - 69), fireparticle.transform.rotation);
            Instantiate(winparticle, new Vector3(Camera.main.transform.position.x, winparticle.transform.position.y, finishcollider.transform.position.z - 59), winparticle.transform.rotation);
            if (MyrankingSystem.rankingSystems[0].transform.gameObject.name == "PlayerCharacter")
            {
                MyrankingSystem.rankingSystems[0].transform.GetChild(8).gameObject.SetActive(true);
                if (Soundmanager.Instance)
                    Soundmanager.Instance.Playsound(Soundmanager.Instance.WinSound);
            }
            else
            {
                MyrankingSystem.rankingSystems[0].transform.GetChild(7).gameObject.SetActive(true);
                if (Soundmanager.Instance)
                    Soundmanager.Instance.Playsound(Soundmanager.Instance.fail);
            }

            Invoke("levelcomplete", 2);
            stoprank = false;
        }

    }
    int rank;
    public void ranktest()
    {
       
        rank=MyrankingSystem.rankingSystems.IndexOf(MyrankingSystem.defaultstates[4]);
        ranktext.text = "" + (rank + 1) + " TH";
    }
    
    public void levelcomplete()
    {
        levelcompletepannel.SetActive(true);
        levelcompletepannel.transform.GetChild(0).GetChild(rank).gameObject.SetActive(true);

        if ((rank+1) == 1)
        {
            levelcompletepannel.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            levelcompletepannel.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void onnextbuttonpress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }
    public void onretrybuttonpress()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
