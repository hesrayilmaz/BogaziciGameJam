using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Image myIcon;
    [HideInInspector]public Item currentItem;
    [SerializeField]private TextMeshProUGUI countText;
    public int count;
    private void Start() {
           CharacterInventory.Instance.inventoryItems.RemoveAll(item => item == null );
        CharacterInventory.Instance.inventoryItems.Add(GetComponent<InventoryItem>());
    }
    public void SlotItem(Item item)
    {
        Debug.Log("yeni item geldi");
        currentItem=item;
        ResetSlot(1);
    }
    public void ResetSlot(int increase)
    {
        Debug.Log("item eklendi");
        myIcon.sprite=currentItem.itemPic;
        count+=increase;
        countText.text=count.ToString();
        if (count<=0)
        {
          count=0;
          currentItem=null;
          myIcon.sprite=null;
        }
    }
}
