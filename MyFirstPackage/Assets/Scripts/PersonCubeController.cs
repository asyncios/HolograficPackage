using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PersonCubeController : MonoBehaviour {

    private int vida;
    public Image[] barraVida;
    public Image[] images;
    public GameObject canvasBarraVida;
    // Use this for initialization
    void Start () {
        vida = 5;
        barraVida = canvasBarraVida.GetComponentsInChildren<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("SaberCollisionBox"))
        {
            if (vida > 0)
            {
                barraVida[vida - 1].enabled = false;
                vida--;
            }
            else
            {

            }
        }
        
        //if (!other.gameObject.name.Equals("Cube"))
        //{
            
        //}

    }
}
