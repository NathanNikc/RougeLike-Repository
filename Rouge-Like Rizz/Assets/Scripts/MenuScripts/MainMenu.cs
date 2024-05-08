using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPlaying;

    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
        isPlaying = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && isPlaying == true)
        {
            OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        SceneManager.LoadScene("Pause");
    }

}

