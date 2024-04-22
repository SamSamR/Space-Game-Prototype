using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    private IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(20f);
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
