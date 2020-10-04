using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

 public class menuscript : MonoBehaviour
{
    public int val;

    public TMP_Dropdown resdrop;

    public Toggle fullscreentoggle;

    public Toggle lowqualitytoggle;

    public Transform about;

    public Transform menu;

    public Transform playmenu;

    public float volume;

    public Slider volslider;

    bool isfullscreen;

    bool islowquality;

    private void Start()
    {
        Screen.SetResolution(1024, 786, isfullscreen);
        volume = PlayerPrefs.GetFloat("vol");
        val = PlayerPrefs.GetInt("val");
    }

    public void handleinputdata()
    {
        if(val == 0)
        {
            Screen.SetResolution(640, 480, isfullscreen);
        }
        if (val == 1)
        {
            Screen.SetResolution(960, 720, isfullscreen);
        }
        if (val == 2)
        {
            Screen.SetResolution(1024, 786, isfullscreen);
        }
    }

    public void Update()
    {
        islowquality = lowqualitytoggle.isOn;
        Screen.fullScreen = isfullscreen;
        PlayerPrefs.SetFloat("vol", volume);
        PlayerPrefs.SetInt("val", val);
        isfullscreen = fullscreentoggle.isOn;
        AudioListener.volume = volslider.value;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayEndless()
    {
        SceneManager.LoadScene("chap1houseendless");
    }

    public void Play()
    {
        SceneManager.LoadScene("forest");
    }

    public void Openabout()
    {
        menu.gameObject.SetActive(false);
        about.gameObject.SetActive(true);
    }

    public void Openplaymenu()
    {
        menu.gameObject.SetActive(false);
        playmenu.gameObject.SetActive(true);
    }

    public void Closeabout()
    {
        menu.gameObject.SetActive(true);
        about.gameObject.SetActive(false);
    }

    public void Closeplaymenu()
    {
        menu.gameObject.SetActive(true);
        playmenu.gameObject.SetActive(false);
    }
}
