using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make object face and look at target
public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        //distance between object and target
        Vector3 relativePos = target.position - transform.position;
        //rotate object to look at target
        transform.rotation = Quaternion.LookRotation(relativePos);  //(relativePos, vector3 that tells which direction is up);

    }
}
