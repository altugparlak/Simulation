# Unity Game Project
Overview
This project began with asset acquisition from the "M STUDIO HUB" on the Unity Asset Store, followed by the creation of a game with a focus on inventory management. To enhance my understanding of game systems, I also took a course on Udemy.

## Game System
Player Movement: The player has a custom movement script that handles input and animation.
Inventory Management: Utilizes a scriptable object for the item list, simplifying the process of adding and removing items.
Item Prefabs: Prefabs in the scene reference ItemDetails (a [System.Serializable] object), making it easy to manage item information.
Inventory System: A SingletonMonobehaviour<InventoryManager> manages inventory actions with an itemDetailsDictionary that pairs itemCode keys with ItemDetails values. This setup allows for easy item access by code.
Unique Identifiers: System.Guid.NewGuid() generates unique IDs for all data, ensuring consistency across scenes and enabling seamless scene transitions.
Persistent Objects: Used SingletonMonobehaviour to maintain steady game objects like the Player and InventoryManager across scenes.
## Custom Scripts
- NPC.cs
- NPCDetails.cs
- NPCDescriptionAttribute.cs
- NPCTalkTrigger.cs
- NPCcodeDescriptionDrawer.cs
- UIShopSlot.cs
- PlayerGoldDisplay.cs
- Player.cs
- FootSteps.cs
- SoundEffectsManager.cs
- SceneNPCManager.cs
## Course Scripts
- SingletonMonobehaviour.cs
- Enums.cs
- Tags.cs
- SwitchBoundingShape.cs
- Settings.cs
- Fader_Item.cs
- TriggerFade.cs
- ItemDetails.cs
- ItemList.cs
- ItemPickUp.cs
- ItemCodeDescriptionAttribute.cs
- ItemCodeDescriptionDrawer.cs
- ItemNudge.cs
- InventoryItem.cs
- UIInventorySlot.cs
- UIInventoryBar.cs
- Item.cs
- UIInventoryTextBox.cs
- EventHandler.cs
- TimeManager.cs
- GameClock.cs
- SceneLoader.cs
- SceneTeleport.cs
- GenerateGUID.cs
- ISavable.cs
- SaveLoadManager.cs
- SceneItemsManager.cs
- InventoryManager.cs
## Future Improvements
- Sound Optimization: Improve the audio experience.
- Player Interactions: Add more actions like chopping and reaping.
- Player Customization: Enhance player outfits, including adding a second costume.
- Expanded Content: Develop more scenes, introduce additional NPCs, and improve NPC dialogues.

![227766046-e61e7617-c31f-4bfb-a42a-538e13eb6df2](https://github.com/user-attachments/assets/7e04363f-0c17-4eb6-9ffe-a1de3fe95116)
