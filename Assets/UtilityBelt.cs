using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class UtilityBelt : XRBaseInteractable
{
    // refrence to the two items you can hold
    public GameObject item1;
    public GameObject item2;

    // function to switch between the two items
    public void SwitchItems()
    {
        // if item1 is active, deactivate it and activate item2
        if (item1.activeSelf)
        {
            item1.SetActive(false);
            item2.SetActive(true);
        }
        // if item2 is active, deactivate it and activate item1
        else if (item2.activeSelf)
        {
            item2.SetActive(false);
            item1.SetActive(true);
        }
    }
}