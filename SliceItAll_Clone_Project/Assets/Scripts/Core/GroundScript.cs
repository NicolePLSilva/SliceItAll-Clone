using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        KnifeScript knife = other.GetComponent<KnifeScript>();
        if (knife == null) { return; }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
