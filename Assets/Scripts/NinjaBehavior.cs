using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

/// <summary>
/// Ninja Can Jump and Duck objects in env while navigating
/// Ninja Has energy that needs to be refiled by collection cookies and cakes
/// Ninja can slash stab and parry attacks using sword (SwordBehavior)
/// Ninja can throw limited num of shuriken
/// 
/// </summary>


public class NinjaBehavior : MonoBehaviour
{
    public GameObject grapplingHook;
    public GameObject shurikenPrefab;
    public Transform fireLocation;

    // Num of shuriken ninja has -> set public to be able to edit in unity
    public int shurikenCount;
    public int Energy;
    
    
    private float shurikenSpeed = 5.0F;
    private int shurikenDamageValue = 5;

    // Temp Var so code compiles replace with expr to determine whether we should fire shurriken
    private bool fireShurikenTrigger = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject obj = null;
        
        // Set obj based on selection technique used
        
        // if (obj != null && selectButtonPressed)
        // Alternatively: move scripting to grappling hook
        // Have it determine object and when a button is pressed by user
        // Call GrapplingHook.Select();
        
        // Select(obj);

        if (fireShurikenTrigger)
        {
            FireShuriken();
        }
    }

    private bool Select(GameObject other)
    {
        IGrabbable grabbable = other.GetComponent<IGrabbable>();

        if (grabbable is null) return false;

        grapplingHook.GetComponent<GrapplingHookBehavior>().Grab(grabbable);
        
        return true;
    }
    
    // When activated trigger the fire method -- now just need to figure out the activation
    // Optionally can do a tool-belt like behavior where user reaches down and presses trigger to grab a shuriken
    // (and this adds to hand instead of firing)
    // Then user can physically throw shuriken
    private void FireShuriken()
    {
        GameObject shuriken = Instantiate(shurikenPrefab, fireLocation.position, Quaternion.identity);
        
        // Set the velocity of the laser
        shuriken.GetComponent<Rigidbody>().velocity = shuriken.transform.forward * shurikenSpeed;

        shurikenCount--;
    }
}
