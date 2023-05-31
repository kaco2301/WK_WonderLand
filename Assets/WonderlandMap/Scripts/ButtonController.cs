using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public float activateDistance = 3f;
    public Button button;

    private Transform player;
    private bool isPlayerInRange = false;

    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene2");
    }

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        button.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            button.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            button.gameObject.SetActive(false);
        }
    }


    void Update()
    {
        if (isPlayerInRange)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance > activateDistance)
            {
                button.gameObject.SetActive(false);
                isPlayerInRange= false;
            }
        }
            
        
        
    }
}
