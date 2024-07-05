using System.Collections;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] int treeToSpawn;
    [SerializeField] int mapsize;
    [SerializeField] GameObject tree;
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
    IEnumerator SpawnTree()
    {
        for (int i=0;i<treeToSpawn;i++)
        {
            Vector3 pos = new Vector3(Random.Range(-mapsize / 2, mapsize / 2) + 0.5f, 0, Random.Range(-mapsize / 2, mapsize / 2) + 0.5f);
            Debug.Log(pos);
            Instantiate(tree, pos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}