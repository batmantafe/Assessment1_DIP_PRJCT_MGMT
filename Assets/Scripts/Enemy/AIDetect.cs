using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIDetect : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;

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
            enemy.GetComponent<NavMeshAgent>().SetDestination(player.position);

            Debug.Log("Enemy is hunting Player!");

            enemyHuntingPlayer = true;
        }
    }
}
