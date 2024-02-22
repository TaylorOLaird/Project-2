using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

public class SwordBehavior : MonoBehaviour
{

    private bool _isSlashing = false;

    private bool _isStabbing = false;

    private bool _isParrying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check state to determine if Slash/Stab or parry
        // Always set the state of the one with the highest confidence?
    }

    /// <summary>
    /// Triggers for slash attacks
    /// </summary>
    private void Slash(IEnemy enemy)
    {
        
    }

    /// <summary>
    /// Triggers for stab attacks
    /// </summary>
    private void Stab(IEnemy enemy)
    {
        //should we have a stab and slash method for enemies to make certain fruits better defeated by certain attacks
    }
    
    /// <summary>
    /// Parry to block an enemy attack
    /// </summary>
    /// <param name="enemy"></param>
    private void Parry(IEnemy enemy)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = other.GetComponent<IEnemy>();

        if (enemy == null) return;
        
        if (_isSlashing) Slash(enemy);
        else if (_isStabbing) Stab(enemy);
        else if (_isParrying) Parry(enemy);
    }
}
