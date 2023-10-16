using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOfObjectsScript : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(true);
        }
    }


    void Update()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.activeSelf)
            {
                return; 
            }
        }
        gameObject.SetActive(false);
    }
}
