using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded == true && controller.velocity.magnitude > 2f && AudioManager.instance.IsPlaying("Footsteps") == false)
        {
            AudioManager.instance.PlaySound("Footsteps");
        }
        else
        {
            AudioManager.instance.StopSound("Footsteps");
        }
    }
}
