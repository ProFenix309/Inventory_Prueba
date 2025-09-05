using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Itams Dabase SO", menuName = "Items Data/New Itams Dabase SO")]
public class ItemsDataBaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> _tems;

    public List<ItemDataSO> Items { get => _tems; set => _tems = value; }

    public ItemDataSO SearchItemDataById(int id)
    {
        return Items.Find(x => x.Id == id);
    }
}
