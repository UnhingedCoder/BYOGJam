using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlock : MonoBehaviour
{
    public float speed = -30;

    Quaternion originalRotation;

    private void Awake()
    {
        originalRotation = this.transform.rotation;
    }

    private void Update()
    {
        if (WorldManager.Instance.WorldInMotion)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }

        if(WorldManager.Instance.WorldInMotion && Quaternion.Angle(transform.rotation, originalRotation) < 0.2f 
                || Quaternion.Angle(transform.rotation, originalRotation) > 90f)
        {
            speed = -speed;
        }
       
    }
}
