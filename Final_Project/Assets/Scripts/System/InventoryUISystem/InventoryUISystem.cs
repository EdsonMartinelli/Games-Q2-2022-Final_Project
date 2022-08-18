using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISystem : MonoBehaviour
{
    private static InventoryUISystem instance;
    private float itemBoxSize;
    private float offset;

    [SerializeField] private float itemSize = 100f;
    [SerializeField] private int numberOfItems = 3;
    [SerializeField] private GameObject ItemBox;

    private InventoryUISystem() { }

    public static InventoryUISystem GetInvetoryUISystem()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            itemBoxSize = ItemBox.GetComponent<RectTransform>().rect.size.x;
            offset = (itemBoxSize - (numberOfItems * itemSize))/ (numberOfItems + 1);
            if (offset < 0) offset = 0;
        }
    }

    public void UpdateInventory(Inventory inventory)
    {
        int horizontalPos = 0;

        foreach (Transform child in ItemBox.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Item item in inventory.GetQueue().ToArray())
        {
            Sprite spriteItem = ResourceSystem.GetResourceSystem().GetSprite(item.GetItemType());
            GameObject spriteObj = new GameObject(item.GetItemType().ToString());
            Image spriteImage = spriteObj.AddComponent<Image>();
            spriteImage.GetComponent<RectTransform>().sizeDelta = new Vector2(itemSize, itemSize);
            spriteImage.sprite = spriteItem;
            spriteImage.GetComponent<RectTransform>().SetParent(ItemBox.transform,false);
            float positonItem = horizontalPos * itemSize - (itemBoxSize / 2) + (itemSize / 2) + (offset * (horizontalPos + 1));
            spriteImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(positonItem, 0f);
            horizontalPos++;

        }
    }

}
