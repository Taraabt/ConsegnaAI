using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] int treeToSpawn;
    [SerializeField] int mapsize;
    [SerializeField] GameObject tree;

    private void Start()
    {
        StartCoroutine(SpawnTree());
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
    }
    public static Vector3 GenerateRandomPosition(float minX, float maxX, float minY, float maxY, float minZ, float maxZ, float excludeMinX, float excludeMaxX, float excludeMinY, float excludeMaxY, float excludeMinZ, float excludeMaxZ)
    {
        Vector3 position;
        do
        {
            position = new Vector3(
                Random.Range(minX+0.5f, maxX+0.5f),
                Random.Range(minY, maxY),
                Random.Range(minZ+0.5f, maxZ+0.5f)
            );
        }
        while (
            (position.x >= excludeMinX && position.x <= excludeMaxX) ||
            (position.y >= excludeMinY && position.y <= excludeMaxY) ||
            (position.z >= excludeMinZ && position.z <= excludeMaxZ)
        );

        return position;
    }
    IEnumerator SpawnTree()
    {
        for (int i=0;i<treeToSpawn;i++)
        {

            Vector3 pos = new Vector3(Random.Range(-mapsize / 2, mapsize / 2) + 0.5f, 0, Random.Range(-(mapsize / 2)+1, mapsize / 2) + 0.5f);
            Debug.Log(pos);
            GameObject obj=ObjectPooler.Instance.GetObj();
            if (obj != null )
            {
                obj.transform.position = GenerateRandomPosition(-mapsize / 2, mapsize / 2, 0, 0, -(mapsize / 2) + 1, mapsize / 2, -12.5f, -3.5f, 0, 0, -11.5f, -2.5f);
                obj.SetActive(true);
            }

            yield return new WaitForSeconds(0f);
        }
    }
}
