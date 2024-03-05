using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBoard : MonoBehaviour
{
    public TriggerZoneCounter[] triggerZones;
    public int[] correctAnswers;
    bool isDone = false;

    void Update()
    {
        if (isDone)
        {
            return;
        }

        if (triggerZones.Length != correctAnswers.Length)
        {
            Debug.LogError("Error: Mismatch in the number of trigger zones and correct answers");
            return;
        }

        bool correctAnswer = true;
        for (int i = 0; i < triggerZones.Length; i++)
        {
            if (triggerZones[i].GetCount() != correctAnswers[i])
            {
                correctAnswer = false;
                break;
            }
        }

        if (correctAnswer)
        {
            isDone = true;
            LevelManager.instance.ZoneTriggered("EscapeDoor");
        }
    }
}
