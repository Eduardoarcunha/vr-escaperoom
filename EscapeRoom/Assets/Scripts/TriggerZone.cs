using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public string zoneId;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            LevelManager.instance.ZoneTriggered(zoneId);
        }
    }
}
