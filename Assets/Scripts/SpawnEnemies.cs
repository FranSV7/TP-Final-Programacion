using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject[] enemy;
    public bool spawning = true;
    public int enemyCount;
    [SerializeField] private float spawnRate = 2f;
    public GameManager manager;

    private void Start()
    {
        StartCoroutine(Spawner());

    }
    
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (spawning == true)
        {
            if(enemyCount < 10)
            {
                
                int spa = Random.Range(0, enemy.Length);
                GameObject enemyToSpawn = enemy[spa];

                int spawnIndex = Random.Range(0, spawnPoint.Length);
                GameObject selectedSpawnPoint = spawnPoint[spawnIndex];

                GameObject newEnemy = Instantiate(enemyToSpawn, selectedSpawnPoint.transform.position, Quaternion.identity);

                newEnemy.GetComponent<Enemy>().gameManager = manager;

                enemyCount++;
            }

            yield return wait;  
        }
        
    }


}
