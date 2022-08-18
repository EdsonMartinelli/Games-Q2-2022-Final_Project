using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ResourceSystem : MonoBehaviour
{
    private static ResourceSystem instance;
    [SerializeField] private GameObject interactHint;
    [SerializeField] private Sprite beer;
    [SerializeField] private Sprite coffee;
    [SerializeField] private Sprite food;
    [SerializeField] private Sprite juice;
    [SerializeField] private Sprite water;
    [SerializeField] private Sprite lunch;
    private ResourceSystem() { }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static ResourceSystem GetResourceSystem()
    {
        return instance;
    }

    public GameObject GetInteractHint()
    {
        return interactHint;
    }

    public Sprite GetSprite(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.Beer: return beer;
            case Item.ItemType.Coffee: return coffee;
            case Item.ItemType.Food: return food;
            case Item.ItemType.Juice: return juice;
            case Item.ItemType.Water: return water;
            case Item.ItemType.Lunch: return lunch;
            default: return null;
        }
    }


}
