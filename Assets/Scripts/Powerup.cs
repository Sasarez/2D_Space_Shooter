using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = -3;
    private Player _player;
    [SerializeField]
    int powerupID; //0 triple shot, 1 speed, 2 shield
    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5.38)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            _player = other.transform.GetComponent<Player>();
            if (_player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        _player.CollectedTripleShot();
                        break;
                    case 1:
                        _player.CollectedSpeed();
                        break;
                    case 2:
                        _player.CollectedShield();
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
