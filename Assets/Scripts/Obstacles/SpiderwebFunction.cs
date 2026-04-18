using UnityEngine;

public class SpiderwebFunction : MonoBehaviour
{
    private PlayerController playerController;

    void Awake()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        playerController.Restart += Respawn;
    }

    void Respawn()
    {
        gameObject.SetActive(true);
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
                    AudioManager.AM.Soundboard(7);
                    playerController.SpiderwebCollision();
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
