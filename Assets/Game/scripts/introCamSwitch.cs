using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class introCamSwitch : MonoBehaviour
{
    public GameObject FirstCamera;
    public GameObject SecondCamera;

    // Start is called before the first frame update
    void Start()
    {
        FirstCamera.SetActive(true);
        SecondCamera.SetActive(false);

        FirstCamera.SetActive(false);
        SecondCamera.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {


    }


}



