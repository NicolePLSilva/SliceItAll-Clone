using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableUncut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SlicebleObjectScript sliceble = other.GetComponent<SlicebleObjectScript>();
        if (sliceble == null) { return; }

        sliceble.gameObject.SetActive(false);
    }
}
