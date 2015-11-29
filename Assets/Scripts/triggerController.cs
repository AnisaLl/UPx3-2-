using UnityEngine;
using System.Collections;

public class triggerController : MonoBehaviour {

    float timer = 0.0f;
    public float range = 3f;
    Ray shootRay;                                   // A ray from the trigger forwards.
    ParticleSystem triggerParticles;                    // Reference to the particle system.
    LineRenderer triggerLine;                           // Reference to the line renderer.
    AudioSource triggerAudio;                           // Reference to the audio source.
    Light triggerLight;                                 // Reference to the light component.
    public float effectsDisplayTime = 2.0f;
    private GameObject trigger;

    // Use this for initialization
    void Awake()
    {
        // Set up the references.
        triggerParticles = GetComponent<ParticleSystem>();
        triggerLine = GetComponent<LineRenderer>();
        //triggerAudio = GetComponent<AudioSource>();
        triggerLight = GetComponent<Light>();
    }

    void Start () {
        trigger = GameObject.FindGameObjectWithTag("trigger_f1_1");
        gameObject.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        //timer += Time.deltaTime;

        //if (Input.GetButton("Jump"))
        //{
        //    //trigger.SetActive(false);
        //    Display();
        //}

        //if (timer >= effectsDisplayTime)
        //{
        //    // ... disable the effects.
        //    DisableEffects();
        //}
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        //triggerLine.enabled = false;
        triggerLight.enabled = false;
    }

    public void Display()
    {

        // Play the trigger audioclip.
        //triggerAudio.Play();

        // Enable the light.
        triggerLight.enabled = true;

        //  start the particles.
        triggerParticles.Play();

        // Enable the line renderer and set it's first position to be the position of the trigger.
        triggerLine.enabled = true;
        triggerLine.SetPosition(0, transform.position);

        // Set the shootRay so that it starts at the position of the trigger and points forward.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
       
        triggerLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
     
    }
}
