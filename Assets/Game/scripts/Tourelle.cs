using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Tourelle : Entity
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera m_MainCamera = null;

    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private GameObject[] m_bonus;

    [SerializeField]
    private int m_bonusSpawnRate;

    [SerializeField]
    private float m_speedFire;
    private float m_currentSpeedFire;

    [SerializeField]
    private GameObject m_bullet;

    private Stopwatch timer;

    protected override void Awake()
    {
        base.Awake();
        m_MainCamera = Camera.main;
        timer = new Stopwatch();
        timer.Start();
        m_currentSpeedFire = m_speedFire;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        movementEnnemy();

        if (timer.Elapsed.TotalMilliseconds > m_currentSpeedFire)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 10f);
            GameObject e_bullet = Instantiate(m_bullet, pos, Quaternion.Euler(90, 0, 0));
            timer.Restart();
        }
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
        if(collision.collider.tag == "Player" || collision.collider.tag == "Bullet")
            updateCurrentPV(-1);
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
