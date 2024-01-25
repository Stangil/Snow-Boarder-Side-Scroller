using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;
    [SerializeField] ParticleSystem finishEfect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEfect.Play();
            Invoke("LoadNewScene", delayTime);
        }        
    }
    private void LoadNewScene()
    {
        SceneManager.LoadScene(0);
    }
}
