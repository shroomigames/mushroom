using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkbuttonscript : MonoBehaviour
{
    public string url;
    
    void openlink()
    {
        Application.OpenURL(url);
    }
}
