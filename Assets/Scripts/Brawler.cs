using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brawler : Enemy
{
    public float speed;
    public float chaseDistance;
    public float stopDistance;
    public GameObject target;

    private float targetDistance;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);
        if(targetDistance < chaseDistance && targetDistance > stopDistance)
            ChasePlayer();
        else
        StopChasePlayer();
    }

    private void StopChasePlayer()
    {
        animator.SetBool("IsWalking", false);
    }

    private void ChasePlayer()
    {
        if(transform.position.x < target.transform.position.x)
            GetComponent<SpriteRenderer>().flipX = false;
        else
        GetComponent<SpriteRenderer>().flipX = true;

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        animator.SetBool("IsWalking", true);
    }
}
