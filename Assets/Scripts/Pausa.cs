using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool pause = false;

    private void Update()
    {
        if (!pause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
              
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                pause = true;
            }
        }
      else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                pause = false;

            }
        }
    

    }

    public void ReturnGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pause = false;
    }
}
