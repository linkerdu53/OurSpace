using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class camSwitchMenu : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MainUI;

    public GameObject SecondCamera;
    public GameObject SecondUI;

    public Button yourButton;

   


    // Start is called before the first frame update
    void Start()
    {

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
       

        MainCamera.SetActive(false);
        MainUI.SetActive(false);

        SecondCamera.SetActive(true);
        SecondUI.SetActive(true);
        Debug.Log("Click gauche souris exact");
    }

}



