using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack : MonoBehaviour
{
    public Item Item;
    
    private int value;
    public int Value { get => value; }

    public void AddValue(int v)
    { 
        value = Mathf.Clamp(value + v, 0, Item.MaxStack);
    }
}
