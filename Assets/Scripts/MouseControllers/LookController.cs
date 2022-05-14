using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 100f;
    [SerializeField] private Transform _playerBody;
    [SerializeField] private Transform _playerHead;
    private float _xRot = 0;

    private float _mouseX;
    private float _mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _xRot -= _mouseY;
        _xRot = Mathf.Clamp(_xRot, -90f, 90f);

        _playerHead.localRotation = Quaternion.Euler(_xRot, 0, 0);
        _playerBody.Rotate(Vector3.up * _mouseX);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 20)) - Camera.main.transform.position);
    }
}
