using System.Collections.Generic;
using UnityEngine;

public class Inventory_2
{
    private List<Item> itemList;

    public Inventory_2() 
    {
        itemList = new List<Item>();
        Debug.Log("Inventory");
    }
}
