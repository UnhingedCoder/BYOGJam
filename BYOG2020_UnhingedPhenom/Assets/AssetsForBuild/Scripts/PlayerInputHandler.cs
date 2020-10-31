using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }

    public Vector3 MousePosition { get; private set; }

    public bool Jump { get; private set; }

    public bool isShooting { get; private set; }
    public bool slowTime { get; private set; }

    private float _horizontal;
    private float _vertical;

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        InputVector = new Vector2(_horizontal, _vertical);

        MousePosition = Input.mousePosition;

        Jump = Input.GetButtonDown("Jump");

        isShooting = Input.GetButtonDown("Fire1");
        slowTime = Input.GetButtonDown("Fire2");
    }
}
