using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class playerdat : NetworkBehaviour
{
    public AudioSource devilsound;
    public TextMeshPro playernametext;
    public Behaviour[] compomentstodisable;
    public SphereCollider killcol;
    public Animator ainm;
    public killscript killscript;
    [SyncVar]
    public bool ismushroom;
    [SyncVar]
    bool iswalking;
    [SyncVar]
    public int mushroomskinid;
    [SyncVar]
    public int survivorskinid;
    [SyncVar]
    public string playername;
    // Start is called before the first frame update
    void Start()
    {
        ainm = GetComponentInChildren<Animator>();
        playername = PlayerPrefs.GetString("playername");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < compomentstodisable.Length; i++)
            {
                compomentstodisable[i].enabled = false;
            }
            transform.LookAt(Camera.main.transform, Vector3.up);
        }
        if (isLocalPlayer)
        {
            ainm.SetInteger("mushroomskinid", mushroomskinid);
            ainm.SetInteger("skinid", survivorskinid);
            ainm.SetBool("walking", iswalking);
            ainm.SetBool("ismushroom", ismushroom);
        }
        playernametext.text = playername;
        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        if(input != Vector2.zero)
        {
            iswalking = true;
        }
        else
        {
            iswalking = false;
        }

        if (ismushroom)
        {
            gameObject.tag = "mushroom";
            killcol.enabled = true;
            killscript.enabled = false;
        }
        if(mushroomskinid == 3 && ismushroom == true)
        {
            devilsound.enabled = true;
        }
        else
        {
            devilsound.enabled = false;
        }
    }
}
