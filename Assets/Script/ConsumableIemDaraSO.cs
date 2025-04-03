using UnityEngine;

public enum ConsumableTypeEnum
{
    heal,
    damage
}
[CreateAssetMenu(fileName = "Consumable SO", menuName = "Items Data/New Consumable SO")]
public class ConsumableIemDaraSO : ItemDataSO
{
    [SerializeField]ConsumableTypeEnum _Type;
    [SerializeField] int _value;
}
