using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody enemyRig;
    public Transform bulletPos;

    public bool lookingAt = false;
    public bool canShoot = false;

    public float speed = 50f;

    public float pauseTime = 2f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(lookingAt == true && canShoot == true)
        {
            canShoot = false;

            //fire bullet
            StartCoroutine(Fire());
        }
    }

    //pause
    private IEnumerator Fire()
    {
        //instanciate bullet
        GameObject newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        //get bullet rigid body
        Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();

        //shoot bullet
        bulletRig.velocity = new Vector3(bulletPos.transform.forward.x, bulletPos.transform.forward.y, bulletPos.transform.forward.z)*speed;
       // bulletRig.AddForce(transform.forward * speed);

        //wait to shoot
        yield return new WaitForSeconds(pauseTime);

        canShoot = true;
    }


    //look at player
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //rotate object to look at target
            this.transform.LookAt(other.transform.position);
            
            lookingAt = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canShoot = true;
        }
    }


    //player out of reach
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            lookingAt = false;
            canShoot = false;

            //resume previouse actions

            //for frog
            Quaternion currentRotation = this.transform.rotation;

            Quaternion endRotation = Quaternion.Euler(transform.forward);

            transform.rotation = Quaternion.Lerp(endRotation, currentRotation, 0.125f);
        }        
    }


}
