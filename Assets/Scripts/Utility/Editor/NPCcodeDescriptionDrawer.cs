using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NPCDescriptionAttiribute))]
public class NPCcodeDescriptionDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Change the returned property height to be double to cater for the additional item code description that we will draw
        return EditorGUI.GetPropertyHeight(property) * 2;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that prefab override logic works on the entire property.

        EditorGUI.BeginProperty(position, label, property);

        if (property.propertyType == SerializedPropertyType.Integer)
        {

            EditorGUI.BeginChangeCheck(); // Start of check for changed values

            // Draw item code
            var newValue = EditorGUI.IntField(new Rect(position.x, position.y, position.width, position.height / 2), label, property.intValue);

            // Draw item description
            EditorGUI.LabelField(new Rect(position.x, position.y + position.height / 2, position.width, position.height / 2), "NPC Name", GetItemDescription(property.intValue));



            // If item code value has changed, then set value to new value
            if (EditorGUI.EndChangeCheck())
            {
                property.intValue = newValue;
            }


        }


        EditorGUI.EndProperty();
    }

    private string GetItemDescription(int itemCode)
    {
        NPC npc_list;

        npc_list = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/NPC/NPCList.asset", typeof(NPC)) as NPC;

        List<NPCDetails> npcDetailsList = npc_list.npcDetails;

        // Find itemDetail where value contains itemCode.
        NPCDetails npcDetails = npcDetailsList.Find(x => x.npcCode == itemCode);

        if (npcDetails != null)
        {
            return npcDetails.npcName;
        }
        else
        {
            return "";
        }
    }
}
