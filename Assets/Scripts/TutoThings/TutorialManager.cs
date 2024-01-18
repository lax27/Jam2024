using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private bool jumpTuto = false;
    private bool boostTuto = false;

    private void Update()
    {
        if (jumpTuto && boostTuto)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetJumpTuto()
    {
        jumpTuto = true;
    }

    public void SetBoostTuto()
    {
        boostTuto = true;
    }
}
