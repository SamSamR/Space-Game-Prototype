using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make object orbit around target
public class Orbit : MonoBehaviour
{
    
    public Transform target;
    public Vector3 offset = new Vector3(0, 0.5f, 0); //offset = orbs height

    private float distanceX; //distance from target,
   // public float forwardSpeedY = 0f; //height from target
    private float forwardSpeedZ = 30; //speed

    public Rigidbody orbitRig;
    public Vector3 upVector = new Vector3(0, 1, 0);
    public float speed = 1f;
   // public float lerp = 0.00125f;


    //public Vector3 relativePos;

    private float dist;

    void Start()
    {
       // orbitRig = this.gameObject.GetComponent<Rigidbody>();

        float dist = Vector3.Distance(this.target.position + offset, transform.position);
        distanceX = dist;
    }

    void FixedUpdate()
    {
        //calculates distance between target and object, add offset to account for the objects height
        Vector3 relativePos = (target.position + offset) - transform.position;

        //stores rotation of object when it's looking at target
        Quaternion endRotation = Quaternion.LookRotation(relativePos, upVector);


        //local rotation of object
        Quaternion currentRotation = transform.localRotation;
        //Debug.Log("cur " + currentRotation);
        //Debug.Log("end " + endRotation);

        //use slerp to slowly turn the object to face the target, slerp(start, end, speed of turn)
        transform.localRotation = Quaternion.Slerp(currentRotation, endRotation, Time.deltaTime*speed);
        //after we turn the object towards the target move it forward a little bit.
        transform.Translate(0, 0, distanceX * Time.deltaTime * 2 * speed);
    }
    
}
