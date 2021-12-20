using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnnemiesManager : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera = null;
    [SerializeField]
    private GameObject[] m_ennemy;
    [SerializeField]
    private float[] m_SpawnTime;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private int m_scoreBeforeBoss;
    [SerializeField]
    private GameObject boss = null; 
    private bool spawn_boss;
    private Stopwatch timer;
    private bool[] launch; 

    // Start is called before the first frame update
    void Start()
    {
        launch =  new bool[m_ennemy.Length];
        for(int i = 0; i< m_ennemy.Length; i++)
        {
            launch[i] = false;   
        }
        spawn_boss = false;
        timer = new Stopwatch();
        timer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_ennemy.Length; i++)
        {
            if(launch[i] == false && timer.Elapsed.TotalSeconds > m_SpawnTime[i] + Random.Range(m_SpawnTime[i]/4, m_SpawnTime[i] / 2))
            {
                launch[i] = true;
                StartCoroutine(spawnEnnemies(m_SpawnTime[i], m_ennemy[i], m_MainCamera, m_scoreBeforeBoss, m_player));
            }
           
        }
        if (!spawn_boss)
        {
            if(m_player.GetComponent<Player>().getScore() > m_scoreBeforeBoss && boss != null)
            {
                spawn_boss = true;
                Vector3 worldPos = m_MainCamera.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height, m_MainCamera.transform.position.y));
                worldPos = new Vector3(worldPos.x, worldPos.y, worldPos.z -100f);
                Instantiate(boss, worldPos, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    private IEnumerator spawnEnnemies(float spawnTime, GameObject ennemy, Camera mainCamera, int scoreBoss, GameObject player)
    {
        while (Application.isPlaying)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width),Screen.height, mainCamera.transform.position.y));
            worldPos = new Vector3(worldPos.x, worldPos.y, worldPos.z - 50f);
            Instantiate(ennemy, worldPos, Quaternion.Euler(0, 0, 0));
            if(player.GetComponent<Player>().getScore() > scoreBoss)
                yield return new WaitForSeconds(spawnTime/2);
            else
                yield return new WaitForSeconds(Random.Range((spawnTime- spawnTime/3), (spawnTime + spawnTime/3)));
        }
        yield return 0;
    }
}
