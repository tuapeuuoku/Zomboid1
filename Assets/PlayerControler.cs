using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    Vector2 movementVector;
    float hp = 10;
    Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    public GameObject hpBar;
    Scrollbar hpScrollBar;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = transform.Find("bulletSpawn");
        movementVector = Vector2.zero;
        hpScrollBar = hpBar.GetComponent<Scrollbar>();
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            hp--;
            if (hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized * 5, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            hp = 10;
            hpScrollBar.size = hp / 10;
            Destroy(collision.gameObject);
        }
    }
    void Die()
    {
        GetComponent<BoxCollider>().enabled = false;
        transform.Translate(Vector3.up);
        transform.Rotate(Vector3.right * -90);

        //Time.timeScale = 0;
    }
}
