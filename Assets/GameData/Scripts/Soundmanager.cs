using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Soundmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource As,Background_As;
    public static Soundmanager Instance;

    public AudioClip MenusoundBg, GameBg, WinSound, HitObstacleSound,Coincollect,Playerinair,GroundHit,fail;
    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    bool weareingame=true;
    bool weareinmenu = true;
    private void Update()
    {
        if (SceneManager.GetActiveScene().name =="MainMenu" && weareinmenu)
        {
            Background_As.PlayOneShot(MenusoundBg);
            weareinmenu = false;
        }
        if(weareingame && SceneManager.GetActiveScene().name != "MainMenu")
        {
            if(Background_As.isPlaying)
            {
                Background_As.Stop();
            }
            Background_As.PlayOneShot(GameBg);
           weareingame = false;
        }
    }

   public void Playsound(AudioClip mysound)
    {
        As.PlayOneShot(mysound);
    }
}
