using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip pickupSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickupSound = SoundEffectsManager.Instance.pick_Up;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item != null)
        {
            // Get item details
            ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(item.ItemCode);
            //Debug.Log(itemDetails.itemDescription);
            // if item can be picked up
            if (itemDetails.canBePickedUp == true)
            {
                // Add item to inventory
                InventoryManager.Instance.AddItem(InventoryLocation.player, item, collision.gameObject);

                // Play pick up sound
                GetComponent<AudioSource>().PlayOneShot(pickupSound);

            }
        }
    }
}
