using UnityEngine;

public enum ArmorTypeEnum
{
    head,
    chest,
    legs,
    feet
}
[CreateAssetMenu(fileName = "Armor SO", menuName = "Items Data/New Armor SO")]
public class ArmorItemDataSo : ItemDataSO
{
    [SerializeField] ArmorTypeEnum _Type;
    [SerializeField] int _value;
}
