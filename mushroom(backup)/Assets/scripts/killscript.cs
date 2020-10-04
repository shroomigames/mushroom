using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class killscript : MonoBehaviour
{
    public bool isdead;

    bool playedjumpscare;

    public Transform cam;

    public Transform menu;

    public GameObject mushroom;

    public AudioSource jumpscare;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mushroom"))
        {
            isdead = true;
        }
        else
            return;
    }

    private void Update()
    {
        if(isdead == true)
        {
            if(!playedjumpscare)
            {
                jumpscare.Play();
            }
            if (jumpscare.isPlaying)
            {
                playedjumpscare = true;
            }
            GetComponent<playerdat>().ismushroom = true;
        }
    }
}
