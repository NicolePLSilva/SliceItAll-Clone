using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicebleObjectScript : MonoBehaviour
{
    [field: SerializeField] public GameObject UncutObject{ get; private set; }
    [field: SerializeField] public GameObject LeftSlicedObject{ get; private set; }
    [field: SerializeField] public GameObject RightSlicedObject{ get; private set; }
    [field: SerializeField] public float Distance{ get; private set; }
    [field: SerializeField] public float Force{ get; private set; }


    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.tag.Equals("Blade")){ return; }

        gameObject.SetActive(false);

        // LeftSlicedObject.AddComponent<Rigidbody>();
        // RightSlicedObject.AddComponent<Rigidbody>();

        // LeftSlicedObject.GetComponent<Rigidbody>().AddForce(new Vector3(-Force, .3f, 0f), ForceMode.Impulse);
        // RightSlicedObject.GetComponent<Rigidbody>().AddForce(new Vector3(Force, .3f, 0f), ForceMode.Impulse);

        // LeftSlicedObject.SetActive(false);
        // RightSlicedObject.SetActive(false);
    }

}
