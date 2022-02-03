using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
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
        while (true)
        {
            Instantiate(_enemy, new Vector3(Random.Range(-8, 8), -11, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
}
