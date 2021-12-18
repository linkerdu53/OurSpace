using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class userInterface : MonoBehaviourSingleton<userInterface>
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject m_GameOverTXT;

    [SerializeField]
    private Button m_RestartButton;

    [SerializeField]
    private Text m_ScoreTXT;

    [SerializeField]
    private Slider m_LifeBar;

    [SerializeField]
    private GameObject m_panel;

    /// <summary>
    /// Couleur du slider 
    /// </summary>
    [SerializeField]
    private Image m_fill;
    private Color m_maxHealthColor = Color.green;
    private Color m_lowHealthColor = Color.red;

    /// <summary>
    /// GameObject qui représente notre joueur
    /// </summary>
    [SerializeField]
    private GameObject m_ThePlayer;
    protected override void Awake()
    {
        base.Awake();
        m_GameOverTXT.SetActive(false);
        m_RestartButton.gameObject.SetActive(false);
        m_ThePlayer.GetComponent<Player>().changeScoreEvent += updateScore;
        m_ThePlayer.GetComponent<Player>().changeHPEvent += updateLife;

        m_RestartButton.onClick.AddListener(gameManager.Instance.ResetLevel);
    }
    private void Start()
    {
        m_LifeBar.maxValue = m_ThePlayer.GetComponent<Player>().getMaxHP();
        m_LifeBar.value = m_ThePlayer.GetComponent<Player>().readCurrentPV();
        m_ScoreTXT.text = "0";
        m_fill.color = m_maxHealthColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void updateScore(int score)
    {
        m_ScoreTXT.text = score.ToString();
    }

    private void updateLife(int currentHP)
    {
        m_LifeBar.value = currentHP;
        m_fill.color = Color.Lerp(m_lowHealthColor, m_maxHealthColor, (float)currentHP / (float)m_ThePlayer.GetComponent<Player>().getMaxHP());
        if(currentHP <= 0)
        {
            m_GameOverTXT.SetActive(true);
            m_RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void togglePausePanel(bool pause)
    {
        m_panel.SetActive(pause);
    }
}
