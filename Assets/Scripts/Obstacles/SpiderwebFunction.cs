using UnityEngine;

public class SpiderwebFunction : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    AudioManager.AM.Soundboard(7);
                    playerController.SpiderwebCollision();
                    Destroy(gameObject);
                }
            }
        }
    }

}
