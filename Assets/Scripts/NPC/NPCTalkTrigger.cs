using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(BoxCollider2D))]
public class NPCTalkTrigger : MonoBehaviour
{
    [NPCDescriptionAttiribute]
    [SerializeField]
    private int _npcCode;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneNPCManager.Instance.isNPCtalkActivated = true;
            SceneNPCManager.Instance.InfoPanel.GetComponent<Animator>().SetBool("InfoShow", true);
            NPCDetails nPCDetails = SceneNPCManager.Instance.GetNpcDetails(_npcCode);
            SceneNPCManager.Instance.GetTalkingNPCData(nPCDetails.dialogue, nPCDetails.answerButtonText, nPCDetails.npcType);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneNPCManager.Instance.ShopDeactive();
            SceneNPCManager.Instance.isNPCtalkActivated = false;
            SceneNPCManager.Instance.noText();
            SceneNPCManager.Instance.InfoPanel.GetComponent<Animator>().SetBool("InfoShow", false);

        }
    }

    
}
