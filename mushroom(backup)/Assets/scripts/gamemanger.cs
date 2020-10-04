using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Mirror;

public class gamemanger : NetworkBehaviour
{
    public GameObject[] players;
    public List<GameObject> mushrooms;
    public List<GameObject> survivors;
    public TextMeshProUGUI timertext;
    [SyncVar]
    public float timer;
    public static bool timeStarted = true;
    public Transform mushroomspwan;

    // Update is called once per frame

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("mushroom");
        if (players != null)
        {
            int i = Random.Range(0, players.Length);
            players[i].GetComponent<playerdat>().ismushroom = true;
            for (int j = 0; j > players.Length; j++) {
                if (players[j].GetComponent<playerdat>().ismushroom == true)
                {
                    mushrooms.Add(players[j]);
                }
                else
                {
                    survivors.Add(players[j]);
                }
            }
            players[i].transform.position = mushroomspwan.position;
        }
        else
        return;
    }
    void Update()
    {
        if (timeStarted)
        {
            timer -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            timertext.text = niceTime;
            if (minutes == 0 && seconds == 00)
            {
                timeStarted = false;
            }
            
        }
    }
}
