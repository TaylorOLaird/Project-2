using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
public class ShurikenBehavior : MonoBehaviour
{
    public GameObject shurikenPrefab;

    
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
        if (other.gameObject.GetComponent<IEnemy>() != null)
        {
            other.gameObject.GetComponent<IEnemy>()?.TakeDamage(shurikenDamageValue);
        }
    }
}
