using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingTower : Tower
{

    public Bullet bullet;
    public GameObject bulletInitPos;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Act()
    {
        base.Act();
        if (currentActionCooldown <= 0)
        {
            print("Act");
            //stvoriti charactera
            Instantiate(bullet, bulletInitPos.transform.position, Quaternion.identity);
            //Instantiate()
            currentActionCooldown = actionCooldown;
        }
        else
        {
            print("Nije vreme");
            currentActionCooldown -= Time.deltaTime;
        }
    }

    public override void WaitingToAct()
    {
        base.WaitingToAct();
        Character enemy;
        if (enemy = GetFacingEnemy())
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange)
                state = State.ACTING;
        }

    }

    Character GetFacingEnemy()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, attackRange);

        foreach (RaycastHit hit in hits)
        {
            Character hitCharacter = hit.transform.parent.GetComponent<Character>();
            if (hitCharacter.evil == true)
            {
                return hitCharacter;
            }
        }

        return null;
    }
}
