using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDissolver : MonoBehaviour
{
    //gets renderer
    Renderer rend;

    public GameObject boss;

    //disolve values
    public float targetDissolveValue = 1f;
    private float currentDissolveValue = 1f;

    public float disolveSpeed = 2f;
    public float disolveTime = 1.5f;
    public float getHealth;

    private Enemy enemyHealth;

    private void Start()
    {
        Shader.EnableKeyword("KEYWORD_ON");
       
        //get EnemyHealth script
        enemyHealth = this.boss.GetComponent<Enemy>();

        //get material
        rend = GetComponent<Renderer>();
        //find shader
        rend.material.shader = Shader.Find("Shader Graphs/Enemy");
        
    }

    void Update()
    {
        getHealth = enemyHealth.currentHealth;

        //animate the desolve/health value
        if (getHealth == 0)
        {
            StartCoroutine(DesolveTimer());
            
            targetDissolveValue = 0.265f;
            currentDissolveValue = Mathf.Lerp(currentDissolveValue, targetDissolveValue, disolveSpeed * Time.deltaTime);

            if(currentDissolveValue <= 0.266)
            {
                currentDissolveValue = 0;
            }
            rend.material.SetFloat("_Health", currentDissolveValue);

            //float currenthealth = rend.material.GetFloat("_Health");
            //Debug.Log("current desolve value" +currenthealth);
        }        
    }

    private IEnumerator DesolveTimer()
    {
        yield return new WaitForSeconds(disolveTime);
        Destroy(this.gameObject);
    }
}
