using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningLight : MonoBehaviour

{
    private Renderer colourRend;

    private Light shiningLight;

    private float timer;
    private float timerSet = 30f;
    public bool blackOut;

    private float blinkTimer;
    private float blinkIntensity;
    public bool detectBlink;
    public bool blinkOn;

    // timer = timer - (1f * Time.deltaTime);

    // Use this for initialization
    void Start()
    {
        shiningLight = GetComponent<Light>();
        colourRend = GetComponent<Renderer>();

        timer = 0f;

        blinkOn = false;
        detectBlink = false;

        blackOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimerFunction();

        BlinkFunction();
    }

    void TimerFunction()
    {
        if (timer > 0f)
        {
            timer = timer - (1f * Time.deltaTime);
        }

        if (timer <= 0f)
        {
            timer = 0f;

            blackOut = false;

            colourRend.material.color = Color.white;
            shiningLight.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        /*
         * When the Light is Triggered by an Enemy, the
         * Light will turn Black and it will deactivate
         * the light Component.
        */
        if (other.gameObject.CompareTag("Darkness") & blackOut == false)
        {
            blackOut = true;

            colourRend.material.color = Color.black;
            shiningLight.enabled = false;
        }

        if (other.gameObject.CompareTag("Detect") && blackOut == false)
        {
            detectBlink = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Darkness") && blackOut == true)
        {
            timer = timerSet;
        }

        if (other.gameObject.CompareTag("Detect") && blackOut == false)
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

    void BlinkFunction()
    {
        if (detectBlink == true && blinkOn == false)
        {
            StartCoroutine(Blink());
        }
    }
}
