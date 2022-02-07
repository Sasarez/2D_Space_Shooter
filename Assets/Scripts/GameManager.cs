using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _gameOver = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver && Input.GetKey("r"))
        {
            _gameOver = false;
            SceneManager.LoadScene(1);
        }
    }

    public void SetGameOver()
    {
        _gameOver = true;
    }
}
