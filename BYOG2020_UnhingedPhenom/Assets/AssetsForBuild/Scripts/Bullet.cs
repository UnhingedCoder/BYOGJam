using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_selfDestructTime;

    private float timer;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetupBullet(Vector3 targetDir)
    {
        transform.rotation = Quaternion.LookRotation(targetDir);
        _rigidbody.velocity = targetDir * m_Speed;
        timer = 0;
    }


    private void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;

            if (timer >= m_selfDestructTime)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
