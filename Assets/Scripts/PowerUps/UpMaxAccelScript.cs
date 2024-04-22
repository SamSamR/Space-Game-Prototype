using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMaxAccelScript : MonoBehaviour
{
    public Rigidbody myRig;

    // Start is called before the first frame update
    void Start()
    {
        myRig = this.gameObject.GetComponent<Rigidbody>();

        if (myRig == null)
        {
            //throw exception
            throw new System.Exception("Could not find Ridgedbody");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move up and down


        //rotate
        transform.Rotate(0, 45f * Time.deltaTime, 0);

    }
}
