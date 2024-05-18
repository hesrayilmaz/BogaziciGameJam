using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static CharacterInventory Instance;
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<Item> allItems = new List<Item>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LoadInventory();
    }

    public void GetItem(Item newItem)
    {
       Debug.Log(newItem);
        foreach (InventoryItem item in inventoryItems)
        {
            if (newItem.itemType == item.currentItem?.itemType)
            {
                item.ResetSlot(1);
                Debug.Log("yeni item eklendi");
                SaveInventory();
                return;
            }
        }

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].currentItem == null)
            {
                inventoryItems[i].SlotItem(newItem,1);
                 Debug.Log("varolan arttırıldı");
                SaveInventory();
                return;
            }
        }
    }

    public void SaveInventory()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            string key = "InventorySlot_" + i;
            if (inventoryItems[i].currentItem != null)
            {
                PlayerPrefs.SetString(key + "_itemType", inventoryItems[i].currentItem.itemType.ToString());
                PlayerPrefs.SetInt(key + "_count", inventoryItems[i].count);
            }
            else
            {
                PlayerPrefs.DeleteKey(key + "_itemType");
                PlayerPrefs.DeleteKey(key + "_count");
            }
        }
        PlayerPrefs.Save();
    }

    public void LoadInventory()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            string key = "InventorySlot_" + i;
            if (PlayerPrefs.HasKey(key + "_itemType"))
            {
                string itemTypeStr = PlayerPrefs.GetString(key + "_itemType");
                int count = PlayerPrefs.GetInt(key + "_count");

                ItemType itemType = (ItemType)System.Enum.Parse(typeof(ItemType), itemTypeStr);
                Item loadedItem = FindItemByType(itemType);

                if (loadedItem != null)
                {
                    inventoryItems[i].SlotItem(loadedItem,count);
                }
            }
        }
    }

    private Item FindItemByType(ItemType itemType)
    {
        foreach (Item item in allItems)
        {
            if (item.itemType == itemType)
            {
                return item;
            }
        }
        return null;
    }

    public void DeleteItem(Item newItem)
    {
        foreach (InventoryItem item in inventoryItems)
        {
            if (newItem.itemType == item.currentItem?.itemType)
            {
                item.ResetSlot(-1);
                Debug.Log("item silindi");
                SaveInventory();
                return;
            }
        }
    }
}
