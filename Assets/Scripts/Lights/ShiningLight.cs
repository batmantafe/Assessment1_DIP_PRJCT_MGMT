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
    private bool blinkOn;

    // timer = timer - (1f * Time.deltaTime);

    // Use this for initialization
    void Start()
    {
        shiningLight = GetComponent<Light>();
        colourRend = GetComponent<Renderer>();

        timer = 0f;

        blinkOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimerFunction();
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
        if (other.gameObject.CompareTag("Darkness"))
        {
            colourRend.material.color = Color.black;
            shiningLight.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Darkness"))
        {
            timer = timerSet;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Detect") && blinkOn == false)
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        blinkOn = true;

        blinkTimer = Random.Range(0.5f, 1f);
        blinkIntensity = Random.Range(0.5f, 3f);

        shiningLight.intensity = blinkIntensity;

        yield return new WaitForSeconds(blinkTimer);

        shiningLight.intensity = 2.0f;

        blinkOn = false;
    }
}
