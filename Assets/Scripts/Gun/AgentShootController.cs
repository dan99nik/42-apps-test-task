using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentShootController : MonoBehaviour
{
    [SerializeField] private GunController _gunController;
    [SerializeField] private LayerMask _playerLayerMask;

    private void Update()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        Collider[] playerCollider = Physics.OverlapSphere(transform.position, 10f, _playerLayerMask);
        if (playerCollider.Length != 0)
            _gunController.Shoot(playerCollider[0].transform.position);
    }
}
