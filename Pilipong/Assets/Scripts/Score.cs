using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] AudioClip scoreSFX;
    [SerializeField] TextMeshProUGUI scoreText;
    public GameLogic gameLogic;
    Lose loseScript;

    public static int scoreCount = 0;

    private void Update()
    {
        scoreText.text = "Player: " + scoreCount.ToString();
        ResetOnWin();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            addScore();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(scoreSFX);
            
            if (scoreCount <= 2)
            {
                Invoke("ReloadScene", gameLogic.delay);
            }
        }
    }

    public void ResetOnWin()
    {
        if (scoreCount > 2)
        {
            gameLogic.timer += Time.deltaTime;

            if (gameLogic.timer > gameLogic.delay)
            {
                Lose.computerScoreCount = 0;
                scoreCount = 0;
                GameLogic.showInstructions = true;
                GoToWinScreen();
            }
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToWinScreen()
    {
        SceneManager.LoadScene(2);
    }
    public void addScore()
    {
        scoreCount++;
    }
}
