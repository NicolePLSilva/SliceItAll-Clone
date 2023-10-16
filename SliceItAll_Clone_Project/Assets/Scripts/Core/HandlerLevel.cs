using Random = System.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerLevel : MonoBehaviour
{
    [field: SerializeField] public GameObject PlatformPrefab { get; private set; }
    [field: SerializeField] public GameObject GroundPrefab { get; private set; }
    [field: SerializeField] public Transform Player { get; private set; }
    [field: SerializeField] public int PlatformNumber { get; private set; }

    private GameObject[] allGround;
    private GameObject ground;
    private Vector3 newPlatformPos;
    private int platformIndex;

    void Start()
    {
        ground = GroundPrefab;

        allGround = new GameObject[PlatformNumber];
        for (int i = 0; i < allGround.Length; i++)
        {
            StartLevel();
        }
    }

    void Update()
    {
        if (Player.transform.position.z > newPlatformPos.z - 15)
        {
            AddGround();
        }
        MoveGround();
    }

    public void AddGround()
    {
        allGround[platformIndex].transform.position = newPlatformPos;
        if (PlatformRandomPos() <= 2) 
        {
            newPlatformPos += new Vector3(0f,0f,6f); 
        }
        else
        {
            newPlatformPos += new Vector3(0f,0f,2f); 
            
        }
        platformIndex++;
        if (platformIndex >= 30)
        {
            platformIndex = 0;
        }
    }
 

    public void MoveGround()
    {
        ground.transform.position = new Vector3(0f,-2f, Player.transform.position.z) ;
    }

    int PlatformRandomPos()
    {
        return new Random().Next(1,10);
    }

    public void StartLevel()
    {
        GameObject obj = Instantiate(PlatformPrefab, newPlatformPos, Quaternion.identity);
        allGround[platformIndex] = obj;
        newPlatformPos += new Vector3(0f,0f,2f);
        platformIndex++;
        if (platformIndex >= 30)
        {
            platformIndex = 0;
        }
    }
}
