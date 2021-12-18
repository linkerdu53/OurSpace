using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera m_mainCamera = null;

    [SerializeField]
    private float m_bulletSpeed;

    private int score;

    public delegate void OnBulletHit();
    public event OnBulletHit BulletHitEvent;


    private void Awake()
    {
        m_mainCamera = Camera.main;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = m_mainCamera.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.y > Screen.height || screenPos.y < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.transform.Translate(Vector3.up * -m_bulletSpeed * Time.deltaTime);
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ennemy")
        {
            BulletHitEvent();
            Destroy(gameObject);
        }
    }
}
