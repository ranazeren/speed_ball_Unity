using JetBrains.Annotations;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]

    private float pushForce = 800f;
    private float movement;
    [SerializeField]

    private float speed = 3f;
    public Vector3 respawnPoint;
    public GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = this.transform.position;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, pushForce * Time.fixedDeltaTime);
        rb.linearVelocity = new Vector3(movement * speed, rb.linearVelocity.y, rb.linearVelocity.z);
        FallDetector();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("bariyer"))
        {
            gameManager.RespawnPoint();
        }


    }
    private void FallDetector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPoint();
        }
    }
    private void OTriggerEnter(Collider other)
    {
        if (other.CompareTag("EndTrigger"))
        {
            gameManager.LevelUp();
        }
        
    }
}
