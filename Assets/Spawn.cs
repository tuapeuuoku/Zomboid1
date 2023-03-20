using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Enemy;


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
        {
            Instantiate(Enemy, GetRandomPosition(), Quaternion.identity);


        }
        Vector3 GetRandomPosition()
        {
            Vector3 position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
            position = position.normalized * Random.Range(-10, 15);
            return position;
        }
    }
}