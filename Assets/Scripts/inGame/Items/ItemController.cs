using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ItemController : MonoBehaviour,IA_Interactable
{
    public Item myItem;
    public void Interact()
    {
        Destroy(gameObject);
        CharacterInventory.Instance.GetItem(myItem);
    }

    
}
