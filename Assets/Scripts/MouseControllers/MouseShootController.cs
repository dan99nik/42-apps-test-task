using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShootController : MonoBehaviour
{
    [SerializeField]private GunController _gunController;

    private RaycastHit _hit;
    private Ray _ray;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Logging.Write("Mouse shoot");
            if (Physics.Raycast(_ray, out _hit))
                _gunController.Shoot(_hit.point);
            else
                _gunController.Shoot(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 20)));
        }
    }
}
