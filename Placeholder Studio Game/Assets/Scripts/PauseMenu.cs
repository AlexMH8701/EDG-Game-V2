using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {

        if((Input.GetKeyDown(KeyCode.Escape)))
        {

            if (GameIsPaused)
            {
                Resume();
                pauseMenuUI.SetActive(false);

            } else
            {
                Pause();
                pauseMenuUI.SetActive(true);
            }

        }
        
    }

    public void Resume ()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause ()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;

    }
}
