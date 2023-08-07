using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerScript : MonoBehaviour
{   
    [field: SerializeField] public bool Hit{ get; set;}

    private void OnCollisionEnter(Collision other)
    {
        Hit = true;
    }

    private void OnCollisionExit(Collision other)
    {
        Hit = false;
    }
}
