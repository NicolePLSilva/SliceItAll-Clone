using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScript : MonoBehaviour
{   
    [field: SerializeField] public bool Hit{ get; set;}

    private void OnTriggerEnter(Collider other)
    {   
        if (!(other.tag.Equals("Platform") || other.tag.Equals("Sliceble"))) { return; }
      
        Hit = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        Hit = false;
    }
}
