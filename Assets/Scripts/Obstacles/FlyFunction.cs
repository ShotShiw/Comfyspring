using UnityEngine;

public class FlyFunction : MonoBehaviour
{
    [SerializeField] private float flyingSpeedX;
    private float flyingSpeedY;
    public Vector3 spawnPoint;
    [SerializeField] private bool verticalFlight;
    private float yBound = 4.5f;

    private void Start()
    {
        flyingSpeedX += Random.Range(-0.5f, 0.5f);
        if (verticalFlight)
        {
            flyingSpeedY = Random.Range(-0.75f, 0.75f);
        }
    }
    private void Update()
    {
        Fly();
        FlightBounds();
    }

    void Fly()
    {
        transform.Translate(Vector3.right * Time.deltaTime * -flyingSpeedX);

        if (verticalFlight)
        {
            transform.Translate(Vector3.up * Time.deltaTime * flyingSpeedY);
        }

        if (transform.position.x < (spawnPoint.x - 20)) Destroy(gameObject);
    }

    void FlightBounds()
    {
        if (transform.position.y > yBound || transform.position.y < -yBound)
        {
            flyingSpeedY = -flyingSpeedY;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -7, ForceMode2D.Impulse);
                    playerController.ObstacleCollision(3);
                    Destroy(gameObject);
                }
            }
        }
    }
}

