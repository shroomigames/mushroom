using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopmanager : MonoBehaviour
{
    public GameObject[] previews;
    public GameObject[] mushroompreviews;
    public GameObject[] equipbuttons;
    public GameObject equippedbutton;
    public int smileys;
    public int preveiwamount;
    public int mushroompreveiwamount;
    public TextMeshProUGUI smileytext;
    public Scrollbar Scrollbar;
    public GameObject preveiwarea;
    public float scrollamount;
    public float startscrollamount;
    public Vector3 preveiwstartpos;
    // Start is called before the first frame update
    void Start()
    {
        preveiwamount = 0;
        smileys =  PlayerPrefs.GetInt("smileyamount", 500);
        preveiwstartpos = preveiwarea.transform.position;
        startscrollamount = preveiwarea.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        scrollamount = Scrollbar.value * -startscrollamount;
        preveiwarea.transform.position = new Vector3(preveiwstartpos.x, preveiwstartpos.y + scrollamount, 0);
        smileytext.text = smileys.ToString();
        PlayerPrefs.SetInt("smileyamount", smileys);
        for (int i = 0; i < previews.Length; i++)
        {
            if (i == preveiwamount)
            {
                previews[i].SetActive(true);
            }
            else
            {
                previews[i].SetActive(false);
            }
        }
        for (int i = 0; i < previews.Length; i++)
        {
            if (i == preveiwamount)
            {
                previews[i].SetActive(true);
            }
            else
            {
                previews[i].SetActive(false);
            }
        }
        for (int j = 0; j < mushroompreviews.Length; j++)
        {
            if (j == preveiwamount)
            {
                mushroompreviews[j].SetActive(true);
            }
            else
            {
                previews[j].SetActive(false);
            }
        }
    }

    public void changepreview(int val)
    {
        preveiwamount = val;
        Debug.Log("Changed preveiw succsessfully.");
    }

    public void changemushroompreview(int val)
    {
        mushroompreveiwamount = val;
    }



    public void equip(int skinid , GameObject equipbutton, GameObject equipedbutton, bool ismushroomskin)
    {
        equipbutton.SetActive(false);
        equipedbutton.SetActive(true);
        if (!ismushroomskin)
        {
            PlayerPrefs.SetInt("mushroomskinid", skinid);
        }
        else
        {
            PlayerPrefs.SetInt("survivorskinid", skinid);
        }
    }
}
