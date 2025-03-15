using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); //oyunun sınırına gelen asteroidlerin ve lazerin patlamasını sağladık
    }
}
