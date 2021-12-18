using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TranslateBackShip : MonoBehaviour
{
    public float transVitesse;
    public float positionX;
    public float positionY;
    public float positionZ;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Posi(Vector3(positionX, positionY, positionZ));
        transform.position = transform.position + new Vector3(positionX, positionY, positionZ);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * transVitesse);
        //positionX = positionX + transVitesse;
    }
}
