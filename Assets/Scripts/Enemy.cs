using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    AudioClip _explosionAudio;
    AudioSource _audioSource;
    Animator enemyDeathAnim;
    private float _speed = 4f;
    // Start is called before the first frame update
    GameObject _player;
    bool _enemyDead = false;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GetComponent<AudioSource>();
        enemyDeathAnim = GetComponent<Animator>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source on the Enemy is NULL");
        }
        if (enemyDeathAnim == null)
        {
            Debug.LogError("Death Animation is Null!");

        }

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
        if (transform.position.y < -5.38 && !_enemyDead)
        {
            transform.position = new Vector3(Random.Range(-8.48f, 8.45f), 7.44f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)


    {

        if (other.transform.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _audioSource.clip = _explosionAudio;
            _audioSource.Play();
            EnemyDeath();
        }
        else if (other.transform.tag == "Projectile")
        {
            Player player = _player.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Score(10);
            }
            _audioSource.clip = _explosionAudio;
            _audioSource.Play();
            Destroy(other.gameObject);
            EnemyDeath();


            //Destroy(gameObject);
        }
    }
    void EnemyDeath()
    {
        _speed = 0;
        gameObject.GetComponent<Collider2D>().enabled = false;
        enemyDeathAnim.SetTrigger("OnEnemyDeath");
        Destroy(gameObject, 2.5f);
    }

}
