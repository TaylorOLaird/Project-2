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

    private int _slashDamage = 10;

    private int _stabDamage = 5;
    
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
        enemy.TakeDamage(_slashDamage);
    }

    /// <summary>
    /// Triggers for stab attacks
    /// </summary>
    private void Stab(IEnemy enemy)
    {
        //should we have a stab and slash method for enemies to make certain
        //fruits better defeated by certain attacks
        enemy.TakeDamage(_stabDamage);
    }
    
    /// <summary>
    /// Parry to block an enemy attack
    /// </summary>
    /// <param name="enemy"></param>
    private void Parry()
    {
        //Should we instead just set a state on the player --- this would protect from all attacks regardless
        //of hitting sword though
        
        //Should instead figure out how the fruit attacks
        //If all melee can just check if collides with enemy
        //If some use projectiles then we will need to check if colliding with enemy or enemy projectile
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IEnemy>() is {} enemy)
        {
            if (_isSlashing) Slash(enemy);
            else if (_isStabbing) Stab(enemy);
            else if (_isParrying) Parry(); //melee attack
        }
        else if (other.CompareTag("EnemyAttack"))
        {
            if (_isParrying) Parry(); //ranged attack
        }
    }
}
