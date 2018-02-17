using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorsClosed;
    public GameObject doorsOpened;

    private int randomOpenClose;

    // Use this for initialization
    void Start()
    {
        RandomDoorStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomDoorStart()
    {
        randomOpenClose = Random.Range(1,3);

        Debug.Log("randomOpenClose = " + randomOpenClose);

        if (randomOpenClose == 1)
        {
            doorsClosed.SetActive(true);
            doorsOpened.SetActive(false);
        }

        if (randomOpenClose == 2)
        {
            doorsClosed.SetActive(false);
            doorsOpened.SetActive(true);
        }
    }
}
