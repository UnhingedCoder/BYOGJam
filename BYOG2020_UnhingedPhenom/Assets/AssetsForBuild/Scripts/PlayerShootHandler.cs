using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerShootHandler : MonoBehaviour
{

    private PlayerInputHandler _playerInput;

    [SerializeField] ObjectPooler _bulletPool;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (!_playerInput.isShooting)
            return;

        Bullet _bullet = _bulletPool.GetPooledObject(this.transform).GetComponent<Bullet>();
        _bullet.gameObject.SetActive(true);
        _bullet.SetupBullet(transform.forward);

    }
}
