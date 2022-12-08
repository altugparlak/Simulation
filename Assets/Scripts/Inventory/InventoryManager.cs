using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonobehaviour<InventoryManager>
{

    private Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField] private ItemList itemList = null;

    private void Start()
    {
        CreateItemDetailsDictionary();

    }

    //  Populates the itemDetailsDictionary from the scriptable object items list 
    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails itemDetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetails.itemCode, itemDetails);
        }
    }

    // Returns the itemDetails (from the ItemList) for the itemCode, or null if the item code doesn't exist
    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}
