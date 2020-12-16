using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherableObject : MonoBehaviour
{
    public Item item;

    public ItemStack GatherObject()
    {
        // randomize chance to gather and return item and set value
        ItemStack itemStack = new ItemStack();
        itemStack.Item = item;
        itemStack.AddValue(Random.Range(1, 3));
        return itemStack;
    }
}
