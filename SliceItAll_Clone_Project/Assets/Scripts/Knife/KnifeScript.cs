using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [field: SerializeField] public bool HitPlatform{ get; set;}
    [field: SerializeField] public bool CanSpin{ get; set;}
    

    Rigidbody myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(!CanSpin){ return; }
        StartCoroutine(SpinCoroutine());
    }

    private IEnumerator SpinCoroutine()
    {
        myRigid.useGravity = false;
        yield return new WaitForSeconds(.5f);
        CanSpin = false;
        myRigid.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Platform")) { return; }
        Debug.Log("Hit");
        HitPlatform = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if(!other.tag.Equals("Platform")) { return; }

        HitPlatform = false;    
    }
}
