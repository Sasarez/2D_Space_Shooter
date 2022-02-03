using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // [SerializeField] private float _speed = 2.2f;
    //private int _playerLives = 3;
    [SerializeField] private float _speed = 11.45f;
    public GameObject bullet;
    [SerializeField]
    private float fireDelay;
    [SerializeField]
    private float fireRate = .3f;

    // public bool gameOver = false;

    // public string playerName = "Clara";
    // Start is called before the first frame update
    void Start()
    {
        //Set our players position to 0,0,0 when the game starts.
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKey("space") && Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate;

            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1.05f, 0), Quaternion.identity);
        }
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); ;
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);


        //if the position of the player y is > 6
        //we make the players y 6
        //else if the position of the player y is <-4
        //player position is -4

        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);

        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        //if the position of the players x is < -10.19612 
        //set the position to 10.15831
        //else if the player x position is > 10.15831
        //set the position to -10.19612

        if (transform.position.x < -10.19612)

        {
            transform.position = new Vector3(10.15831f, transform.position.y, 0);

        }
        else if (transform.position.x > 10.15831)
        {
            transform.position = new Vector3(-10.19612f, transform.position.y, 0);
        }
    }
}
