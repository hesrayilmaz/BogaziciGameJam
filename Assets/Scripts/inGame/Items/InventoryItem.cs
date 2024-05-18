using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string slotIndex;
    public Image myIcon;
    public Item currentItem;
    [SerializeField]public TextMeshProUGUI countText;
    public int count;

    public void SlotItem(Item item,int newCount)
    {
        currentItem=item;
        ResetSlot(newCount);
    }
    public void ResetSlot(int increase)
    {
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
