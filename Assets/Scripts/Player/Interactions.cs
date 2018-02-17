using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    public bool playerHasKey;

    private Door doorScript;

    // Use this for initialization
    void Start()
    {
        playerHasKey = false;
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

        if (other.gameObject.CompareTag("Door") /*&& Input.GetMouseButtonDown(0)*/)
        {
            Debug.Log("Door triggered by Player.");

            doorScript = other.gameObject.GetComponent<Door>();


            if (doorScript.doorsClosed.activeSelf == true)
            {
                doorScript.doorsClosed.SetActive(false);
                doorScript.doorsOpened.SetActive(true);
            }

            if (doorScript.doorsClosed.activeSelf == false)
            {
                doorScript.doorsClosed.SetActive(true);
                doorScript.doorsOpened.SetActive(false);
            }
        }
    }
}
