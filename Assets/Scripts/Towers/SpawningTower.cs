using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTower : Tower
{
    // Start is called before the first frame update

    public Character spawnCharacter;
    public GameObject spawnPoint;

    void Start()
    {
        
    }


    public override void Act()
    {
        base.Act();
        if (currentActionCooldown <= 0)
        {
            print("Act");
            //stvoriti charactera
            Instantiate(spawnCharacter, spawnPoint.transform.position, Quaternion.identity);
            //Instantiate()
            currentActionCooldown = actionCooldown;
        }
        else
        {
            print("Nije vreme");
            currentActionCooldown -= Time.deltaTime;
        }
    }
}
