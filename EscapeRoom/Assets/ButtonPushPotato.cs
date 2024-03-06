using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushPotato : MonoBehaviour
{
    public GameObject potatoPrefab;
    public Transform potatoSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRBaseInteractable>().selectEntered.AddListener(x => InstantiatePotato());
    }

    // Update is called once per frame
    void InstantiatePotato()
    {
        AudioManager.instance.PlaySound("SimpleClickSound");
        Instantiate(potatoPrefab, potatoSpawnPoint.position, potatoSpawnPoint.rotation);
    }
}
