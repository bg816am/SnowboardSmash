using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // TODO: Adjust head crash behavior so it bounces instead of going under the snow.
    [SerializeField] float loadDelay = .5f;
  void OnTriggerEnter2D(Collider2D other) 
  {
      if (other.tag == "Ground")
      {
          Invoke("ReloadScene", loadDelay);
      }
  }

  void ReloadScene()
  {
      SceneManager.LoadScene(0);
  }
}
