using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    // Flag to check against during updates to adjust behavior i.e. do not attack or move while held
    protected bool Selected = false;

    private IGrabber _grabbingObject;

    [field:SerializeField]
    public int Health { get; set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Health <= 0) GameObject.Destroy(this.gameObject);
        if (Selected) return;
    }

    protected void OnDestroy()
    {
        _grabbingObject?.Clear();
    }

    public virtual bool Select(IGrabber parent)
    {
        if (Selected) return false;
        
        transform.SetParent(parent.GetTransform());

        _grabbingObject = parent;
        
        return Selected = true;
    }

    public virtual bool Throw()
    {
        if (!Selected) return false;

        Selected = false;
        transform.SetParent(null);
        _grabbingObject = null;
        
        return !Selected;
    }

    public virtual int TakeDamage(int dmg)
    {
        Health -= dmg;
        return Health;
    }

    public virtual void Mold()
    {
        //throw new System.NotImplementedException();
    }
}
