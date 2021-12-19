using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviourSingleton<gameManager>
{
    // Start is called before the first frame update
    private bool m_paused;
    public bool statePause
    {
        get{ return m_paused;}
        protected set{ m_paused = value;}
    }
    void Start()
    {
        m_paused = false;
        Play(m_paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
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
}
