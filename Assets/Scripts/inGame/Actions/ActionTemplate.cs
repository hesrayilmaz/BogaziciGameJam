using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTemplate:MonoBehaviour
{
    public Item myItem;
    [HideInInspector]public bool isActive;
    [SerializeField][Header("IMPORTANT UNIQUE")]protected string actionName;
    
    public virtual void Active()
    {
         if (isActive)
        return;


       foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (myItem==item?.currentItem)
          {
             CharacterInventory.Instance.DeleteItem(myItem);
             isActive=true;
             Debug.Log("aktif edildi");
             PlayerPrefs.SetString(actionName,"1");
             ShowCase();
          }
       }
       
    }
    public virtual void ShowCase()
    {
      Debug.Log("şov time");
    }

  
}
