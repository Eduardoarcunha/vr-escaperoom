using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneCounter : MonoBehaviour
{
    private int count = 0;
    public string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            count--;
        }
    }

    public int GetCount()
    {
        return count;
    }
}
