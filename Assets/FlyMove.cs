using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyMove : MonoBehaviour
{
    public InputActionReference FlyButton;
    // reference to the the object to get what direction to fly
    public Transform objectReference;

    private void OnEnable()
    {
        FlyButton.action.Enable();
    }

    private void OnDisable()
    {
        FlyButton.action.Disable();
    }

    void Update()
    {
        // Check if the button is pressed
        if (FlyButton.action.ReadValue<float>() > 0.5f)
        {
            // move the object in the 
            transform.position += (objectReference.forward * .1f);
        }
    }
}


