using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class SkullLever : MonoBehaviour
{
    private bool enabledOnce = false;
    private XRLever lever;

    void Awake()
    {
        lever = GetComponent<XRLever>();
    }


    void Update()
    {
        if (enabledOnce == false)
        {
            if (lever.value == false)
            {
                enabledOnce = true;
                LevelManager.instance.ZoneTriggered("Chest");
            }
        }
    }
}
