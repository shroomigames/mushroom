using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemenu : MonoBehaviour
{

    bool menuisopen = false;

    public Transform menu;

    public killscript killscript;

    // Update is called once per frame
    void Update()
    {
        if (killscript != null)
        {
            if (!killscript.isdead)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (menuisopen)
                    {
                        menuisopen = false;
                    }
                    else
                        menuisopen = true;
                }

                if (menuisopen)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    menu.gameObject.SetActive(true);
                }

                if (!menuisopen)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Time.timeScale = 1;
                    menu.gameObject.SetActive(false);
                }
            }
            else
            {
                menu.gameObject.SetActive(true);
            }
        }
        else
            return;
    }


    public void quit()
    {
        SceneManager.LoadScene("menu");
    }
}
