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
            interactHint = Instantiate(interactHint);
            interactHint.transform.rotation = Quaternion.Euler(0f, 45f, 0f);
            interactHint.SetActive(false);
        }
    }

    public static ResourceSystem GetResourceSystem()
    {
        return instance;
    }

    public void SetActiveHint(bool mode)
    {
        interactHint.SetActive(mode);
    }

    public void SetPositionHint(Vector3 pos)
    {
        interactHint.transform.position = pos;
    }

    public void SetRotationHint(Quaternion rotation)
    {
        interactHint.transform.rotation = rotation;
    }

    public Sprite GetSprite(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.Cerveja: return beer;
            case Item.ItemType.Cafe: return coffee;
            case Item.ItemType.Alimento: return food;
            default: return null;
        }
    }


}
