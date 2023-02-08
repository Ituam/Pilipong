using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    
    [SerializeField] AudioClip loseSFX;
    [SerializeField] TextMeshProUGUI computerScore;
    [SerializeField] GameLogic gameLogic;
    Score scoreScript;

    public static int computerScoreCount = 0;


    private void Update()
    {
        computerScore.text = "Computer: " + computerScoreCount;
        ResetOnLose();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            AddComputerScore();
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(loseSFX);

            if (computerScoreCount <= 2)
            {
                Invoke("ReloadScene", gameLogic.delay);
            }

        }
    }
    public void ResetOnLose()
    {
        if (computerScoreCount > 2)
        {
            gameLogic.timer += Time.deltaTime;

            if (gameLogic.timer > gameLogic.delay)
            {
                Score.scoreCount = 0;
                computerScoreCount = 0;
                GameLogic.showInstructions = true;
                GoToLoseScreen();
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLoseScreen()
    {
        SceneManager.LoadScene(3);
    }

    void AddComputerScore() 
    { 
        computerScoreCount++;
    }


}
