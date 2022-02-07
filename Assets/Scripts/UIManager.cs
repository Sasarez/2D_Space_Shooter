using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _gameOverText;
    [SerializeField]
    Text _scoreText;
    [SerializeField]
    Image _livesImg;
    [SerializeField]
    Sprite[] _livesArray;
    [SerializeField]
    Text _restartText;
    GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.Log("Game Manager is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateScore(int score)
    {

        _scoreText.text = "Score " + score;

    }
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _livesArray[currentLives];
        if (currentLives <= 0)
        {
            StartCoroutine(GameOver());
            _restartText.gameObject.SetActive(true);

            _gameManager.SetGameOver();

        }
    }
    IEnumerator GameOver()
    {
        while (true)
        {
            yield return new WaitForSeconds(.25f);
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.25f);
            _gameOverText.gameObject.SetActive(false);
        }


    }
}
