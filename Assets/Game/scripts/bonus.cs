using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonus : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed;

    private int m_bonusType;

    public int bonusType
    {
        get { return m_bonusType; }
        protected set { m_bonusType = value; }
    }
    // Start is called before the first frame update

    private void Awake()
    {
        m_bonusType = Random.Range(1, 7);
    }

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        movemementBonus();
    }

    private void movemementBonus()
    {
        gameObject.transform.Translate(Vector3.forward * m_MovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
