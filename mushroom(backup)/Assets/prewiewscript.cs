using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prewiewscript : MonoBehaviour
{
    public int skinid;
    public GameObject buybutton;
    public GameObject equipbutton;
    public GameObject equipedbutton;
    public GameObject currentequipedbutton;
    public bool isequippable;
    public bool isequipped;

    // Update is called once per frame
    void Update()
    {
        buybutton.SetActive(!isequippable);
        equipbutton.SetActive(isequippable);
        equipbutton.SetActive(!isequipped);
        equipedbutton.SetActive(isequipped);
        if(skinid == PlayerPrefs.GetInt("skinid"))
        {
            isequipped = true;
        }
        else
        {
            isequipped = false;
        }
    }

    public void equip()
    {
        PlayerPrefs.SetInt("skinid", skinid);
    }    
    public void buy(int cost)
    {
        int smileys = PlayerPrefs.GetInt("smileyamount");
        PlayerPrefs.SetInt("smileyamount", smileys);
        if (cost <= smileys)
        {
            smileys -= cost + cost;
            isequippable = true;
        }
        else
        {
            return;
        }
    }
}