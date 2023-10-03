using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<Node> spawnPos = new List<Node>();
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());   
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            int randomPos = Random.Range(0, spawnPos.Count);
            GameObject enemy = Instantiate(enemyPrefab, spawnPos[randomPos].transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
        }
    }
}
