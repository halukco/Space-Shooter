using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController; //score tabelasını game controllerın içine tanımlıyoruz

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>(); //score tabelasını unity arayüzündeki etikete
    }                                                                                             // göre bulmasını sağlıyoruz


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boundary") //asteroidin patlama scripti
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player") //oyuncunun ana gemisinin patlama efekti
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.UpdateScore(); // skor güncelleme
    }


}
