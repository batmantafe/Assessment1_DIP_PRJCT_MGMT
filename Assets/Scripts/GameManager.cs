using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyArray;
    public GameObject[] exitDoorArray;

    private int enemyStart;
    private int exitDoorStart;

    // Use this for initialization
    void Start()
    {
        EnemyStartFunction();
        ExitDoorFunction();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemyStartFunction()
    {
        enemyStart = Random.Range(1,4);

        enemyArray[enemyStart].SetActive(true);
    }

    void ExitDoorFunction()
    {
        exitDoorStart = Random.Range(1,4);

        exitDoorArray[exitDoorStart].SetActive(true);
    }
}
