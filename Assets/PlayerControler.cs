using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    Vector2 movementVector;
    Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = transform.Find("bulletSpawn");
        movementVector = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * movementVector.x);
        transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * playerSpeed);
    }

    void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();


    }
    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }
}
