using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class camSwitchMenuStart : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MainUI;

    public GameObject SecondCamera;
    public GameObject SecondUI;

    public GameObject ThirdCamera;
    public GameObject ThirdUI;

    public Button yourButton;

   


    // Start is called before the first frame update
    void Start()
    {
        MainCamera.SetActive(true);
        MainUI.SetActive(true);

        SecondCamera.SetActive(false);
        SecondUI.SetActive(false);

        ThirdCamera.SetActive(false);
        ThirdUI.SetActive(false);
        // boutton pour selection niveau
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



