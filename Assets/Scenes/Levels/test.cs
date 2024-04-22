using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    /*
    void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        float x = Input.GetAxisRaw("Mouse X");
        float y = Input.GetAxisRaw("Mouse Y");


        if (controller)
        {
            //move player

            //add this to make player stop suddenly
            // myRig.velocity = new Vector3(h, 0, 0).normalized * speed; // + new Vector3(0, myRig.velocity.y, 0);  //normalize to stop diagnl for being faster


            //roate based on mouse location
            yaw += RotateSpeed * x;
            pitch -= RotateSpeed * y;

            // transform.eulerAngles = new Vector3(pitch, yaw, transform.forward.z);
            Quaternion Rotation = Quaternion.Euler(pitch, yaw, transform.forward.z);

            this.transform.rotation = Quaternion.Lerp(Rotation, transform.rotation, 0.125f);

            //this.transform.eulerAngles = Vector3.Lerp(this.transform.eulerAngles, finalAngles, 0.01f);


            //use rigiid body
            //Vector3 currentAngle = new Vector3(pitch, yaw, 0);
            // myRig.angularVelocity = new Vector3(pitch, yaw, 0);
            // myRig.angularVelocity = Vector3.Lerp(new Vector3(myRig.angularVelocity.x, 0, 0), new Vector3(currentAngle.x, 0, 0), 0.125f);


            //move forward when hitting w
            if (Input.GetAxis("Vertical") != 0)
            {

                if (this.speed < 10)
                {
                    this.speed = 10;
                }

                myRig.AddForce(transform.forward * this.speed);

                PlayerPrefs.SetFloat("MaxSpeed", this.speed);


                //myRig.velocity = transform.forward * speed;
                //Debug.Log("velocity" + myRig.velocity);

                // Vector3 finalloc = transform.forward * this.speed;

                // myRig.velocity = Vector3.Lerp(myRig.velocity, finalloc, 0.125f);
                //myRig.velocity = (new Vector3(0, 0, v).normalized + transform.forward) * speed;
                playerVelocity = myRig.velocity;
            }


            //straif left
            if (Input.GetKeyDown(KeyCode.A))
            {
                myRig.AddForce(-1 * transform.right * 2000f);

            }
            //straif right
            if (Input.GetKeyDown(KeyCode.D))
            {
                myRig.AddForce(transform.right * 2000f);
            }


            //acceleration boost
            //if click is held down inccrease acceleration
            if (Input.GetMouseButton(0) && Input.GetButton("Vertical"))
            {
                if (speed < maxSpeed - 0.1f)
                {
                    this.speed = this.speed + 0.1f;

                    PlayerPrefs.SetFloat("MaxSpeed", this.speed);
                }
            }

        }

        //slow down speed
        if (Input.GetMouseButton(0) == false && Input.GetButton("Vertical") == false) //  && speed > 10)
        {
            if (speed >= 0.1)
            {
                speed -= 0.1f;
                PlayerPrefs.SetFloat("MaxSpeed", this.speed);
            }
        }

    }
    */


    
    void Start()
    {
        Shader.EnableKeyword("KEYWORD_ON");
        //Shader.DisableKeyword("KEYWORD_OFF");

        //Create a new cube primitive to set the color on
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //Get the Renderer component from the new cube
        var cubeRenderer = cube.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.SetColor("_Color", Color.red);
    }
    
}

