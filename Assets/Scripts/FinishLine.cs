using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] private ParticleSystem victory;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            victory.Play();
            Invoke("ReloadScene", delayTime);
            GetComponent<AudioSource>().Play();
        }
        
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
