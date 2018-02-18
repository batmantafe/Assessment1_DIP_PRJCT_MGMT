using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    public GameObject greenSign;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") &&
            greenSign.activeSelf == true &&
            other.gameObject.GetComponent<Interactions>().playerHasKey == true)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
