using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    
    private float health;
    private State state = State.WALKING;
    private float currentAttackCooldown = 0;
    private NavMeshAgent agent;
    private Character chasingEnemy;

    public float speed = 2;
    public float maxHealth = 100;
    public enum State { WALKING, CHASING_ENEMY, ATTACKING };
    public bool evil;
    public float damage = 5;
    public float attackRange = 2;
    public float attackCooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;

        health = maxHealth;
        Walk(transform.position + transform.forward * 10);
    }

    // Update is called once per frame
    void Update()
    {
        print(state);
        switch(state)
        {
            case State.ATTACKING:
                Attack();
                break;

            case State.WALKING:
                {
                    Character enemy;
                    if (enemy = GetFacingEnemy())
                    {
                        ChaseEnemy(enemy);
                    }
                    else
                    {
                        float dist = Vector3.Distance(agent.destination, transform.position);
                        if (dist <= attackRange)
                        {
                            //
                        }
                    }
                    break;
                }

            case State.CHASING_ENEMY:
                {
                    float dist = Vector3.Distance(transform.position, chasingEnemy.transform.position);
                    if (dist <= attackRange)
                    {
                        state = State.ATTACKING;
                    }
                    else
                    {
                        ChaseEnemy(chasingEnemy);
                    }
                    break;
                }
        }
    }
    void Walk(Vector3 destination)
    {
        agent.stoppingDistance = 0;
        agent.destination = destination;
        state = State.WALKING;
    }

    void ChaseEnemy(Character enemy)
    {
        chasingEnemy = enemy;
        agent.stoppingDistance = attackRange;
        agent.destination = enemy.transform.position;
        state = State.CHASING_ENEMY;
    }

    void Attack()
    {
        if (currentAttackCooldown <= 0)
        {
            print("Napad!");
            currentAttackCooldown = attackCooldown;
        }else
        {
            currentAttackCooldown -= Time.deltaTime;
        }
    }

    Character GetFacingEnemy()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, attackRange);

        foreach(RaycastHit hit in hits)
        {
            Character hitCharacter = hit.transform.parent.GetComponent<Character>();
            if (hitCharacter && evil != hitCharacter.evil)
            {
                return hitCharacter;
            }
        }

        return null;
    }
}
