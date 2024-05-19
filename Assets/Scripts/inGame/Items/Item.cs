using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;



[CreateAssetMenu(fileName = "Item", menuName = "Item/NewItem", order = 0)]
public class Item : ScriptableObject {
    
    public ItemType itemType;
    public Sprite itemPic;
}

[Serializable]
public enum ItemType
{
    Key,
    Book,
    Knife,
    Shovel
}
    

