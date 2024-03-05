using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static Action<string> OnOpenDoor;

    private string jailDoor = "JailDoor";
    private string gateDoor = "GateDoor";
    private string escapeDoor = "EscapeDoor";
    private string endZone = "EndZone";
    private string chest = "Chest";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ZoneTriggered(string zoneId)
    {
        if (zoneId == jailDoor)
        {
            OnOpenDoor.Invoke(jailDoor);
            AudioManager.instance.PlaySound("MetalDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");

        }

        if (zoneId == gateDoor)
        {
            OnOpenDoor.Invoke(gateDoor);
            AudioManager.instance.PlaySound("SimpleDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");
        }

        if (zoneId == escapeDoor)
        {
            OnOpenDoor.Invoke(escapeDoor);
            AudioManager.instance.PlaySound("SimpleDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");
        }

        if (zoneId == chest)
        {
            OnOpenDoor.Invoke(chest);
            AudioManager.instance.PlaySound("SimpleDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");
        }

        if (zoneId == endZone)
        {
            GameManager.instance.EndGame();
        }
    }
}
