using UnityEngine;

public class WaterDroplets : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -6, ForceMode2D.Impulse);
                    playerController.ObstacleCollision(3);
                    Destroy(gameObject);
                }
            }
        }
    }
}
