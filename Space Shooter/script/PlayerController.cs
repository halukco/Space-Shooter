using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;  //oyunun sınırlarını tanımladım
}

public class PlayerController : MonoBehaviour
{
    Rigidbody physic; //physic atadım
    AudioSource audioPlayer;

    [SerializeField] int speed;     //serialize kullanarak serileştirdik
    [SerializeField] int tilt;
    [SerializeField] float nextFire;
    [SerializeField] float fireRate;

    public Boundary boundary;   // oyununsınırını,araçtan çıkan lazer ve lazerin oluşturulma süresini public yapıp unity üzerinden kontrol ettim
    public GameObject shot;  
    public GameObject shotSpawn;
    


    void Start()
    {
        physic = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>(); //unity arayüzündeki ses dosyasına ulaştık
    }

    void Update()
    {
        

        
        if (Input.GetButton("Fire1") && Time.time > nextFire) //ateş etmeyi sağladım
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation); // lazeri oluşturduk
            audioPlayer.Play(); //lazer ateşlendiğinde çıkan sesi ayarladım
        }
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // geminin yatay düzlemde hareketi
        float moveVertical = Input.GetAxis("Vertical"); //geminin dikey düzlemde hareketi

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        physic.velocity = movement * speed; //geminin gidiş hızını ayarladım

        Vector3 position = new Vector3(
            Mathf.Clamp(physic.position.x, boundary.xMin, boundary.xMax), //oyunun sınırlarını x ekseninde belirledim
            0, 
            Mathf.Clamp(physic.position.z, boundary.zMin, boundary.zMax)  // oyunun sınırlarını z ekseninde belirledim 
            );

        physic.position = position;

        physic.rotation = Quaternion.Euler(0, 0, physic.velocity.x * tilt); //geminin a ve d basarken ki eğimini verdim
    }
}
