using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static CharacterInventory Instance;
    [SerializeField]private List<InventoryItem> inventoryItems=new List<InventoryItem>();
    private void Awake() {
        if (Instance==null)
        {
            Instance=this;
        }
    }
    public void GetItem(Item newItem)
    {
       foreach (InventoryItem item in inventoryItems)
       {
         if(newItem.itemType == item.currentItem?.itemType)
         {
              item.ResetSlot(1);
              return;
         }
       }
       for (int i = 0; i < inventoryItems.Count; i++)
       {
         if(inventoryItems[i].currentItem==null)
         {
            inventoryItems[i].SlotItem(newItem);
            return;
         }
       }
      
    }
}
