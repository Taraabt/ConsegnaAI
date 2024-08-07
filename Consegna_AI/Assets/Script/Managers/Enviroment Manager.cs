using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] int treeToSpawn;
    [SerializeField] int foodToSpawn;
    [SerializeField] int mapsize;
    [SerializeField] GameObject tree;

    private void Start()
    {
        StartCoroutine(SpawnTree());
        StartCoroutine(SpawnFood());

    }
    private void OnEnable()
    {
        TimeManager.ItsNight += CreateTree;
    }
    private void OnDisable()
    {
        TimeManager.ItsNight += CreateTree;
    }
    private void CreateTree()
    {
        StartCoroutine(SpawnTree());
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnTree()
    {
        for (int i=0;i<treeToSpawn;i++)
        {
            Vector3 pos;
            //Vector3 pos = new Vector3(Random.Range(-mapsize / 2, mapsize / 2) + 0.5f, 0, Random.Range(-(mapsize / 2)+1, mapsize / 2) + 0.5f);
            //Debug.Log(pos);
            do
            {
                pos = new Vector3(Random.Range(-mapsize / 2, mapsize / 2) + 0.5f,0,Random.Range(-(mapsize / 2) + 1, mapsize / 2) + 0.5f);
            }
            while ((pos.x >= -12.5f && pos.x <= -3.5f) &&(pos.z >= -11.5f && pos.z <= -2.5f));
            GameObject obj=ObjectPooler.Instance.GetTree();
            if (obj != null )
            {
                obj.transform.position = pos;
                obj.SetActive(true);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator SpawnFood()
    {
        for (int i = 0; i < foodToSpawn; i++)
        {
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(-mapsize / 2, mapsize / 2) + 0.5f, 0, Random.Range(-(mapsize / 2) + 1, mapsize / 2) + 0.5f);
            }
            while ((pos.x >= -12.5f && pos.x <= -3.5f) && (pos.z >= -11.5f && pos.z <= -2.5f));
            GameObject obj = ObjectPooler.Instance.GetFood();
            if (obj != null)
            {
                obj.transform.position = pos;
                obj.SetActive(true);
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

}
