using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AC_Door : ActionTemplate,IA_Interactable
{
    [SerializeField]private Item shovelItem;
    public override void Active()
    {
        base.Active();
    }

    public void Interact()
    {
        //base

        Active();
    }

    public override void ShowCase()
    {
      base.ShowCase();
      NodeController.Instance.SolveNode(myItem);
      foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (shovelItem==item?.currentItem)
          {
             return;
          }
       }
       CharacterInventory.Instance.GetItem(shovelItem);
       PlayerPrefs.SetString("richGirl","1");

    }
}
