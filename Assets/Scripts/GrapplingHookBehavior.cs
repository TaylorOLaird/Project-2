using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class GrapplingHookBehavior : MonoBehaviour
{
    private IGrabbable _selectedFruit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Confirm selection
    /// </summary>
    /// <param name="fruit"></param>
    /// <returns></returns>
    public bool Grab(IGrabbable fruit)
    {
        if (_selectedFruit != null) return false;
        if (!fruit.Select()) return false;
        _selectedFruit = fruit;

        return true;
    }

    /// <summary>
    /// Throw the fruit - the throw method on the fruit can maybe calculate dmg
    /// to do to the fruit or something or just used for repositioning enemies
    /// </summary>
    /// <returns></returns>
    bool Throw()
    {
        _selectedFruit.Throw();
        _selectedFruit = null;
        return true;
    }
}
