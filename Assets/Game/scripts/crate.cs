using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crate : Entity
{
    [SerializeField]
    private Camera m_MainCamera = null;

    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private GameObject[] m_bonus;

    [SerializeField]
    private int m_bonusSpawnRate;

    [SerializeField]
    private ParticleSystem impactParticle;

    protected override void Awake()
    {
        base.Awake();
        m_MainCamera = Camera.main;
    }
    void Start()
    {
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
        if (collision.collider.tag == "Player" || collision.collider.tag == "Bullet")
        {
            impactParticle.Play();
            updateCurrentPV(-1);
        }
            
        if (readCurrentPV() <= 0)
        {
            if (Random.Range(0, 100) < m_bonusSpawnRate)
            {
                Instantiate(m_bonus[Random.Range(0, m_bonus.Length)], gameObject.transform.position, Quaternion.Euler(new Vector3(0f, -0, 75f)));
            }

            Destroy(gameObject);
        }
    }
}
