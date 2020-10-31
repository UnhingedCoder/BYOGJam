using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    public float speed = 10;

    Transform moveTo;

    private void Awake()
    {
        moveTo = pos1;
    }

    private void Update()
    {
        if (WorldManager.Instance.InMotion)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, moveTo.position, step);
        }

        if((this.transform.position - moveTo.position).magnitude < 0.2f)
        {
            if(moveTo == pos1)
            {
                moveTo = pos2;
            }
            else
            {
                moveTo = pos1;
            }
        }
    }
}
