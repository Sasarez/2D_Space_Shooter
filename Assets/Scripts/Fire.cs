using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float _speed = 10;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, _speed * Time.deltaTime, 0));
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
}
