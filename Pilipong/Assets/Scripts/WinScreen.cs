using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    void Update()
    {
        YouWonText();
    }

    public void YouWonText()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
        }
    }
}
