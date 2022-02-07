using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 11.45f;
    [SerializeField] private float _speedPowerup = 20f;
    public GameObject bullet;
    [SerializeField]
    private float fireDelay;
    [SerializeField]
    AudioClip _laserFire;
    [SerializeField]
    AudioClip _powerupPickup;
    AudioSource _audioSource;

    [SerializeField]
    private float fireRate = .3f;
    [SerializeField]
    private int _playerLives = 5;
    private int _score = 0;
    private bool _speedActive = false;
    private bool _tripleshotActive = false;
    private bool _shieldActive = false;

    GameObject _spawnManager;
    [SerializeField]
    GameObject _tripleShot;
    [SerializeField]
    GameObject _shield;
    UIManager _uiManager;
    [SerializeField]
    GameObject _rightThruster;
    [SerializeField]
    GameObject _leftThruster;


    void Start()
    {
        //_uiManager = GameObject.Find("UI_Manager");
        _uiManager = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();
        //AudioSource _laserFire = GetComponent<AudioSource>();
        transform.position = new Vector3(0, 0, 0);
        _score = 0;
        _spawnManager = GameObject.Find("Spawn_Manager");
        //_tripleShot = GameObject.Find("Triple_Shot");
        if (_audioSource == null)
        {
            Debug.LogError("AudioSource on Player is NULL");
        }
        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
        if (_spawnManager == null)
        {
            Debug.LogError("Spawn Manager is null");
        }
    }
    void Update()
    {
        Movement();
        if (Input.GetKey("space") && Time.time > fireDelay)
        {
            ShootBullet();
        }
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); ;
        float verticalInput = Input.GetAxis("Vertical");
        if (_speedActive == false)
        {
            transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * horizontalInput * _speedPowerup * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * _speedPowerup * Time.deltaTime);
        }




        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y < -2.53)
        {
            transform.position = new Vector3(transform.position.x, -2.53f, 0);
        }
        if (transform.position.x < -10.19612)
        {
            transform.position = new Vector3(10.15831f, transform.position.y, 0);
        }
        else if (transform.position.x > 10.15831)
        {
            transform.position = new Vector3(-10.19612f, transform.position.y, 0);
        }
    }
    void ShootBullet()
    {
        fireDelay = Time.time + fireRate;
        if (_tripleshotActive == true)
        {
            Instantiate(_tripleShot, new Vector3(transform.position.x - 1.37f, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.05f, 0), Quaternion.identity);
        }
        _audioSource.clip = _laserFire;
        _audioSource.Play();

    }
    public void CollectedTripleShot()
    {

        AudioSource.PlayClipAtPoint(_powerupPickup, transform.position);
        _tripleshotActive = true;
        StopCoroutine("TripShotTimer");
        StartCoroutine("TripShotTimer");
    }
    public void CollectedSpeed()
    {

        AudioSource.PlayClipAtPoint(_powerupPickup, transform.position);
        _speedActive = true;

        StopCoroutine("SpeedTimer");
        StartCoroutine("SpeedTimer");
    }
    public void CollectedShield()
    {

        AudioSource.PlayClipAtPoint(_powerupPickup, transform.position);
        _shield.SetActive(true);
        _shieldActive = true;
    }
    public void Damage()
    {
        if (_shieldActive == true)
        {
            _shield.SetActive(false);
            _shieldActive = false;
            return;
        }
        _playerLives--;
        switch (_playerLives)
        {
            case 2:
                _rightThruster.SetActive(true);
                break;
            case 1:
                _leftThruster.SetActive(true);
                break;
            case 3:
                _rightThruster.SetActive(false);
                _leftThruster.SetActive(false);
                break;
        }
        _uiManager.UpdateLives(_playerLives);


        if (_playerLives <= 0)
        {
            Spawner spawner = _spawnManager.transform.GetComponent<Spawner>();
            if (spawner != null)
            {
                spawner.PlayerDied();
            }
            Destroy(gameObject);
        }
    }

    IEnumerator TripShotTimer()
    {
        yield return new WaitForSeconds(4);
        _tripleshotActive = false;

    }
    IEnumerator SpeedTimer()
    {
        yield return new WaitForSeconds(4);
        _speedActive = false;
    }
    public void Score(int score)
    {
        _score = _score + score;
        // 
        _uiManager.UpdateScore(_score);




    }
}
