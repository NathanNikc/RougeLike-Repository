using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector2 mousePosition;
    public Camera sceneCamera;
    public Rigidbody2D rb;
    public Transform firePoint;
    private float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

        if (Input.GetKeyDown(KeyCode.Mouse0)) //if the player presses the left mouse button
        {
            Fire();
        }      
    }
}
