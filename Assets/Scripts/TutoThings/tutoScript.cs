using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoScript : MonoBehaviour
{
    private bool pauseGame = false;
    [SerializeField] private GameObject text;
    private TutorialManager tutoMana;

    private void Awake()
    {
        tutoMana = GameObject.Find("TurotialColl").GetComponent<TutorialManager>();
    }

    private void Update()
    {
        if (pauseGame)
        {
            Time.timeScale = 0f;
            text.SetActive(true);
        }
        if (transform.name == "boostTuto")
        {
            if (InputManager._INPUT_MANAGER.GetBoostButtonPressed() == 0)
            {
                Time.timeScale = 1f;
                Destroy(text);
                Destroy(this.gameObject);
                tutoMana.SetBoostTuto();

            }
        }
        else
        {
            if (InputManager._INPUT_MANAGER.GetJumpButtonPressed() == 0)
            {
                Time.timeScale = 1f;
                Destroy(text);
                Destroy(this.gameObject);
                tutoMana.SetJumpTuto();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pauseGame = true;
    }
}
