using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ZombiePefab;
    public GameObject healPrefab;

    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
        {
            Instantiate(ZombiePefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
        if (GameObject.FindGameObjectsWithTag("Heal").Length < 1)
        {
            Instantiate(healPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPoint;
        do
        {
            spawnPoint = UnityEngine.Random.insideUnitSphere;
            spawnPoint.y = 0f;
            spawnPoint = spawnPoint.normalized;
            spawnPoint *= UnityEngine.Random.Range(8f, 13f);
            spawnPoint += Player.transform.position;
        }
        //TODO: check this shit
        while (Physics.CheckSphere(new Vector3(spawnPoint.x, 1, spawnPoint.z), 0.9f));

        return spawnPoint;
    }
}