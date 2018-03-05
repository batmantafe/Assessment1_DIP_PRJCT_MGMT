using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIDetect : MonoBehaviour
{
    public bool enemyHuntingPlayer;

    // Use this for initialization
    void Start()
    {
        enemyHuntingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        // For Debugging purposes
        if (Input.GetKeyDown(KeyCode.F2))
        {
            enemyHuntingPlayer = true;
        }
    }

    // If Player enters Enemy Trigger then Bool is True. This is used in AIAgent script to change
    // AI from random NavTargets (wander/patrol), to Player NavTarget.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            enemyHuntingPlayer = true;
        }
    }
}
