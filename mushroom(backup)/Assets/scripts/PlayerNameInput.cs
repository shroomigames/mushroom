using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField nameinputfeild = null;
    [SerializeField] private Button playbutton = null;

    public static string DisplayName { get; private set; }

    private const string playerprefsnamekey = "playername";

    public void Start() => setupinputfeild();


    public void setupinputfeild()
    {
        if (!PlayerPrefs.HasKey(playerprefsnamekey)) { return; }

        string defaultname = PlayerPrefs.GetString(playerprefsnamekey);

        nameinputfeild.text = defaultname;

        setplayername(defaultname);
    }

    public void setplayername(string name)
    {
        playbutton.interactable = !string.IsNullOrEmpty(name) || name.Length > 16;
    }

    public void saveplayername()
    {
        DisplayName = nameinputfeild.text;

        PlayerPrefs.SetString(playerprefsnamekey, DisplayName);
    }
}
