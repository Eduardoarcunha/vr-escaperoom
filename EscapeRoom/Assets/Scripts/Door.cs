using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorId;
    private Animator animator;
    private string animatorBoolName = "isOpen";

    void Awake()
    {
        animator = GetComponent<Animator>();
        LevelManager.OnOpenDoor += OnToogleDoorEvent;
    }

    public void OnToogleDoorEvent(string doorToOpenId)
    {
        if (doorId == doorToOpenId)
        {
            bool isOpen = animator.GetBool(animatorBoolName);
            animator.SetBool(animatorBoolName, !isOpen);
        }
    }

    void OnDestroy()
    {
        LevelManager.OnOpenDoor -= OnToogleDoorEvent;
    }
}
