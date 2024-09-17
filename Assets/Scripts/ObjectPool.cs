using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public GameObject[] objectPrefabs; 
    public int initialCount = 3;

    private List<GameObject>[] pools;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        pools = new List<GameObject>[objectPrefabs.Length];
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
            for (int j = 0; j < initialCount; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[i]);
                obj.SetActive(false);
                pools[i].Add(obj);
            }
        }
    }

    public GameObject GetObject(int tipo)
    {
        foreach (GameObject obj in pools[tipo])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObject = Instantiate(objectPrefabs[tipo]);
        newObject.SetActive(true);
        pools[tipo].Add(newObject);
        return newObject;
    }
}