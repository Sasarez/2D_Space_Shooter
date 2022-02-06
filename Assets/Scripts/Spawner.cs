using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy;
    [SerializeField]

    float _waitTime = 3f;
    [SerializeField]
    GameObject _enemyContainer;
    [SerializeField]
    GameObject[] powerups;
    [SerializeField]
    GameObject _powerupContainer;
    bool spawningEnemies = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //spawn our enemy every 5 seconds
    //create a coroutine of type IEnumerator
    //in an infinite while loop
    IEnumerator SpawnRoutine()
    {
        while (spawningEnemies)
        {
            GameObject newEnemy = Instantiate(_enemy, new Vector3(Random.Range(-8, 8), -11, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(Random.Range(.5f, _waitTime));
        }
    }
    IEnumerator PowerUpSpawnRoutine()
    {
        while (spawningEnemies)
        {

            yield return new WaitForSeconds(Random.Range(7, 11));
            int i = Random.Range(0, 3);
            GameObject newPowerup = Instantiate(powerups[i], new Vector3(Random.Range(-8, 8), 8, 0), Quaternion.identity);
            newPowerup.transform.parent = _powerupContainer.transform;
        }
    }
    public void PlayerDied()
    {
        spawningEnemies = false;
    }
}
