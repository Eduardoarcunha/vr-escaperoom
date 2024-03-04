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
            Debug.Log("Objects in zone: " + count);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            count--;
            Debug.Log("Objects in zone: " + count);
        }
    }

    public int GetCount()
    {
        return count;
    }
}
