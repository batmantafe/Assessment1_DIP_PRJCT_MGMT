using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRandomStart : MonoBehaviour
{
    public GameObject[] enemyArray;

    private int randomStart;

    // Use this for initialization
    void Start()
    {
        RandomStartFunction();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RandomStartFunction()
    {
        randomStart = Random.Range(1,4);

        enemyArray[randomStart].SetActive(true);
    }
}
