using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [SerializeField] private GameObject menuObjects;
    [SerializeField] private GameObject CreditsObjects;

    public void Play(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenCredits()
    {
        menuObjects.SetActive(false);
        CreditsObjects.SetActive(true);
    }

    public void CloseCredits()
    {
        menuObjects.SetActive(true);
        CreditsObjects.SetActive(false);
    }

}
