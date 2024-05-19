using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AC_Book : ActionTemplate,IA_Interactable
{
    [SerializeField]private GameObject BookScene,BackButton;
    public override void Active()
    {
         foreach (InventoryItem item in CharacterInventory.Instance.inventoryItems)
       {
          if (myItem==item?.currentItem)
          {
            NodeController.Instance.SolveNode(myItem);
            BackButton.SetActive(true);
            BookScene.SetActive(true);
            CameraMovement.Instance.zoomActive=true;
          }
       }
    }

    public void Interact()
    {
        Active();
    }

 
}
