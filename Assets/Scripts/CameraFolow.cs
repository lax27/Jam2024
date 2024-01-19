using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private float Yoffset;
    [SerializeField] private float Zoffset;

    private void Update()
    {
        Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y + Yoffset ,Zoffset);
        transform.position = Vector3.Slerp(transform.position, newPos, speed);
    }

}
