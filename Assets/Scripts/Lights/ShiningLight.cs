using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiningLight : MonoBehaviour

{
    public Renderer colourRend;

    public Light shiningLight;

    // Use this for initialization
    void Start()
    {
        shiningLight = GetComponent<Light>();
        colourRend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        /*
         * When the Light is touched by an Enemy, the
         * Light will turn Black and it will deactivate
         * the light Component.
        */
        if (other.gameObject.CompareTag("Enemy"))
        {
            colourRend.material.color = Color.black;
            shiningLight.enabled = false;
        }
    }
}
