using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGoldDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerGold;
    private void OnEnable()
    {
        EventHandler.GameGoldEvent += UpdateGameGold;
    }

    private void OnDisable()
    {
        EventHandler.GameGoldEvent -= UpdateGameGold;
    }

    private void UpdateGameGold(int gold)
    {
        playerGold.text = gold.ToString();
    }
}
