using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class UIShopSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject itemPrefab = null;
    [SerializeField] private TextMeshProUGUI priceText = null;
    public GameObject shopDraggedItem;
    public GameObject draggedItem;
    public Image shopSlotImage;
    private ItemDetails itemDetails;
    private int playergold;


    void Start()
    {
        if (itemPrefab!= null)
        {
            int _itemCode = itemPrefab.GetComponent<Item>().ItemCode;
            itemDetails = InventoryManager.Instance.GetItemDetails(_itemCode);
            priceText.text = itemDetails.itemShopPrice.ToString();
        }
        EventHandler.GameGoldEvent += UpdatePlayerGold;

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (itemPrefab != null)
        {
            // Disable keyboard input
            Player.Instance.DisablePlayerInputAndResetMovement();

            // Instatiate gameobject as dragged item
            draggedItem = Instantiate(shopDraggedItem, transform);

            // Get image for dragged item
            Image draggedItemImage = draggedItem.GetComponentInChildren<Image>();
            draggedItemImage.sprite = shopSlotImage.sprite;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move game object as dragged item
        if (draggedItem != null)
        {
            draggedItem.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy game object as dragged item
        if (draggedItem != null)
        {
            Destroy(draggedItem);
            if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<UIInventorySlot>() != null)
            {
                // if item can be bought up
                playergold = Player.Instance.GetPlayerGold();
                if (itemDetails.canBeBought == true && playergold >= itemDetails.itemShopPrice)
                {
                    // Add item to inventory
                    InventoryManager.Instance.AddItemFromShop(InventoryLocation.player, itemPrefab.GetComponent<Item>());

                    // Play pick up sound
                    //AudioManager.Instance.PlaySound(SoundName.effectPickupSound);

                    // Lose Money
                    playergold -= itemDetails.itemShopPrice;
                    EventHandler.CallPlayerGoldEvent(playergold);


                }
                // else attempt to drop the item if it can be dropped
                else
                {

                }

                // Enable player input
            }
            Player.Instance.EnablePlayerInput();

        }
    }

    private void UpdatePlayerGold(int gold)
    {
        playergold = gold;
    }

    private void OnDisable()
    {
        EventHandler.GameGoldEvent -= UpdatePlayerGold;
    }

}