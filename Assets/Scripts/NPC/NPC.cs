using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCList", menuName = "Scriptable Objects/NPC/NPC List")]
public class NPC : ScriptableObject
{
    [SerializeField] public List<NPCDetails> npcDetails;

}
