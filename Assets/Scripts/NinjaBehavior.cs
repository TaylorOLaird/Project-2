using Interfaces;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Ninja Can Jump and Duck objects in env while navigating
/// Ninja Has energy that needs to be refiled by collection cookies and cakes
/// Ninja can slash stab and parry attacks using sword (SwordBehavior)
/// Ninja can throw limited num of shuriken
/// 
/// </summary>


public class NinjaBehavior : MonoBehaviour, IPlayer
{
    public GameObject grapplingHook;
    public GameObject shurikenPrefab;
    public Transform fireLocation;
    public GameObject moldPower;
    private IEnergyBar energyBar;

    // Num of shuriken ninja has -> set public to be able to edit in unity
    public int shurikenCount;

    public UnityEvent GameOverEvent { get; private set; } = new UnityEvent();
    
    
    private float shurikenSpeed = 5.0F;

    // Temp Var so code compiles replace with expr to determine whether we should fire shurriken
    private bool fireShurikenTrigger = false;
    // Temp Var so code compiles replace with expr to determine whether we should fire shurriken
    private bool moldVoicePromptRecognized = false;

    // Start is called before the first frame update
    void Start()
    {
        moldPower.SetActive(false);
        if (GameOverEvent == null)
        {
            GameOverEvent = new UnityEvent();
        }

        energyBar = gameObject.GetComponent<IEnergyBar>();
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject obj = null;
        
        // Set obj based on selection technique used

        /*if (grapplingHookEquiped)
        {
            grapplingHook.SetActive(true);
            grapplingHook.GetComponent<GrapplingHookBehavior>().grapplingHookEnabled = true;
        }*/

        if (fireShurikenTrigger)
        {
            FireShuriken();
        }

        if (moldVoicePromptRecognized)
        {
            ActivateMoldPower(); //alternative method for this exists if not pleased with this behavior
        }

        if (Energy <= 0f)
        {
            OnGameOver();
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
        if (shurikenCount <= 0) return; //early return if no shuriken left to fire
        
        GameObject shuriken = Instantiate(shurikenPrefab, fireLocation.position, Quaternion.identity);
        
        // Set the velocity of the laser
        shuriken.GetComponent<Rigidbody>().velocity = shuriken.transform.forward * shurikenSpeed;

        shurikenCount--;
    }

    public void TakeDamage(int attackValue)
    {
        energyBar.TakeDamage(attackValue);
    }

    public float Energy
    {
        get => energyBar?.CurrentEnergy ?? 0f;
    }

    public void ActivateMoldPower()
    {
        moldPower.SetActive(true);
        Invoke(nameof(DisableMoldPower), 2f);
    }
    
    private void OnGameOver()
    {
        GameOverEvent?.Invoke();
    }

    private void DisableMoldPower()
    {
        moldPower.SetActive(false);
    }
}

