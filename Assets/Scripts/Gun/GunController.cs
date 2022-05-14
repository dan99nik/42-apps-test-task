using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunController : MonoBehaviour
{
    [SerializeField]private float _timeReload;
    private bool _canShoot = true;


    public void Shoot(Vector3 direction)
    {
        if (_canShoot)
        {
            AmmoController ammo = AmmoPool.Instate.GetAmmo();
            ammo.transform.position = transform.position;

            ammo.MoveAmmo((direction - transform.position).normalized, direction);
           // ammo.MoveAmmo(transform.forward, direction);

            StartCoroutine(ReloadGun());
        }
    }

    private IEnumerator ReloadGun()
    {
        _canShoot = false;
        yield return new WaitForSeconds(_timeReload);
        _canShoot = true;
    }
}
