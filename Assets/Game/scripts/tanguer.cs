using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanguer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float m_rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sideToTanger();
    }

    void sideToTanger()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion targetedRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -25);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetedRotation, m_rotationSpeed * Time.deltaTime);
        }
        //ROTATION GAUCHE
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion targetedRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 25);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetedRotation, m_rotationSpeed * Time.deltaTime);
        }
        //Remise à plat 
        else
        {
            Quaternion targetedRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetedRotation, m_rotationSpeed * Time.deltaTime);
        }
    }
}
