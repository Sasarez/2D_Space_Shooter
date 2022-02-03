using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int _score = 0;
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters a second
        //if at the bottom of the screen respawn at the top in a random x position

        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //pos at top is 7.44
        //pos at bottom is -5.38
        //far left -8.48 far right 8.45
        if (transform.position.y < -5.38)
        {
            transform.position = new Vector3(Random.Range(-8.48f, 8.45f), 7.44f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // if we collide with the player
        // we want to decrease lives of the player
        // destroy this
        // else if we collide with a bullet
        // we just want to destroy this
        if (other.transform.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(gameObject);
        }
        else if (other.transform.tag == "Projectile")
        {
            _score = _score + 10;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
