using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera m_MainCamera;

    [SerializeField]
    private GameObject ground;

    [SerializeField]
    private float m_speedScroll;

    private bool next; 
    void Start()
    {
        next = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 posEndGround = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - (gameObject.transform.localScale.z)/2 );
        Vector3 screenPos = m_MainCamera.WorldToScreenPoint(posEndGround);
        if (screenPos.y < Screen.height/2 + 10 && next == false)
        {
            next = true;
            UnityEngine.Debug.Log(gameObject.transform.position);
            Vector3 newpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - gameObject.transform.localScale.z*10f);
            Instantiate(ground, newpos, gameObject.transform.rotation) ;
            

        }
        if (screenPos.y <= -Screen.height)
        {
            Destroy(gameObject);
        }
       
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * m_speedScroll);
    }
}
