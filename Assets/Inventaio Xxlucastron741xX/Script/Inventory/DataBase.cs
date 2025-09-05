using UnityEngine;

[CreateAssetMenu(fileName = "DataBase", menuName = "Inventory/New DataBase", order = 1)]
public class DataBase : ScriptableObject
{
    [System.Serializable]
    public struct InventoryItem
    {
        public string nameItem;
        public string description;
        public int ID;
        public int mazStack;
        public bool acumulative;
        public Tipo tipo;
        public Sprite icon;
        public BaseItem item;
    }

    public enum Tipo
    {
        Bullet,
        Consumable
    }

    public InventoryItem[] dataBase;

    private void OnValidate()
    {
        if (dataBase != null)
        {
            for (int i = 0; i < dataBase.Length; i++)
            {
                if (dataBase[i].ID != i)
                {
                    dataBase[i].ID = i;
                }
            }
        }
    }

}
