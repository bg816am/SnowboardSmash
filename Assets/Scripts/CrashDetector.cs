using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // TODO: Adjust head crash behavior so it bounces instead of going under the snow.
    [SerializeField] float loadDelay = .5f;
    [SerializeField] private ParticleSystem crash;
    [SerializeField] private AudioClip crashSfx;
    
    private bool _soundPlayed = false;
    
  void OnTriggerEnter2D(Collider2D other) 
  {
      if (other.CompareTag("Ground"))
      {
          FindObjectOfType<PlayerController>().DisableControls();
          if (!_soundPlayed)
          {
              crash.Play();
              GetComponent<AudioSource>().PlayOneShot(crashSfx);
              _soundPlayed = true;
          }
          
          Invoke("ReloadScene", loadDelay);
      }
  }

  private void ReloadScene()
  {
      SceneManager.LoadScene(0);
  }
}
