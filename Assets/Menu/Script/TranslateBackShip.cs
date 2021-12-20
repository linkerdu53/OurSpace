using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TranslateBackShip : MonoBehaviour
{
    public GameObject vaisseauBack;
    public float transVitesse;
    public float positionXInit;
    public float positionYInit;
    public float positionZInit;
    public float facteurAlea;
    public int tempsAvRetour;
    public int tempsAvRetourActuel;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Posi(Vector3(positionX, positionY, positionZ));
        //vaisseauBack = this.GameObject;
        facteurAlea = Random.Range(1, 5);
        transform.position = transform.position + new Vector3(positionXInit * facteurAlea, positionYInit* facteurAlea, positionZInit* facteurAlea);


    }

    // Update is called once per frame
    void Update()
    {

        tempsAvRetourActuel = tempsAvRetourActuel + 1;
        transform.Translate(Vector3.forward * Time.deltaTime * transVitesse *facteurAlea);
        if(tempsAvRetourActuel >= tempsAvRetour)
        {
            facteurAlea = Random.Range(1, 5);
            transform.position = new Vector3(positionXInit * facteurAlea, positionYInit * facteurAlea, positionZInit * facteurAlea);
            tempsAvRetourActuel = 0;
            
        }
        //positionX = positionX + transVitesse;
    }
}
