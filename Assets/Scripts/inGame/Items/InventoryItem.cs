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
    }
}
