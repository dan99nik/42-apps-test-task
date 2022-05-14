using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickController : MonoBehaviour, IMovement
{

    private Vector3 _direction = Vector3.zero;
    private float _kickForce = 0;

    public void Move(CharacterController characterController)
    {
        characterController.Move(_direction * _kickForce * Time.deltaTime);
    }

    public void Kick(Vector3 direction)
    {
        _direction = new Vector3(direction.x,0,direction.z);
        _kickForce = 30;
        StartCoroutine(DownForceKick());
    }

    IEnumerator DownForceKick()
    {
        while(_kickForce > 0)
        {
            _kickForce--;
            yield return null;
        }
    }
}
