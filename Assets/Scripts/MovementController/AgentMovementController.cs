using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovementController : MonoBehaviour, IMovement
{
    [SerializeField] private float _movementSpeed = 12f;
    private Vector3 _direction;
    private Vector3[] _pathPosition = new Vector3[3];
    private int _pathPointID = 2;
    private int _layerMask = 1 << 8;

    private void Start()
    {
        FindPathPoint();
    }

    private void FindPathPoint()
    {
        _pathPosition[0] = transform.position;

        float steps = 0;
        while (_pathPosition[1] == Vector3.zero)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.right * steps, -transform.up, out hit, Mathf.Infinity, _layerMask))
                steps += 0.05f;
            else
                _pathPosition[1] = transform.position + transform.right * (steps - 0.15f);
        }

        steps = 0;
        while (_pathPosition[2] == Vector3.zero)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.right * steps, -transform.up, out hit, Mathf.Infinity, _layerMask))
                steps -= 0.05f;
            else
                _pathPosition[2] = transform.position + transform.right * (steps + 0.15f);
        }

        StartCoroutine(ChangePathPointID());
    }

    public void Move(CharacterController characterController)
    {
        if (Vector3.Distance(transform.position, _pathPosition[_pathPointID]) > 0.3f)
            characterController.Move(_direction * _movementSpeed * Time.deltaTime);
        else
            characterController.Move(Vector3.zero);
    }

    private IEnumerator ChangePathPointID()
    {
        while (true)
        {
            _pathPointID = Random.Range(0, _pathPosition.Length);
            _direction = (_pathPosition[_pathPointID] - transform.position).normalized;
            yield return new WaitForSeconds(2f);
        }
    }
}
