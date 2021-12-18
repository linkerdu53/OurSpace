using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class EnnemiesManager : MonoBehaviour
{
    [SerializeField]
    private Camera m_MainCamera = null;

    [SerializeField]
    private GameObject m_ennemy;

    [SerializeField]
    private float m_SpawnTime;

    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private int m_scoreBeforeBoss;

    [SerializeField]
    private GameObject boss; 

    private bool spawn_boss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(m_SpawnTime, m_ennemy, m_MainCamera, m_scoreBeforeBoss, m_player));
        spawn_boss = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawn_boss)
        {
            if(m_player.GetComponent<Player>().getScore() > m_scoreBeforeBoss)
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
                yield return new WaitForSeconds(spawnTime);
        }
        yield return 0;
    }
}
