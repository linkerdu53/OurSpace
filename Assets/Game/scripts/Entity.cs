using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected int m_MaxPv;

    private int m_currentPv;

    protected virtual void Awake()
    {
        m_currentPv = m_MaxPv;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void updateCurrentPV(int damage)
    {
        m_currentPv += damage;
    }

    public int readCurrentPV()
    {
        return m_currentPv;
    }
}
