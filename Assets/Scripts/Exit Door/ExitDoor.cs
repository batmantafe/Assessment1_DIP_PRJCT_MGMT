using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitDoor : MonoBehaviour
{
    public GameObject greenSign;
    public GameObject redSign;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // If Player enters Trigger AND the Green Sign on Door is Active (correct Door) AND
    // the Player has the Key, then Win!
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
