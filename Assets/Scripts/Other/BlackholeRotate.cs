﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move up and down


        //rotate
        transform.Rotate(0, 45f * Time.deltaTime, 0);

    }
}
