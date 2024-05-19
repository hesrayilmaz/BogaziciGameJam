using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionTemplate:MonoBehaviour
{
    public Item myItem;
    
    public virtual void Active()
    {
       foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (myItem==item?.currentItem)
          {
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
