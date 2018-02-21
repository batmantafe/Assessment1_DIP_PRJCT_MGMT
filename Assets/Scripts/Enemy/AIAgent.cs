using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIAgent : MonoBehaviour
{
    public Transform target;

    public Transform[] randomNav;
    public Transform player;

    private int randomNavInt;
    private Transform randomNavTrans;

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

        CheckRandom();
    }

    void RandomNav()
    {
        randomNavInt = Random.Range(0,4);

        randomNavTrans = randomNav[randomNavInt];

        nav.SetDestination(randomNavTrans.position);

        Debug.Log("randomNavInt = " + randomNavInt);

        Debug.Log("Enemy is wandering.");
    }

    void CheckRandom()
    {
        if (transform.position == randomNavTrans.position &&
            nav.destination != player.position)
        {
            RandomNav();
        }
    }
}

