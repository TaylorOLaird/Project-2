using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class ShurikenBehavior : MonoBehaviour
{
    public GameObject shurikenPrefab;
    
    private int shurikenDamageValue = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Shuriken trigger event
    private void OnTriggerEnter(Collider other)
    {
        // check if we successfully get a non-null IEnemy component and set local var enemy to that value so
        // we do not need to call GetComponent again
        if (other.gameObject.GetComponent<IEnemy>() is { } enemy)
        {
            enemy.ShurikenHit(shurikenDamageValue);
        }
    }
}
