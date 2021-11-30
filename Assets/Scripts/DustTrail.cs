using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustTrail;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            dustTrail.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            dustTrail.Stop();
        }
}
        
    }

