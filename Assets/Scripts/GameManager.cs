using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyArray;
    public GameObject[] exitDoorRedArray;
    public GameObject[] exitDoorBlackArray;
    public GameObject[] keyArray;

    private int enemyStart;
    private int exitDoorRedStart;
    private int keyStart;

    // Use this for initialization
    void Start()
    {
        EnemyStartFunction();
        ExitDoorRedStartFunction();
        KeyStartFunction();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This function sets the random Enemy starting position.
    void EnemyStartFunction()
    {
        enemyStart = Random.Range(1,4);

        enemyArray[enemyStart].SetActive(true);
    }

    // This function sets the random Exit Door.
    void ExitDoorRedStartFunction()
    {
        exitDoorRedStart = Random.Range(1,4);

        exitDoorRedArray[exitDoorRedStart].SetActive(true);
        exitDoorBlackArray[exitDoorRedStart].SetActive(false);
    }

    // This functions set the random Key.
    void KeyStartFunction()
    {
        keyStart = Random.Range(1,4);

        keyArray[keyStart].SetActive(true);
    }
}
