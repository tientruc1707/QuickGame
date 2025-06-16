
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemTemplate;
    [SerializeField] private float itemCellsize;

    private void OnEnable()
    {
        itemSlotContainer = transform.Find("ItemSlotContainer");
        itemTemplate = itemSlotContainer.Find("ItemSlotTemplate");
    }
    public void SetInventory(Inventory _inventory)
    {
        inventory = _inventory;
        RefreshInventoryUI();
    }

    private void RefreshInventoryUI()
    {
        int x = 0;
        int y = 0;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemCellsize, y * itemCellsize);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            Button btn = itemSlotRectTransform.AddComponent<Button>();
            btn.onClick.AddListener(() => { Debug.Log("item is choose"); });

            
            x++;
            if (x > 2)
            {
                y--;
                x = 0;
            }
            if (y < -1)
            {
                Debug.Log("Inventory is full!");
            }
        }
    }
}
