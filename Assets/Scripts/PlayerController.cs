using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 20f;
    
    Rigidbody2D _rb2d;
    
    private bool _canMove = true;

    private SurfaceEffector2D _surfaceEffector2D;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        if (_canMove)
        {
            RotatePlayer();
            RespondToBoost(); 
        }
        
    }

    public void DisableControls()
    {
        _canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            _surfaceEffector2D.speed = baseSpeed;
        }
    }

    // Update is called once per frame
    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }
}
