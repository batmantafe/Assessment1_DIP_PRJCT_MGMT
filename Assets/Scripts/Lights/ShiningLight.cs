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

        if (other.gameObject.CompareTag("Detect"))
        {
            detectBlink = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Darkness"))
        {
            timer = timerSet;
        }

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
        if (detectBlink == true && blinkOn == false && blackOutBool == false)
        {
            StartCoroutine(Blink());
        }
    }

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
