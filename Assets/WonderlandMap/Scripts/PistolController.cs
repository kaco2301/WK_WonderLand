using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour
{
    public GameObject Pistol;
    public Transform SpawnPoint;
    public Transform Bullet;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PistolShot();
        }
    }

    void PistolShot()
    {
        
            Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
        
    }
}
