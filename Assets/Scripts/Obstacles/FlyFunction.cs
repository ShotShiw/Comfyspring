using UnityEngine;

public class FlyFunction : MonoBehaviour
{
    [SerializeField] private float flyingSpeed;

    private void Start()
    {
        flyingSpeed += Random.Range(-0.5f, 0.5f);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * -flyingSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * -7, ForceMode2D.Impulse);
                    playerController.ObstacleCollision(1);
                }
            }
            Destroy(gameObject);
        }
    }
}

