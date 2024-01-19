using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIscript : MonoBehaviour
{
    [SerializeField] private GameObject CdrImage;
    [SerializeField] private GameObject RightImage;
    [SerializeField] private GameObject LeftImage;

    [SerializeField] private TMP_Text cooldownText;

    private CoinMovement player;

    private void Awake()
    {
        player = GameObject.Find("Moneda").GetComponent<CoinMovement>();    
    }


    private void Update()
    {
        if (!player.GetCanBoost())
        {
            int a = (int)player.GetCurrentCooldown();
            cooldownText.text = a.ToString();
            CdrImage.SetActive(true);
            RightImage.SetActive(false);
            LeftImage.SetActive(false);
        }

        if (player.GetCanBoost())
        {
            cooldownText.text = player.GetCurrentCooldown().ToString();
            CdrImage.SetActive(false);
            if (player.GetIsRigthLeft())
            {
                RightImage.SetActive(false);
                LeftImage.SetActive(true);
            }

            if (!player.GetIsRigthLeft())
            {
                RightImage.SetActive(true);
                LeftImage.SetActive(false);
            }
        }

 
    }
}
