using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour, IA_Interactable
{
    [SerializeField]private TeleportType teleportType;
    public void Interact()
    {
        SceneManager.LoadScene(teleportType.ToString());
    }
    public enum TeleportType
    {
        Garden,
        Hall,
        Kitchen

    }
}
