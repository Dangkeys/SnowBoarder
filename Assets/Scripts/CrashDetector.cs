using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem loseEffect;
    [SerializeField] float loadDelay = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            loseEffect.Play();
            Invoke("ReloadScene", loadDelay);
        }

    }
    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
