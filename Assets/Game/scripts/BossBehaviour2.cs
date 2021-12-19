using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour2 : Entity
{
    // Start is called before the first frame update
    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private Camera m_mainCamera; 

    private Vector3 m_bossEndPoint;

    protected override void Awake()
    {
        base.Awake();
        m_mainCamera = Camera.main;
        m_bossEndPoint = m_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, m_mainCamera.transform.position.y));
    }
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_b5e7df0c0b2141c18f67115a93441cfa", Random.Range(-5f, 5f));
        gameObject.GetComponent<Renderer>().material.SetFloat("Vector1_202c2e6711b44ccba6dc32c3b5006f92", Random.Range(-2.5f, 2.5f));   
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_bossEndPoint, Time.deltaTime * m_MovementSpeed);
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
       
    }
}
