using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorsClosed;
    public GameObject doorsOpened;

    public bool isDoorOpen;

    private int randomOpenClose;

    // Use this for initialization
    void Start()
    {
        RandomDoorStart();
    }

    // Update is called once per frame
    void Update()
    {
        DoorOpenOrClosed();
    }

    void RandomDoorStart()
    {
        randomOpenClose = Random.Range(1,3);

        Debug.Log("randomOpenClose = " + randomOpenClose);

        if (randomOpenClose == 1)
        {
            isDoorOpen = false;
        }

        if (randomOpenClose == 2)
        {
            isDoorOpen = true;
        }
    }

    void DoorOpenOrClosed()
    {
        if (isDoorOpen == false)
        {
            doorsClosed.SetActive(true);
            doorsOpened.SetActive(false);
        }

        if (isDoorOpen == true)
        {
            doorsClosed.SetActive(false);
            doorsOpened.SetActive(true);
        }
    }
}
