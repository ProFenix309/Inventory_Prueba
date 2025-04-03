using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> _items = new()
    {
        { 3, 15},
        { 7, 3}
    };


    public void AddItem(int id, int amout)
    {
        if (!_items.ContainsKey(id))
        {
            _items.Add(id, amout);
        }
        else
        {
            _items[id] += amout;
        }
    }

    public void RemoveItem(int id, int amout)
    {
        if (_items.ContainsKey(id))
        {
            _items[id] -= amout;

            if (_items[id] <= 0)
            {
                _items.Remove(id);
            }
        }
    }

    public void SowInventory()
    {
        foreach (var item in _items)
        {
            Debug.Log(item);
        }
    }
}