using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    private float _speed = 30;
    private Vector3 _direction;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Collider _collider;
    [SerializeField] private MeshRenderer _bulletMeshRender;
    [SerializeField] private GameObject _collisionFX;


    private const string _agentTag = "Agent";
    public void MoveAmmo(Vector3 direction, Vector3 lookPos)
    {
        CollisionBullet(false);
        _direction = direction;
        _rb.velocity = _direction * _speed;
        transform.LookAt(lookPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionBullet(true);
        if (collision.gameObject.TryGetComponent(out KickController kickController))
        {
            kickController.Kick(_direction);

            if(collision.gameObject.tag == _agentTag)
                Logging.Write("Agent Hit");
        }
    }

    private void CollisionBullet(bool enable)
    {
        _rb.isKinematic = enable;
        _collider.enabled = !enable;
        _bulletMeshRender.enabled = !enable;
        _collisionFX.SetActive(enable);

        if (enable)
            StartCoroutine(BulletDisable());
    }

    private IEnumerator BulletDisable()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
