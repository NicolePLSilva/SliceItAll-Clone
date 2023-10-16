using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Random = System.Random;

public class ObjectPool : MonoBehaviour
{
        [SerializeField] GameObject[] prefab;
        [SerializeField] int poolSize = 4;

        GameObject[] pool;
        Vector3 newPos;

        void Awake()
        {
            PopulatePool();
            newPos = this.transform.position;
        }

        void Start() 
        {
            StartCoroutine(SpawnObject());    
        }

        private void PopulatePool()
        {
            pool = new GameObject[poolSize];
            for (int i = 0; i < pool.Length; i++)
            {
                pool[i] = Instantiate(prefab[GetRamdom()], this.transform);
                pool[i].SetActive(false);
            }
        }

        void EnableObjectInPool()
        {
            for(int i = 0; i < pool.Length; i++)
            {
                if(pool[i].activeInHierarchy == false)
                {
                    SetObjectNewPosition(i);
                    pool[i].SetActive(true);
                    return;
                }    
            }
        }

        IEnumerator SpawnObject()
        {
            while (true)
            {
                EnableObjectInPool();
                yield return null;
            }
        }

        private void SetObjectNewPosition(int index)
        {
            pool[index].transform.position = newPos;
            newPos += new Vector3(0f, 0f, 5f);
        }


        private int GetRamdom()
        {
            return new Random().Next(0, prefab.Length);
        }

}
