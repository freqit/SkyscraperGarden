using UnityEngine;

public class Item : ScriptableObject
{
    [SerializeField] private string name;
    public int MaxStack = 10;

    public string Name { get => name; }
}
