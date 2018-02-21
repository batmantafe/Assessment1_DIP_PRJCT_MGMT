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

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            enemyHuntingPlayer = true;
        }
    }
}
