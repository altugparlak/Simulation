using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "Scriptable Objects/Item/Item List")]
public class ItemList : ScriptableObject
{
    [SerializeField] public List<ItemDetails> itemDetails;
}
