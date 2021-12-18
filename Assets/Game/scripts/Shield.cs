using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Entity
{
    protected override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restoreShield()
    {
        updateCurrentPV(m_MaxPv);
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ennemy")
        {
            updateCurrentPV(-1);
            if (readCurrentPV() <= 0)
            {
                gameObject.SetActive(false);
            }
        }   
    }
}
