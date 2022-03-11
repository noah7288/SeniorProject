using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public Transform gunEnd;
    public float projectileSpeed = 10f;

    public float moveSpeed = 10.0f;

    //public int playerDamage = 1;
    

    void Update()
    {
        Controls();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Controls() 
        {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //track mouse
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    } 

    void Shoot()
    {
        GameObject bullet = Instantiate(projectile, gunEnd.position, gunEnd.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunEnd.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
