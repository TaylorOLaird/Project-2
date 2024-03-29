using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEditorInternal;
using UnityEngine;

public class EnergyBar : MonoBehaviour, IEnergyBar
{
    public GameObject enegeryCube;
    public float maxEnergy = 100f;
    public float drainRate = 1f;
    private float currentEnergy;

    public float CurrentEnergy { get => currentEnergy; }
    public void TakeDamage(float dmg)
    {
        currentEnergy -= dmg;
    }

    public List<GameObject> cakes = new List<GameObject>();

    // sound to play when eating a cake
    public AudioClip eatCakeSound;

    // make a private variable to hold the time since last ate a cake
    // private float timeSinceLastAteCake = 0f;

    // variable for inital x scale of the energy cube
    private float initialXScale;

    // reference for the player
    public GameObject player;

    // death sound
    public AudioClip deathSound;

    private bool deathSoundStart = false;


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with is a cake
        if (cakes.Contains(other.gameObject))
        {
            // log the name of the cake we ate
            // Debug.Log("Ate a cake: " + other.gameObject.name);
            // If it is, eat the cake
            EatCake(other.gameObject);
        }
    }

    private void EatCake(GameObject cake)
    {
        // Play the eat cake sound
        GetComponent<AudioSource>().PlayOneShot(eatCakeSound);
        // Increase the current energy
        currentEnergy = maxEnergy;
        enegeryCube.transform.localScale = new Vector3(initialXScale, enegeryCube.transform.localScale.y, enegeryCube.transform.localScale.z);
        // print current energy
        // Debug.Log("Current energy: " + currentEnergy);
        Destroy(cake);
    }


    // Start is called before the first frame update
    void Start()
    {
        // set the current energy to the max energy
        currentEnergy = maxEnergy;
        // set the initial x scale of the energy cube
        initialXScale = enegeryCube.transform.localScale.x;
        // timeSinceLastAteCake = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnergy <= 0.03 * maxEnergy && !deathSoundStart)
        {
            // play the death sound
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            deathSoundStart = true;
        }
        if (currentEnergy <= 0)
        {
            // Debug.Log("You are out of energy!");
            // If the current energy is less than or equal to 0, destroy the player
            Destroy(player);
        }
        currentEnergy = currentEnergy - (drainRate / 100);
        // Debug.Log("Current energy: " + currentEnergy);
        // set the x scale of the energy cube to the current energy, without changing the y and z scales
        enegeryCube.transform.localScale = new Vector3(currentEnergy, enegeryCube.transform.localScale.y, enegeryCube.transform.localScale.z);
    }
}
