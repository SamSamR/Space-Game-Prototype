using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAccelScript : MonoBehaviour
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

    
    void Update()
    {
        //rotate
        transform.Rotate(0, 45f * Time.deltaTime, 0);
    }
}
