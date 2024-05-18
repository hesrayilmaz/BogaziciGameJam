using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTemplate:MonoBehaviour
{
    public Item myItem;
    public bool isActive;
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
             ShowCase();
          }
       }
    }
    public virtual void ShowCase()
    {
      Debug.Log("şov time");
    }

  
}
