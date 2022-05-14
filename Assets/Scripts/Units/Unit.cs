using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    private IMovement[] _movementControllers;

    private void Start()
    {
        _movementControllers = GetComponents<IMovement>();
    }

    private void Update()
    {
        for(int i =0;i < _movementControllers.Length; i++)
        {
            _movementControllers[i].Move(_characterController);
        }
    }
}
