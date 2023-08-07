using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicebleObjectScript : MonoBehaviour
{
    [field: SerializeField] public GameObject UncutObject{ get; private set; }
    [field: SerializeField] public GameObject LeftSlicedObject{ get; private set; }
    [field: SerializeField] public GameObject RightSlicedObject{ get; private set; }
    [field: SerializeField] public float Force{ get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.tag.Equals("Player")){ return; }

        Destroy(UncutObject);

        LeftSlicedObject.AddComponent<Rigidbody>();
        RightSlicedObject.AddComponent<Rigidbody>();

        LeftSlicedObject.GetComponent<Rigidbody>().AddForce(new Vector3(-Force, .3f, 0f), ForceMode.Impulse);
        RightSlicedObject.GetComponent<Rigidbody>().AddForce(new Vector3(Force, .3f, 0f), ForceMode.Impulse);

        Destroy(this.gameObject, 3f);
    }

}
