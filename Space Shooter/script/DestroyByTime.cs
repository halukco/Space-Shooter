using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifeTime;
                                // astreoid ve gemi patladıktan sonra hala oyun objesi olarak görünmesini engelliyoruz
    void Start()
    {                       // unity içerisinden 2 saniyelik yaşam süresi verdik
        Destroy(gameObject, lifeTime);
    }

    
}
