using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, IA_Interactable,IA_Openable
{
    [SerializeField]private TeleportType teleportType;
    public bool Locked=false;

    public void Interact()
    {
        if(Locked==false)
        SceneManager.LoadScene(teleportType.ToString());
    }

    public void Open()
    {
       Locked=false;
       Interact();
       
    }
    [Serializable]
    public enum TeleportType
    {
        Garden,
        Hall,
        Kitchen,
        Bedroom,
        Cellar,
        SecretRoom,
        MainMenu
    }
}
