using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class introCamSwitch : MonoBehaviour
{
    public GameObject FirstCamera;
    public GameObject SecondCamera;
    public int timerActeulAvFinAnimation;
    public int timeFinAnimation;

    // Start is called before the first frame update
    void Start()
    {


        //FirstCamera.SetActive(true);
        //SecondCamera.SetActive(false);

        //FirstCamera.SetActive(false);
        //SecondCamera.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (timerActeulAvFinAnimation == timeFinAnimation)
        {
            FirstCamera.SetActive(false);
            SecondCamera.SetActive(true);
            timerActeulAvFinAnimation = timerActeulAvFinAnimation + 1;
        }
        else if (timerActeulAvFinAnimation < timeFinAnimation)
        {
            FirstCamera.SetActive(true);
            SecondCamera.SetActive(false);
            timerActeulAvFinAnimation = timerActeulAvFinAnimation + 1;
        }

    }


}



