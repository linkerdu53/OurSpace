using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BossBehaviour1 : Entity
{
    [SerializeField]
    private float m_MovementSpeed;

    [SerializeField]
    private Camera m_mainCamera;

    private Vector3 m_bossEndPoint;

    [SerializeField]
    private float m_speedFire;
    private float m_currentSpeedFire;

    [SerializeField]
    private GameObject m_bullet;

    private Stopwatch timer;

    protected override void Awake()
    {
        base.Awake();
        m_mainCamera = Camera.main;
        m_bossEndPoint = m_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, m_mainCamera.transform.position.y));
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
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, m_bossEndPoint, Time.deltaTime * m_MovementSpeed);
        if (timer.Elapsed.TotalMilliseconds > m_currentSpeedFire)
        {
            Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 10f);
            GameObject e_bullet = Instantiate(m_bullet, pos, Quaternion.Euler(90, 0, 0));
            timer.Restart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet" || collision.collider.tag == "Player")
        {
            updateCurrentPV(-1);
            if (readCurrentPV() <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
