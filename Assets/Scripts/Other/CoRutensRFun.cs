using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRutensRFun : MonoBehaviour
{
    //I want to chase the player
    public GameObject PlayerGO;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SlowUpdate());
    }

    public IEnumerator SlowUpdate()
    {
        yield return StartCoroutine(SlowStart());
        while (true)
        {
            Debug.Log("inside SlowUpdate");
            yield return new WaitForSeconds(0.5f);
        }
    }


    public IEnumerator SlowStart()
    {
        yield return StartCoroutine(SlowStart());
        while (PlayerGO = null)
        {
            yield return new WaitForSeconds(0.1f);
            PlayerGO = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("inside Update");
    }
}
