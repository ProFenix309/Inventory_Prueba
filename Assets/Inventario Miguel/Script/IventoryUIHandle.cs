using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IventoryUIHandle : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemsDataBaseSO dataSO;
    [SerializeField] GameObject itemButton;
    [SerializeField] ScrollRect itemScroll;

    [SerializeField] CanvasGroup previewPanel;

    List<GameObject> instantiateButtonList = new();

    [Space]
    [Header("Preview Panel")]
    [SerializeField] Image itemPreviewIcon;
    [SerializeField] TextMeshProUGUI itemPreviewAmount;
    [SerializeField] TextMeshProUGUI itemPreviewName;

    int selectecItemId;


    private void Start()
    {
        InstantiateButtons();
        ShowItems();
    }

    public void InstantiateButtons()
    {
        for (int i = 0; i < dataSO.Items.Count; i++)
        {
            GameObject istantiateButton = Instantiate(itemButton, itemScroll.content);
            istantiateButton.SetActive(false);
            instantiateButtonList.Add(istantiateButton);
        }
    }

    public void ShowItems()
    {
        foreach (var item in inventory.Items)
        {
            ItemDataSO itemData = dataSO.SearchItemDataById(item.Key);

            GameObject searchedButton = instantiateButtonList.Find(x => x.activeSelf == false);
            searchedButton.SetActive(true);
            searchedButton.transform.Find("Icon Image").GetComponent<Image>().sprite= itemData.Icn;
            searchedButton.transform.Find("Amount").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            searchedButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                selectecItemId = item.Key;
                ShowItemPreview(itemData,item.Value);
                ShowPreviewPanel();
            });
        }
    }

    public void ShowItemPreview(ItemDataSO itemData, int Amount)
    {
        itemPreviewIcon.sprite = itemData.Icn;
        itemPreviewAmount.text = Amount.ToString();
        itemPreviewName.text = itemData.ItmNm;
    }

    public void ShowPreviewPanel()
    {
        previewPanel.alpha = 1f;
        previewPanel.interactable = true;
        previewPanel.blocksRaycasts = true;
    }

    public void DeleteItem()
    {
        inventory.RemoveItem(selectecItemId,1);
    }

}
