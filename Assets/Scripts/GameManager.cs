using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyArray;
    public GameObject[] exitDoorRedArray;
    public GameObject[] exitDoorGreenArray;
    public GameObject[] exitDoorBlackArray;
    public GameObject[] keyArray;
    public string[] keyGridArray;
    public string[] exitGridArray;
    public GameObject player;
    public GameObject[] enemyDetect;

    private int enemyStart;
    private int exitDoorRedStart;
    private int keyStart;

    public Text enemyText;
    public Text objectiveText;
    public Text doorText;

    // Use this for initialization
    void Start()
    {
        EnemyStartFunction();
        ExitDoorRedStartFunction();
        KeyStartFunction();

        enemyText.text = "Something is in here with you.";
    }

    // Update is called once per frame
    void Update()
    {
        ExitDoorGreenFunction();
        MessageFunction();
    }

    // This function sets the random Enemy starting position.
    void EnemyStartFunction()
    {
        enemyStart = Random.Range(0,4);
        Debug.Log("enemyStart = " + enemyStart);

        enemyArray[enemyStart].SetActive(true);
    }

    // This function sets the random Exit Door.
    void ExitDoorRedStartFunction()
    {
        exitDoorRedStart = Random.Range(0,4);
        Debug.Log("exitDoorRedStart = " + exitDoorRedStart);

        exitDoorRedArray[exitDoorRedStart].SetActive(true);
        exitDoorBlackArray[exitDoorRedStart].SetActive(false);
    }

    // This functions set the random Key.
    void KeyStartFunction()
    {
        keyStart = Random.Range(0,4);
        Debug.Log("keyStart = " + keyStart);

        keyArray[keyStart].SetActive(true);
    }

    void ExitDoorGreenFunction()
    {
        if (player.gameObject.GetComponent<Interactions>().playerHasKey == true)
        {
            exitDoorRedArray[exitDoorRedStart].SetActive(false);
            exitDoorGreenArray[exitDoorRedStart].SetActive(true);
        }
    }

    void MessageFunction()
    {
        // Messages for Keys
        if (player.gameObject.GetComponent<Interactions>().playerHasKey == false)
        {
            objectiveText.text = "The Key is near Ward " + keyGridArray[keyStart];
        }

        if (player.gameObject.GetComponent<Interactions>().playerHasKey == true)
        {
            objectiveText.text = "You've got the Key. The Exit is near Ward " + exitGridArray[exitDoorRedStart];
        }

        // Messages for normal open/close Doors
        if (player.gameObject.GetComponent<Interactions>().playerAtDoor == true)
        {
            doorText.text = "Left-Click to open or close this Door.";
        }

        if (player.gameObject.GetComponent<Interactions>().playerAtDoor == false)
        {
            doorText.text = "";

        }

        // Messages about the Enemy
        if (enemyDetect[enemyStart].GetComponent<AIDetect>().enemyHuntingPlayer == true)
        {
            enemyText.color = Color.red;
            enemyText.text = "IT'S COMING FOR YOU";
        }

        // Messages for the Exit Doors
        if (player.gameObject.GetComponent<Interactions>().playerAtBlackExit == true)
        {
            doorText.text = "This Exit is broken. Find another Exit.";
        }

        if (player.gameObject.GetComponent<Interactions>().playerAtRedExit == true)
        {
            doorText.text = "This Exit is locked. Find the Key and come back.";
        }
    }
}
