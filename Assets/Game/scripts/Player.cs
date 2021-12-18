using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class Player : Entity
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera m_MainCamera = null;

    [SerializeField]
    private float m_VerticalSpeed;
    private float m_currentVerticalSpeed;

    [SerializeField]
    private float m_HorizontalSpeed;
    private float m_currentHorizontalSpeed;

    [SerializeField]
    private float m_speedFire;
    private float m_currentSpeedFire;

    [SerializeField]
    private GameObject m_bullet;

    [SerializeField]
    private GameObject m_shield;

    private Stopwatch timer;

    private int score;

    private bool isBonusActive;
    [SerializeField]
    private float bonusDuration;
    private Stopwatch bonusTimer;
    private int typeOfBonus;

    public delegate void onHPChange(int currentHP);
    public event onHPChange changeHPEvent;
    public delegate void onScoreChange(int score);
    public event onScoreChange changeScoreEvent;
    

    protected override void Awake()
    {
        base.Awake();
        //m_MainCamera = Camera.main; 
        timer = new Stopwatch();
        bonusTimer = new Stopwatch();
        timer.Start();
        isBonusActive = false;
        m_currentSpeedFire = m_speedFire;
        m_currentVerticalSpeed = m_VerticalSpeed;
        m_currentHorizontalSpeed = m_HorizontalSpeed;
        m_shield.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        PlayerControl();
        bonusControl();
    }

    private void PlayerControl()
    {
        Vector3 screenPos = m_MainCamera.WorldToScreenPoint(gameObject.transform.position);
    
        
        //ROTATION DROITE
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(screenPos.x >= 0)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + (m_currentHorizontalSpeed * Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
            }
            
        }
        //ROTATION GAUCHE
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (screenPos.x <= Screen.width)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + (-m_currentHorizontalSpeed * Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (screenPos.y >= 0 )
            {
                gameObject.transform.Translate(Vector3.forward * m_currentVerticalSpeed * Time.deltaTime);
            }
            
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (screenPos.y <= Screen.height)
            {
                gameObject.transform.Translate(Vector3.forward * (-m_currentVerticalSpeed) * Time.deltaTime);
            }
                
        }

        if (Input.GetKey(KeyCode.Space) && timer.Elapsed.TotalMilliseconds > m_currentSpeedFire)
        {
            if (typeOfBonus == 3)
            {
                for (int i = 0; i<3; i++)
                {
                    Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);
                    GameObject e_bullet = Instantiate(m_bullet, pos, Quaternion.Euler(90, 0, 0));
                    e_bullet.GetComponent<bullet>().BulletHitEvent += updateScore;
                    e_bullet.GetComponent<bullet>().setDirection(i);
                }
            }
            else if(typeOfBonus == 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector3 pos = new Vector3(gameObject.transform.position.x - 5.5f +(i*5.5f), gameObject.transform.position.y, gameObject.transform.position.z - 3f);
                    GameObject e_bullet = Instantiate(m_bullet, pos, Quaternion.Euler(90, 0, 0));
                    e_bullet.GetComponent<bullet>().BulletHitEvent += updateScore;
                }
            }
            else
            {
                Vector3 pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 3f);
                GameObject e_bullet = Instantiate(m_bullet, pos, Quaternion.Euler(90, 0, 0));
                e_bullet.GetComponent<bullet>().BulletHitEvent += updateScore;
            }
            
            
;           timer.Restart();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.collider.tag == "Ennemy")
        {
            updateCurrentPV(-1);
            //UnityEngine.Debug.Log(readCurrentPV());
            changeHPEvent(readCurrentPV());
        }

        if(collision.collider.tag == "Bonus")
        {
            if (isBonusActive)
                bonusTimer.Restart();
            else
                bonusTimer.Start();

            isBonusActive = true;
            UnityEngine.Debug.Log("Bonus collected");
            typeOfBonus = collision.collider.gameObject.GetComponent<bonus>().bonusType;
            if(typeOfBonus == 5)
            {
                updateCurrentPV(1);
                changeHPEvent(readCurrentPV());
            }
            if(typeOfBonus == 6)
            {
                m_shield.GetComponent<Shield>().restoreShield();
            }
            UnityEngine.Debug.Log(typeOfBonus);
        }
    }

    private void updateScore()
    {
        score += 50;
        //UnityEngine.Debug.Log(score);
        changeScoreEvent(score);
    }

    public int getMaxHP()
    {
        return m_MaxPv;
    }

    private void bonusControl()
    {
        if(bonusTimer.IsRunning == true)
        {
            if (bonusTimer.Elapsed.TotalSeconds > bonusDuration)
            {
                isBonusActive = false;
                typeOfBonus = 0;
                bonusTimer.Stop();
                bonusTimer.Reset();

                m_currentSpeedFire = m_speedFire;
                m_currentHorizontalSpeed = m_HorizontalSpeed;
                m_currentVerticalSpeed = m_VerticalSpeed;
            }
            else if (isBonusActive)
            {
                if (typeOfBonus == 1)
                {
                    m_currentSpeedFire = m_speedFire / 2;
                    m_currentHorizontalSpeed = m_HorizontalSpeed;
                    m_currentVerticalSpeed = m_VerticalSpeed;
                }
                else if (typeOfBonus == 2)
                {
                    m_currentSpeedFire = m_speedFire;
                    m_currentHorizontalSpeed = m_HorizontalSpeed * 1.5f;
                    m_currentVerticalSpeed = m_VerticalSpeed * 1.5f;
                }
            }
        }
        
    }
}
