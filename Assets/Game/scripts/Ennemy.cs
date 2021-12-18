using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Entity
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera m_MainCamera = null;

    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private GameObject m_bonus;

    protected override void Awake()
    {
        base.Awake();
        m_MainCamera = Camera.main;
    }
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_b5e7df0c0b2141c18f67115a93441cfa", Random.Range(-5f,5f));
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_202c2e6711b44ccba6dc32c3b5006f92", Random.Range(-2.5f, 2.5f));
    }

    // Update is called once per frame
    void Update()
    {
        movementEnnemy();
    }

    private void movementEnnemy()
    {
        Vector3 screenPos = m_MainCamera.WorldToScreenPoint(gameObject.transform.position);
        if (/*screenPos.y > Screen.height ||*/ screenPos.y < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.Translate(Vector3.forward * m_MovementSpeed * Time.deltaTime);
        }   
    }


    private void OnCollisionEnter(Collision collision)
    {
        updateCurrentPV(-1);
        if (readCurrentPV() <= 0)
        {
            if (Random.Range(0, 100) < 50)
                Instantiate(m_bonus, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        /*
        else
        {
            updateCurrentPV(-1);
        }
        */
    }
}
