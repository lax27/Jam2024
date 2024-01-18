using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTorqueCollieder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.transform.gameObject;

        CoinMovement cm = temp.GetComponent<CoinMovement>();

        cm.SetResetTorque();
    }

}
