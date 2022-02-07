using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    [SerializeField]
    GameObject _explosion;
    Spawner _spawner;
    private float _speed = 4;

    void Start()
    {

        _spawner = GameObject.Find("Spawn_Manager").GetComponent<Spawner>();

        if (_spawner == null)
        {
            Debug.LogError("Spawner is Null!");
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, _speed * 4 * Time.deltaTime), Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {

            GameObject _asteroidExplosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            _spawner.BeginSpawning();

            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Destroy(_asteroidExplosion, 3f);
        }
    }
}
