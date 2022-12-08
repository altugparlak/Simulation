using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Scenes
    public const string Game = "Game";

    // Obscuring Item Fading - ObscuringItemFader
    public const float fadeInSeconds = 0.25f;
    public const float fadeOutSeconds = 0.35f;
    public const float targetAlpha = 0.45f;


    // Player Movement
    public const float runningSpeed = 0.2f;
    public const float walkingSpeed = 0.1f;

    // Inventory
    public static int playerInitialInventoryCapacity = 24;
    public static int playerMaximumInventoryCapacity = 48;


    // Player Animation Parameters
    public const string TurningState = "TurningState";



}
