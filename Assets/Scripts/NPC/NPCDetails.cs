using UnityEngine;

[System.Serializable]
public class NPCDetails
{
    public int npcCode;
    public NPCType npcType;
    public string npcName;
    public string[] dialogue;
    public string continueButtonText;
    public string answerButtonText;
    public Sprite npcGameSprite;
    public Sprite npcUISprite;

    public bool canBeTalkable;
    

}
