using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // TODO: Adjust head crash behavior so it bounces instead of going under the snow.
    [SerializeField] float loadDelay = .5f;
    [SerializeField] private ParticleSystem crash;
    [SerializeField] private AudioClip crashSfx;
    
  void OnTriggerEnter2D(Collider2D other) 
  {
      if (other.tag == "Ground")
      {
          FindObjectOfType<PlayerController>().DisableControls();
          crash.Play();
          GetComponent<AudioSource>().PlayOneShot(crashSfx);
          Invoke("ReloadScene", loadDelay);
      }
  }

  private void ReloadScene()
  {
      SceneManager.LoadScene(0);
  }
}
