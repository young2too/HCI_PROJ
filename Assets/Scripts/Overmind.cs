using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Overmind : MonoBehaviour
{

    static public Overmind instance { get; private set; }

    public float timeLimit;
    float elapsedTime;

    public GameObject loseText;
    public GameObject winText;
    public GameObject pausedText;
    public Text timeText;
    public string remain_time;

    Vector3 playerStartingPos;
    Quaternion playerStartingRotation;

    bool gameEnded;

    void Awake()
    {
        instance = this;
        gamePaused = false;
    }

    void Start()
    {
        Time.timeScale = 1;
        elapsedTime = 0;
        playerStartingPos = Player.instance.transform.position;
        playerStartingRotation = Player.instance.transform.rotation;
    }

    public void LoseGame()
    {
        loseText.SetActive(true);
        EndGame();
    }

    public void WinGame()
    {
        winText.SetActive(true);
        EndGame();
    }

    void EndGame()
    {
        Time.timeScale = 0;
        elapsedTime = 0;
        gameEnded = true;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P) && !gameEnded)
        {
            TogglePause();
        }

        if (!gameEnded)
        {
            elapsedTime += Time.deltaTime;
            timeText.text = ((int)timeLimit - (int)elapsedTime).ToString();
            remain_time = (timeLimit - elapsedTime).ToString();
            if (elapsedTime >= timeLimit)
                LoseGame();
        }
        else
        {
            elapsedTime += Time.unscaledDeltaTime;
            if (Input.anyKeyDown && !Input.GetKey(KeyCode.Escape) && elapsedTime > 1.5f)
            {
                gameEnded = false;
                Time.timeScale = 1;
                elapsedTime = 0f;
                Player.instance.transform.position = playerStartingPos;
                Player.instance.transform.rotation = playerStartingRotation;
                loseText.SetActive(false);
                winText.SetActive(false);
            }
        }

    }

    public bool gamePaused { get; private set; }
    void TogglePause()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused ? 0f : 1f;
        pausedText.SetActive(gamePaused);
    }
}
