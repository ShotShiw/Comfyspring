using UnityEngine;

public class SpiderwebFunction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    StartCoroutine(playerController.SlowEffect(2.5f, 5));
                    playerController.ObstacleCollision(1);
                }
            }
            Destroy(gameObject);
        }
    }

}
