using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBoss : MonoBehaviour
{
    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private float m_slideSpeed;

    private bool sens;
    private Vector3 endPointRight;
    private Vector3 endPointLeft;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = Camera.main;
        sens = false;
        endPointRight = m_camera.ScreenToWorldPoint(new Vector3(Screen.width , Screen.height, m_camera.transform.position.y));
        endPointLeft = m_camera.ScreenToWorldPoint(new Vector3(0, Screen.height, m_camera.transform.position.y));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BossBehaviour1>().getStop() == true)
        {

            Vector3 screenPos = m_camera.WorldToScreenPoint(gameObject.transform.position);
            if (sens == true)
            {
                Debug.Log("ici");
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPointRight, Time.deltaTime * m_slideSpeed);
                if (gameObject.transform.position == endPointLeft)
                    sens = !sens;
            }              
            else if (sens == false)
            {
                Debug.Log("là");
                Debug.Log(Screen.width);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, endPointLeft, Time.deltaTime * m_slideSpeed);
                if (gameObject.transform.position == endPointLeft)
                    sens = !sens;
            }
            
        }
       
    }
}
