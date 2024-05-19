using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Shovel : ActionTemplate
{
   private void OnTriggerEnter2D(Collider2D other) {
     if(other.gameObject.tag=="Player")
    Active();
   }
    public override void Active()
    {
         foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (myItem==item?.currentItem)
          {
            NodeController.Instance.SolveNode(myItem);
          }
       }
    }
}
