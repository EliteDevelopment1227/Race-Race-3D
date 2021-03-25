using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class RankingSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<RankingSystem> rankingSystems = new List<RankingSystem>();
    public RankingSystem[] defaultstates;
    void Awake()
    {
    defaultstates = FindObjectsOfType<RankingSystem>();
        for(int i = 0; i < defaultstates.Length; i++)
        {
            rankingSystems.Add(defaultstates[i]);
        }
    }
    public bool stopranking=true;
    // Update is called once per frame
    void Update()
    {
        if (stopranking)
        {
            rankingSystems = rankingSystems.OrderBy(i => i.GetComponent<RankingSystem>().transform.position.z).ToList();
            rankingSystems.Reverse();
        }
       
       

    }
}
