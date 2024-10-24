using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float life = 3;
    [SerializeField] private float projectileSpeed = 5f;

    private Transform target;

    // Update is called once per frame
    void Awake()
    {
        Destroy(gameObject, life);
    }

    public void SetTarget(Transform _target)
    {
        target = _target; 
    }

    private void FixedUpdate()
    {
        if (!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        gameObject.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Enemy") return;
        //Adding knockback to the collided object and calling the TakeDamage function from the EnemyCtrl Script.
        EnemyCtrl enemy = collision.gameObject.GetComponent<EnemyCtrl>();
        enemy.TakeDamage();
        Destroy(gameObject);

    }
}
