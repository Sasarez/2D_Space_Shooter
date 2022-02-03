using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float _speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

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
