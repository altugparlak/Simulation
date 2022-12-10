using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemCode;
    public ItemType itemType;
    public Outfit outfit;
    public Sprite outfitBody;
    public Sprite outfitArm;
    public Sprite outfitHair;
    public int itemPrice;
    public int itemShopPrice;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartingItem;
    public bool canBePickedUp;
    public bool canBeDropped;
    public bool canBeEaten;
    public bool canBeCarried;
    public bool canBeSold;
    public bool canBeBought;


}
