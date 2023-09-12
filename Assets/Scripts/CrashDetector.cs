using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem loseEffect;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            if (!hasCrashed)
            {
                FindObjectOfType<PlayerController>().DisablePlayerMovement();
                hasCrashed = true;
            }
            loseEffect.Play();
            Invoke("ReloadScene", loadDelay);
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }

    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
