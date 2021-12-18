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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnnemies(m_SpawnTime, m_ennemy, m_MainCamera));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnnemies(float spawnTime, GameObject ennemy, Camera mainCamera)
    {
        while (Application.isPlaying)
        {
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width),Screen.height, mainCamera.transform.position.y));
            worldPos = new Vector3(worldPos.x, worldPos.y, worldPos.z - 50f);
            Instantiate(ennemy, worldPos, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(spawnTime);
        }
        yield return 0;
    }
}