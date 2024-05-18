using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Node :MonoBehaviour
{
    public Item myItem;
    [Header("IMPORTANT UNIQUE")]
    public string myName;
    public GameObject myLine;
    public void SaveSolve()
    {
        PlayerPrefs.SetString(myName,"1");
    }
}
