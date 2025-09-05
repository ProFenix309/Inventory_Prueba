using UnityEngine;

public class ItemDataSO : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] string _itemName;
    [SerializeField] Sprite _icon;
    [SerializeField] GameObject _prefab;

    public int Id { get => _id; set => _id = value; }
    public string ItmNm { get => _itemName; set => _itemName = value; }
    public Sprite Icn { get => _icon; set => _icon = value; }
    public GameObject Prfb { get => _prefab; set => _prefab = value; }
}
