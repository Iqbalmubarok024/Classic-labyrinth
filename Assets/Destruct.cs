using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
            SelfDestruct();
    }

     private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }
}
