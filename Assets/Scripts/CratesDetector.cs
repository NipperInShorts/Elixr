using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CratesDetector : MonoBehaviour
{


    public UnityEvent onUpdateCratesTossed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crate")) {
            onUpdateCratesTossed?.Invoke();
        }
    }
}
