using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float movSpeed = 2f;
    [SerializeField] public float enemyStunTimer = 3;


    [SerializeField] private float currentFull;
    [SerializeField] private float maxFull;
    [SerializeField] private float damageAmount;

    [SerializeField] EnemyFloatingFeedMeter feedMeter;

    private Transform target;
    private bool frozen = false;
    private float timer = -1;


    private void Awake()
    {
        feedMeter = GetComponentInChildren<EnemyFloatingFeedMeter>();
    }

    private void Start()
    {
        target = LevelManager.main.targetPoint;
  
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            Destroy(gameObject);
            return;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = -1;
                frozen = false;
            }
        }
    }   

    private void FixedUpdate()
    {
        if (frozen) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * movSpeed;

    }

    public void TakeDamage()
    {
        Freeze();
        currentFull += damageAmount;
        feedMeter.UpdateFeedMeter(currentFull, maxFull);

        if(currentFull == maxFull)
        {
            Eliminate();
        }
    }

    public void Freeze()
    {
        frozen = true;
        timer = enemyStunTimer;
    }

    public void Eliminate()
    {
        Destroy(gameObject);
    }
}