using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerMovementHandler : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float m_MovementSpeed;
    [SerializeField] private float m_RotationSpeed;

    [SerializeField] private bool _rotateTowardsMouse;
    
    private PlayerInputHandler _playerInput;


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        var targetVector = new Vector3(_playerInput.InputVector.x, 0, _playerInput.InputVector.y);
        var movementVector = MoveTowardTarget(targetVector);

        if (!_rotateTowardsMouse)
        {
            RotateTowardMovementVector(movementVector);
        }
        if (_rotateTowardsMouse)
        {
            RotateFromMouseVector();
        }
    }

    private void RotateFromMouseVector()
    {
        Ray ray = _camera.ScreenPointToRay(_playerInput.MousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateTowardMovementVector(Vector3 movementDirection)
    {
        if (movementDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, m_RotationSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = m_MovementSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, _camera.gameObject.transform.rotation.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}
