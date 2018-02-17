using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    public bool playerHasKey;

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
    }
}
