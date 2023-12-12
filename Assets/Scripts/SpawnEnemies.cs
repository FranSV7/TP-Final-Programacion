using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] enemy;
    public bool spawning = true;
    private int enemyCount;
    [SerializeField] private float spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(Spawner());

    }

    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (spawning == true && enemyCount <= 10)
        {
            yield return wait;
            int spa = Random.Range(0, enemy.Length);
            GameObject enemyToSpawn = enemy[spa];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);

            enemyCount++;
        }
        
    }


}
