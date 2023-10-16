using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [field: SerializeField] public bool HitPlatform{ get; set;}
    [field: SerializeField] public bool CanSpin{ get; set;}


    private Rigidbody myRigid;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.tag.Equals("Platform")) { return; }
        HitPlatform = true;
    }

    private void OnTriggerExit(Collider other) 
    {
        if(!other.tag.Equals("Platform")) { return; }

        HitPlatform = false;    
    }

    public void HandlerCoroutines(float delayGravity, float rotationDuration)
    {
        StartCoroutine(HandlerGravityCoroutine(delayGravity));
        StartCoroutine(HandlerRotateCoroutine(rotationDuration));
    }


    public IEnumerator HandlerGravityCoroutine(float delay)
    {
        myRigid.useGravity = false;
        yield return new WaitForSeconds(delay);
        myRigid.useGravity = true;
    }

    public IEnumerator HandlerRotateCoroutine(float duration)
    {     
        Quaternion startRot = this.transform.rotation;
        float t = 0.0f;
        while ( t  < duration )
        {
            t += Time.deltaTime;
            this.transform.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.right); 
            yield return null;
        }
        this.transform.rotation = startRot;
    }
}
