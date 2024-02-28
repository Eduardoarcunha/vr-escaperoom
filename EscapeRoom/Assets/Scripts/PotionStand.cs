using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PotionStand : MonoBehaviour
{

    private XRSocketInteractor[] socketInteractors;

    private bool greenPotion;
    private bool bluePotion;
    private bool whitePotion;
    private string zoneId = "GateDoor";
    private bool isDone = false;

    void Start()
    {
        // Get all XRSocketInteractor components in children
        socketInteractors = GetComponentsInChildren<XRSocketInteractor>();
        greenPotion = false;
        bluePotion = false;
        whitePotion = false;
    }


    void Update()
    {
        greenPotion = false;
        bluePotion = false;
        whitePotion = false;
        foreach (var socketInteractor in socketInteractors)
        {
            if (socketInteractor.selectTarget != null)
            {
                GameObject selectedObject = socketInteractor.selectTarget.gameObject;
                Debug.Log("Selected Object: " + selectedObject.name);

                if (selectedObject.GetComponent<Potion>().potionType == PotionType.Blue)
                {
                    bluePotion = true;
                }
                else if (selectedObject.GetComponent<Potion>().potionType == PotionType.Green)
                {
                    greenPotion = true;
                }
                else if (selectedObject.GetComponent<Potion>().potionType == PotionType.White)
                {
                    whitePotion = true;
                }
            }
        }
        if (greenPotion && bluePotion && whitePotion && !isDone)
        {
            Debug.Log("Correct Answer!");
            isDone = true;
            LevelManager.instance.ZoneTriggered(zoneId);
        }

    }
}
