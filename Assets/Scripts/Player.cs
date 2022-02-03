using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 11.45f;
    public GameObject bullet;
    [SerializeField]
    private float fireDelay;
    [SerializeField]
    private float fireRate = .3f;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
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

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
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
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.05f, 0), Quaternion.identity);
    }
}
