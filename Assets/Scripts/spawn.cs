using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime;

    private GameObject enemyObject;

    private void Start()
    {
        StartCoroutine(WaitAndPrint(spawnTime));
    }
    private void CreateCar()
    {
            enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CreateCar();
        StartCoroutine(WaitAndPrint(spawnTime));
    }
}