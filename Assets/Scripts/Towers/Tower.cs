using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

   

    //public enum TowerType {ATTACK, DEFENCE};
    public enum State { ACTING, IDLE}

    public State state = State.ACTING;
    public float maxHealth;
    public float health;
    public float actionCooldown;
    public float currentActionCooldown = 0;
 
   // public TowerType towerType;

    

    void Start()
    {
        health = maxHealth;

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.ACTING:
                print("TOWER CASE STATE = ACTING");
                Act();
                break;

            case State.IDLE:
                print("TOWER CASE STATE = Idle");
                WaitingToAct();
                break;
        }
    }


    virtual public void Act() { }
    virtual public void WaitingToAct() { }

}
