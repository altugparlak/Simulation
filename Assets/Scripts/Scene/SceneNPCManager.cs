using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneNPCManager : SingletonMonobehaviour<SceneNPCManager>
{
    private Dictionary<int, NPCDetails> npcDetailsDictionary;
    [SerializeField] private NPC npcList = null;

    [SerializeField] public GameObject InfoPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialogueButton;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueButtonText;

    private string[] dialogue;
    private string buttonAnswer;

    NPCType talkingNPCtype;

    [HideInInspector] public bool isNPCtalkActivated = false;
    private int index = 0;

    private void Start()
    {
        CreateNpcDetailsDictionary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isNPCtalkActivated)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                NextLine();
            }
            else
            {
                dialoguePanel.SetActive(true);
                Type();
            }
        }

        if (dialogueText != null && dialogue != null)
        {
            if (dialogueText.text == dialogue[index])
                dialogueButton.SetActive(true);
        }


    }

    public void noText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    private void Type()
    {
        dialogueText.text = dialogue[index];
    }

    public void NextLine()
    {
        dialogueButton.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            Type();
        }
        else
        {
            ShopActive();
            noText();
        }
    }

    private void ShopActive()
    {
        shopPanel.SetActive(true);
    }
    public void ShopDeactive()
    {
        shopPanel.SetActive(false);
    }

    public void ResetNPCvalues()
    {

    }

    public void GetTalkingNPCData(string[] diaTalk, string buttonAnswerText, NPCType npcType)
    {
        dialogue = diaTalk;
        buttonAnswer = buttonAnswerText;
        talkingNPCtype = npcType;
    }

    private void CreateNpcDetailsDictionary()
    {
        npcDetailsDictionary = new Dictionary<int, NPCDetails>();

        foreach (NPCDetails nPCDetails in npcList.npcDetails)
        {
            npcDetailsDictionary.Add(nPCDetails.npcCode, nPCDetails);
        }
    }

    public NPCDetails GetNpcDetails(int npcCode)
    {
        NPCDetails nPCDetails;

        if (npcDetailsDictionary.TryGetValue(npcCode, out nPCDetails))
        {
            return nPCDetails;
        }
        else
        {
            return null;
        }
    }

}
