using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour
{
    [SerializeField][Header("IMPORTANT UNIQUE")]private string myName;
    private void Start() {
        if (PlayerPrefs.GetString(myName)!="1")
        {
            gameObject.SetActive(false);
        }
    }
}
