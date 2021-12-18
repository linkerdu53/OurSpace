using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : Entity
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_b5e7df0c0b2141c18f67115a93441cfa", Random.Range(-5f, 5f));
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_202c2e6711b44ccba6dc32c3b5006f92", Random.Range(-2.5f, 2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet" || collision.collider.tag == "Player")
        {
            updateCurrentPV(-1);
            if (readCurrentPV() <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        /*
        else
        {
            updateCurrentPV(-1);
        }
        */
    }
}
