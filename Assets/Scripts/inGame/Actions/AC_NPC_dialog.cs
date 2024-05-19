using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_NPC_dialog : ActionTemplate
{
    [SerializeField]private NpcDialog npcDialog;
    [SerializeField]private bool littleGirl=false;

    public override void Active()
    {
         foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (myItem==item?.currentItem)
          {
            NodeController.Instance.SolveNode(myItem);
            npcDialog.isLocked=false;
            if (littleGirl)
            {
                PlayerPrefs.SetString("Boss","1");
                EndGame.Instance.Refresh();
            }
          }
       }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        Active();
    }

}
