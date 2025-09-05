using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ItemUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private DataBase db;

    public int id;
    public int quantity;

    [HideInInspector]
    public DataBase.InventoryItem itemData;
    [HideInInspector]
    public Transform exParent;

    TextMeshProUGUI quantityText;
    Image iconImage;
    Vector3 dragOffset;

    private void Awake()
    {
        quantityText = transform.GetComponentInChildren<TextMeshProUGUI>();
        iconImage = GetComponent<Image>();

        exParent = transform.parent;
        if (exParent.GetComponent<Image>())
            exParent.GetComponent<Image>().fillCenter = true;
        InitializeItem(id, quantity);
    }

    private void Update()
    {
        if (quantityText != null)
        {
            quantityText.text = quantity.ToString();
        }
    }

    public void InitializeItem(int id, int quantity)
    {
        itemData.ID = id;
        itemData.acumulative = db.dataBase[id].acumulative;
        itemData.description = db.dataBase[id].description;
        itemData.icon = db.dataBase[id].icon;
        itemData.nameItem = db.dataBase[id].nameItem;
        itemData.tipo = db.dataBase[id].tipo;
        itemData.mazStack = db.dataBase[id].mazStack;
        itemData.item = db.dataBase[id].item;

        this.quantity = quantity;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        //Inventory_2.Intance.HadeDrescription();
        quantityText.enabled = false;
        exParent = transform.parent;
        exParent.GetComponent<Image>().fillCenter = false;
        //transform.SetParent(Inventory_2.Instance.transform);
        dragOffset = transform.position - Input.mousePosition; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        quantityText.enabled = true;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        Transform slot = null;

        //Inventory_2.Intance.grapRay.Raycast(eventData, raycastResults);

        foreach (RaycastResult hit in raycastResults)
        {
            var hitObj = hit.gameObject.transform;

            if (hitObj.CompareTag("Slot") && hit.gameObject.transform.childCount == 0)
            {
                slot = hit.gameObject.transform;
                break;
            }

            if (hitObj.CompareTag("Item_UI"))
            {
                if (hitObj != this.gameObject)
                {
                    ItemUI hitObjItamData = hitObj.GetComponent<ItemUI>();
                    if (hitObjItamData.itemData.ID != id)
                    {
                        slot = hitObjItamData.transform.parent;
                        //Iventory.Instance.UpdatePatent(hitObjItemData, exParent);
                        break;
                    }
                    else
                    {
                        if (itemData.acumulative && hitObjItamData.quantity + quantity <= itemData.mazStack)
                        {
                            quantity += hitObjItamData.quantity;
                            slot = hitObjItamData.transform.parent; 

                            break;
                        }
                    }
                }
            }
        }
    }

}
