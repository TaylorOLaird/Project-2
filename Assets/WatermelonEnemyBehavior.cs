using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class WatermelonEnemyBehavior : MonoBehaviour, IEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Select()
    {
        //throw new System.NotImplementedException();
        return false;
    }

    public bool Throw()
    {
        //throw new System.NotImplementedException();
        return false;
    }

    public int TakeDamage(int dmg)
    {
        return 0;
    }

    public void Mold()
    {
        //throw new System.NotImplementedException();
    }
}
