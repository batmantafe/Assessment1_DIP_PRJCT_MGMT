using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIAgent : MonoBehaviour
{
    public Transform player;

    public Transform[] randomNav;
    private int randomNavInt;
    private Transform randomNavTrans;

    public GameObject enemyDetect;

    private NavMeshAgent nav;

    // Use this for initialization

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        RandomNav();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // if target is != null
        if (target != null)
        {
            // set destination to target's position
            nav.SetDestination(target.position);
        }
        */

        CheckTarget();
    }

    void RandomNav()
    {
        randomNavInt = Random.Range(0,4);

        randomNavTrans = randomNav[randomNavInt];

        nav.SetDestination(randomNavTrans.position);

        Debug.Log("randomNavInt = " + randomNavInt);

        Debug.Log("Enemy is wandering.");
    }

    void CheckTarget()
    {
        Debug.Log(nav.destination);

        if (transform.position == randomNavTrans.position &&
            enemyDetect.GetComponent<AIDetect>().enemyHuntingPlayer == false)
        {
            RandomNav();
        }

        if (enemyDetect.GetComponent<AIDetect>().enemyHuntingPlayer == true)
        {
            nav.SetDestination(player.position);
        }
    }
}

