using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpTuto : MonoBehaviour
{
    private bool pauseGame = false;
    [SerializeField] private GameObject text;

    private void Update()
    {
        if (pauseGame)
        {
            Time.timeScale = 0f;
            text.SetActive(true);
        }

        if (InputManager._INPUT_MANAGER.GetJumpButtonPressed() == 0)
        {
            Time.timeScale = 1f;
            Destroy(text);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pauseGame = true;
    }
}
