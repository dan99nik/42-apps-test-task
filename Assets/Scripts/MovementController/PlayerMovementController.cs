using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMovement
{
    [SerializeField] private float _movementSpeed = 12f;

    private float _x;
    private float _z;
    private Vector3 _direction;

    public void Move(CharacterController characterController)
    {
        _x = Input.GetAxis("Horizontal");
        _z = Input.GetAxis("Vertical");

        _direction = transform.right * _x + transform.forward * _z;

        characterController.Move(_direction * _movementSpeed * Time.deltaTime);
    }
}
