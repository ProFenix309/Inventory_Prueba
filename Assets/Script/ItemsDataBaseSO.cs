using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Itams Dabase SO", menuName = "Items Data/New Itams Dabase SO")]
public class ItemsDataBaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> _dataBase;

    public ItemDataSO SearchItemDataById(int id)
    {
        return _dataBase.Find(x => x.Id == id);
    }
}
