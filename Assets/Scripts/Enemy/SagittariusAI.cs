using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagittariusAI : MonoBehaviour
{
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    private bool isInFov = false;

    public GameObject bullet;
    private Rigidbody enemyRig;
    public Transform bulletPos;

    public float speed = 50f;

    public float pauseTime = 60f;

    public Animator SagAnime;

    private void Start()
    {
        SagAnime = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //is player in fov?
        RaycastHit hit;
        Vector3 rayDirection = (player.position - transform.position); //.normalized * maout hitxRadius;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                //Debug.Log("Can see player");
                isInFov = true;
            }
            else
            {
                //Debug.Log("Can not see player");
                isInFov = false;

            }
        }

        //draw depending on if player in fov?
        if (isInFov == true)
        {
            //distance between object and target
            Vector3 relativePos = player.transform.position - transform.position;
            //rotate object to look at target
            Quaternion endRotation = Quaternion.LookRotation(relativePos);  //(relativePos, vector3 that tells which direction is up);


            //local rotation of object
            Quaternion currentRotation = transform.localRotation;

            //use slerp to slowly turn the object to face the target, slerp(start, end, speed of turn)
            transform.localRotation = Quaternion.Slerp(currentRotation, endRotation, 0.0125f);


            //this.transform.LookAt(player.transform.position);


            StartCoroutine(Fire());
        }
           
    }

    private IEnumerator Fire()
    {
       // SagAnime.SetBool("attack", true);

        //instanciate bullet
        GameObject newBullet = Instantiate(bullet, bulletPos.position, Quaternion.identity);

        //get bullet rigid body
        Rigidbody bulletRig = newBullet.GetComponent<Rigidbody>();

        //shoot bullet
        bulletRig.velocity = new Vector3(bulletPos.transform.forward.x, bulletPos.transform.forward.y, bulletPos.transform.forward.z) * speed;
        // bulletRig.AddForce(transform.forward * speed);

        //wait to shoot
        yield return new WaitForSeconds(pauseTime);
      //  SagAnime.SetBool("attack", false);

    }

    /*
    private void OnDrawGizmos()
    {
        //draws sphere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        //fov lines 
        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        //is player in fov?
        RaycastHit hit;
        Vector3 rayDirection = (player.position - transform.position); //.normalized * maout hitxRadius;
        if (Physics.Raycast(transform.position, rayDirection, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                //Debug.Log("Can see player");
                isInFov = true;
            }
            else
            {
                //Debug.Log("Can not see player");
                isInFov = false;
            }
        }

        //draw depending on if player in fov?
        if (isInFov == false)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

        //draws radius
        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);


    }
    */


}





//////Bullet script
    /*
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
        if (lookingAt == true && canShoot == true)
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
        bulletRig.velocity = new Vector3(bulletPos.transform.forward.x, bulletPos.transform.forward.y, bulletPos.transform.forward.z) * speed;
        // bulletRig.AddForce(transform.forward * speed);

        //wait to shoot
        yield return new WaitForSeconds(pauseTime);

        canShoot = true;
    }


    //look at player
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
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
        if (other.tag == "Player")
        {
            lookingAt = false;
            canShoot = false;

            //resume previouse actions

            //for frog
            Quaternion currentRotation = this.transform.rotation;

            Quaternion endRotation = Quaternion.Euler(transform.forward);

            transform.rotation = Quaternion.Lerp(endRotation, currentRotation, 0.125f);
        }
    }*/

