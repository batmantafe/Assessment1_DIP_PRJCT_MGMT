using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    public bool playerHasKey;
    public bool playerAtDoor;

    public bool playerAtBlackExit;
    public bool playerAtRedExit;

    private Door doorScript;

    private bool clickInUse;

    // Use this for initialization
    void Start()
    {
        playerHasKey = false;
        playerAtDoor = false;

        clickInUse = false;

        playerAtBlackExit = false;
        playerAtRedExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        Shortcuts();

    }

    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
            SceneManager.LoadScene("Main");
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If Player enters Key's trigger, then deactivate Key and set PlayerHadKey Bool to
        // True (used in ExitDoor script).
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            playerHasKey = true;
        }

        // If Player enters Enemy's trigger then Lose!
        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Used to toggle open/close Door gameobjects when Player left-clicks and is in Door's trigger.
        // PlayerAtDoor Bool used in GameManager script to display appropriate Text message to Player, to
        // let them know how to open/close Door.
        if (other.gameObject.CompareTag("Door"))
        {
            playerAtDoor = true;

            if (Input.GetKeyDown(KeyCode.Mouse0) && clickInUse == false)
            {
                clickInUse = true;

                doorScript = other.gameObject.GetComponent<Door>();

                doorScript.isDoorOpen = !doorScript.isDoorOpen;
            }

            else
            {
                clickInUse = false;
            }
        }

        // Used in GameManager script to activate appropriate Text message to Player when Player is at
        // an Exit Door that is not working (has a Black "Exit" Sign) or is working but the Player doesn't have
        // the Key yet (has a Red "Exit" Sign)
        if (other.gameObject.CompareTag("Exit Door"))
        {
            if (other.gameObject.GetComponent<ExitDoor>().redSign.activeSelf == false)
            {
                if (other.gameObject.GetComponent<ExitDoor>().greenSign.activeSelf == false)
                {
                    playerAtBlackExit = true;
                }
            }

            if (other.gameObject.GetComponent<ExitDoor>().redSign.activeSelf == true)
            {
                    playerAtRedExit = true;
            }
        }
    }

    // Bools used in GameManager script to display appropriate Text message when at Doors and Exit Doors.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            playerAtDoor = false;
        }

        if (other.gameObject.CompareTag("Exit Door"))
        {
            playerAtBlackExit = false;
            playerAtRedExit = false;
        }
    }
}
