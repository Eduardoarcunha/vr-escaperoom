using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static Action<string> OnOpenDoor;

    private int currentPuzzle = 1;
    private string jailDoor = "JailDoor";
    private string gateDoor = "GateDoor";
    private string escapeDoor = "EscapeDoor";

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
        if (zoneId == jailDoor && currentPuzzle == 1)
        {
            Debug.Log("DoorOpened");
            currentPuzzle++;
            OnOpenDoor.Invoke(jailDoor);
            AudioManager.instance.PlaySound("MetalDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");

        }

        if (zoneId == gateDoor)
        {
            Debug.Log("DoorOpened");
            currentPuzzle++;
            OnOpenDoor.Invoke(gateDoor);
            AudioManager.instance.PlaySound("SimpleDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");
        }

        if (zoneId == escapeDoor)
        {
            Debug.Log("DoorOpened");
            currentPuzzle++;
            OnOpenDoor.Invoke(escapeDoor);
            AudioManager.instance.PlaySound("SimpleDoorOpen");
            AudioManager.instance.PlaySound("PuzzleDone");
        }
    }
}
