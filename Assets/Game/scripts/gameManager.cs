using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviourSingleton<gameManager>
{
    // Start is called before the first frame update
    private bool m_paused;
    public Button yourButton;
    public int clicBtnResume;

    public bool statePause
    {
        get{ return m_paused;}
        protected set{ m_paused = value;}
    }
    void Start()
    {
        m_paused = false;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Resume);
        Play(m_paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            m_paused = !m_paused;
            Play(m_paused);

        }else if (clicBtnResume == 1)
        {
            clicBtnResume = 0;
            m_paused = !m_paused;
            Play(m_paused);
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Play(bool play)
    {
        userInterface.Instance.togglePausePanel(play);
        Time.timeScale = play ? 0 : 1;
    }
    public void Resume()
    {
        clicBtnResume = 1;
    }
}
