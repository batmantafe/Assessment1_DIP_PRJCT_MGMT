using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    public bool playerHasKey;

    private Door doorScript;

    private bool clickInUse;

    // Use this for initialization
    void Start()
    {
        playerHasKey = false;

        clickInUse = false;
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
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            playerHasKey = true;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Game");
        }

        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            //Debug.Log("Player inside Door's Trigger.");

            if (Input.GetKeyDown(KeyCode.Mouse0) && clickInUse == false)
            {
                Debug.Log("Player clicked!");

                clickInUse = true;

                doorScript = other.gameObject.GetComponent<Door>();

                doorScript.isDoorOpen = !doorScript.isDoorOpen;

                Debug.Log("isDoorOpen = " + doorScript.isDoorOpen);
            }

            else
            {
                clickInUse = false;
            }
        }
    }
}
