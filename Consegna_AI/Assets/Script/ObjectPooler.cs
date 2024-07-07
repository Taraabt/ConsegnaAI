using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] int amount;

    public List<GameObject> activeTree = new List<GameObject>();
    [SerializeField] GameObject treePrefab;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        for (int i = 0;i<amount;i++)
        {
            GameObject obj = Instantiate(treePrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj); 
        }
    }
    public GameObject GetObj()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                activeTree.Add(pooledObjects[i]);
                return pooledObjects[i];
            }
        }
        return null;
    }
}
