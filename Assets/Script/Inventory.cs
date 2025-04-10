using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void InventoryUpdateDelegate();
    public InventoryUpdateDelegate ItemUpdate;
    public InventoryUpdateDelegate ItemRemoved;
    public InventoryUpdateDelegate ItemAdded;

    Dictionary<int, int> _items = new()
    {
        { 3, 15},
        { 7, 3}
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    public void AddItem(int id, int amout)
    {
        if (!Items.ContainsKey(id))
        {
            Items.Add(id, amout);
            ItemAdded?.Invoke();
        }
        else
        {
            Items[id] += amout;
            ItemUpdate?.Invoke();
        }
    }

    public void RemoveItem(int id, int amout)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] -= amout;

            if (Items[id] <= 0)
            {
                Items.Remove(id);
                ItemRemoved?.Invoke();
            }
            else
            {
                ItemUpdate?.Invoke();
            }
        }
    }

    public void SowInventory()
    {
        foreach (var item in Items)
        {
            Debug.Log(item);
        }
    }
}