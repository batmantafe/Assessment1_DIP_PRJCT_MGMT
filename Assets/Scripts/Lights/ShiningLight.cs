using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningLight : MonoBehaviour

{
    private Renderer colourRend;

    private Light shiningLight;

    private float timer;
    private float timerSet = 30f;

    private float blinkTimer;
    private float blinkIntensity;
    public bool detectBlink;
    public bool blinkOn;

    public bool blackOutBool;

    // timer = timer - (1f * Time.deltaTime);

    // Use this for initialization
    void Start()
    {
        shiningLight = GetComponent<Light>();
        colourRend = GetComponent<Renderer>();

        timer = 0f;

        blinkOn = false;
        detectBlink = false;
    }

    void FixedUpdate()
    {
        BlackoutFunction();
    }

    // Update is called once per frame
    void Update()
    {
        TimerFunction();

        //BlinkFunction();
    }

    void LateUpdate()
    {
        BlinkFunction();
    }

    // Used to count down to reactivating Light's material and light component in OnTriggerExit.
    void TimerFunction()
    {
        if (timer > 0f)
        {
            timer = timer - (1f * Time.deltaTime);
        }

        if (timer <= 0f)
        {
            timer = 0f;

            colourRend.material.color = Color.white;
            shiningLight.enabled = true;
            //shiningLight.intensity = 2.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If Enemy's Darkness trigger enters a Light trigger, then Light's Material turns Black AND
        // Light component turned Off.
        if (other.gameObject.CompareTag("Darkness"))
        {
            colourRend.material.color = Color.black;
            shiningLight.enabled = false;
        }

        // If Enemy's Detect trigger enters Light trigger, then DetectBlink Bool is True.
        if (other.gameObject.CompareTag("Detect"))
        {
            detectBlink = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If Enemy's Darkness trigger has left the Light's trigger, then start countdown Timer function
        // to reactivate Light.
        if (other.gameObject.CompareTag("Darkness"))
        {
            timer = timerSet;
        }

        // If Enemy's Detect trigger has left the Light's trigger, then DetectBlink bool is false.
        if (other.gameObject.CompareTag("Detect"))
        {
            detectBlink = false;
        }
    }

    /*void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detect") && blinkOn == false)
        {
            StartCoroutine(Blink());
        }
    }*/

    // Blink selects a random time and light intensity, then activates the light intensity for that time, then
    // resets it back to normal intensity.
    IEnumerator Blink()
    {
        blinkOn = true;

        blinkTimer = Random.Range(1f, 2f);
        blinkIntensity = Random.Range(0.5f, 4f);

        shiningLight.intensity = blinkIntensity;

        yield return new WaitForSeconds(blinkTimer);

        shiningLight.intensity = 2.0f;

        blinkOn = false;
    }

    // If Enemy's Detect trigger is present, and Blink ienumerator isn't already working, and Light is still On,
    // then run Blink ienumerator.
    void BlinkFunction()
    {
        if (detectBlink == true && blinkOn == false && blackOutBool == false)
        {
            StartCoroutine(Blink());
        }
    }

    // Chooses appropriate Bool (used in BlinkFunction function) if Light component is On or Off.
    void BlackoutFunction()
    {
        if (shiningLight.enabled == false) //(shiningLight.intensity == 0f)
        {
            blackOutBool = true;
        }

        if (shiningLight.enabled == true)
        {
            blackOutBool = false;
        }
    }
}
