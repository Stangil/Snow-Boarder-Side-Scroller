using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private bool hasCrashed = false;

    private void Start()
    {
        hasCrashed = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !hasCrashed)
        {            
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            
            hasCrashed=true;
            Invoke("ReLoadScene", delayTime);
        }
    }
    private void ReLoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
