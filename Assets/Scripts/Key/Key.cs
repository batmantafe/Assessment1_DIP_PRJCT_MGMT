using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    // Key spins slowly to catch Player's attention
    void Rotate()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
