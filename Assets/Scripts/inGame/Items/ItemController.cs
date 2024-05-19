using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ItemController : MonoBehaviour,IA_Interactable
{
    public Item myItem;

    [Header("IMPORTANT UNIQUE")]public string myName;
    private void Start() {
        if (PlayerPrefs.GetString(myName)=="1")
          Destroy(gameObject);
    }
    public void Interact()
    {
        AudioManager.Instance.PlaySFX("interaction1");
         CharacterInventory.Instance.GetItem(myItem);
         PlayerPrefs.SetString(myName,"1");
        Destroy(gameObject);
    }

    
}
