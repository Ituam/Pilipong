using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject startText;
    [SerializeField] public float delay = 3f;
    public float timer;

    public static bool showInstructions = true;

    void Start()
    {

    }

    void Update()
    {
        HideInstructionsOnPlay();
        BackToMenu();
    }
    
    void HideInstructionsOnPlay()
    {
        if (Input.GetKeyDown("space"))
        {
            showInstructions = false;
        }

        if (showInstructions)
        {
            startText.GameObject().SetActive(true);
        }

        if (!showInstructions)
        {
            startText.GameObject().SetActive(false);
        }
    }

    void BackToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
