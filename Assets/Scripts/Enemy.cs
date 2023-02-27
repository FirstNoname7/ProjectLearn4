using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody _enemyRb;
    private GameObject _player;
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(direction * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
