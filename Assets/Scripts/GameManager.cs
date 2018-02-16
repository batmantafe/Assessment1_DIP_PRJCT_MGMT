using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyArray;
    public GameObject[] exitDoorArray;
    public GameObject[] keyArray;

    private int enemyStart;
    private int exitDoorStart;
    private int keyStart;

    // Use this for initialization
    void Start()
    {
        EnemyStartFunction();
        ExitDoorStartFunction();
        KeyStartFunction();
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

    void ExitDoorStartFunction()
    {
        exitDoorStart = Random.Range(1,4);

        exitDoorArray[exitDoorStart].SetActive(true);
    }

    void KeyStartFunction()
    {
        keyStart = Random.Range(1,4);

        keyArray[keyStart].SetActive(true);
    }
}
