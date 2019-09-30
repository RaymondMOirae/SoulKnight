using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    // Weapon Propeties
    public string Name;
    public float FireRate;
    public int Damage;
    public float BulletSpeed;

    // instance refrence
    public GameObject Bullet;

    private float NextFire;


    public void Attack()
    {
        NextFire += Time.fixedDeltaTime;

        if (NextFire > FireRate)
        {
            // calculate shooting direction
            Vector3 mousePos= Input.mousePosition;
            Vector3 screenPos = new Vector3(mousePos.x - Camera.main.pixelWidth / 2, mousePos.y - Camera.main.pixelHeight / 2, 0);
            Vector3 offset = new Vector3(transform.position.x - Camera.main.transform.position.x, transform.position.y - Camera.main.transform.position.y, 0);
            // spawn bullet and add velocity
            GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (screenPos + transform.position + offset).normalized * BulletSpeed;
            Debug.Log(bullet.GetComponent<Rigidbody2D>().velocity);
            // store the bullet in a parent object 
            bullet.transform.SetParent(GameObject.Find("Bullets").transform);

            // reset timer
            NextFire = 0;
        }
    }

    public void AimCursor()
    {

    }
}
