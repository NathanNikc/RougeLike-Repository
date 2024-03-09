using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAim: MonoBehaviour
{
    public GameObject bulletPrefab;
    private Vector2 mousePosition;
    public Camera sceneCamera;
    public Rigidbody2D rb;
    public Transform firePoint;
    private float bulletSpeed = 10f;
    public Transform player;
    public Transform FirePointHinge;
    private bool shotFired = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //rb variable gets rb of the hinge that the firepoint rotates around so the hinge can be told to follow the mouse. this is so the player doesnt rotate to move the firepoint, the invisable hinge does.
    }

    public void Fire()
    {
        GameObject projectile = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        FirePointHinge.transform.position = player.transform.position;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;

        if (Input.GetKeyDown(KeyCode.Mouse0) && shotFired == false) //if the player presses the left mouse button
        {
            Fire();
            StartCoroutine(FireRate());
        }      
    }

    private IEnumerator FireRate()
    {
        shotFired = true;
        yield return new WaitForSeconds(.85f);
        shotFired = false;
    }
}
