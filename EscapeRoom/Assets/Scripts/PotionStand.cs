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
            if (socketInteractor.hasSelection)
            {
                // Get the oldest interactable selected by this interactor
                IXRSelectInteractable selectedInteractable = socketInteractor.GetOldestInteractableSelected();

                // Cast to XRBaseInteractable or your specific interactable type
                XRBaseInteractable baseInteractable = selectedInteractable as XRBaseInteractable;

                // Proceed if the cast is successful and we have a valid selected interactable
                if (baseInteractable != null)
                {
                    GameObject selectedObject = baseInteractable.gameObject;

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
        }
        if (greenPotion && bluePotion && whitePotion && !isDone)
        {
            isDone = true;
            LevelManager.instance.ZoneTriggered(zoneId);
        }
    }


}
