using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;
    List<GameObject> pooledTree = new List<GameObject>();
    public List<GameObject> pooledFood = new List<GameObject>();
    [SerializeField] int amount;

    public List<GameObject> activeTree = new List<GameObject>();
    [SerializeField] GameObject treePrefab;
    [SerializeField] GameObject foodPrefab;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        Time.timeScale = 0;
        for (int i = 0;i<amount;i++)
        {
            GameObject obj1 = Instantiate(treePrefab);
            obj1.SetActive(false);
            pooledTree.Add(obj1);
            GameObject obj2 = Instantiate(foodPrefab);
            obj2.SetActive(false);
            pooledFood.Add(obj2);
        }
    }
    public GameObject GetFood()
    {
        for(int i = 0; i < pooledFood.Count; i++)
        {
            if (!pooledFood[i].activeInHierarchy)
            {
                return pooledFood[i];
            }
        }
        return null;
    }
    public GameObject GetTree()
    {
        for (int i = 0; i < pooledTree.Count; i++)
        {
            if (!pooledTree[i].activeInHierarchy)
            {
                activeTree.Add(pooledTree[i]);
                return pooledTree[i];
            }
        }
        return null;
    }
}
