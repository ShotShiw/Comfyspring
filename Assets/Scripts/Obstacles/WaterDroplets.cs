using System.Collections;
using UnityEngine;

public class WaterDroplets : MonoBehaviour
{
    [SerializeField] private ParticleSystem waterParticle;

    private void Awake()
    {
        StartCoroutine("AutoDestroy");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            ParticleCheck();
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                var playerController = collision.gameObject.GetComponent<PlayerController>();
                if (!playerController.invincible)
                {
                    AudioManager.AM.Soundboard(6);
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * -6, ForceMode2D.Impulse);
                    playerController.ObstacleCollision(3);
                    ParticleCheck();
                    Destroy(gameObject);
                }
            }
        }
    }
    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

    void ParticleCheck()
    {
        if (waterParticle != null)
        {
            waterParticle.transform.parent = null;
            waterParticle.Play();

            Destroy(waterParticle.gameObject, waterParticle.main.duration);
        }
    }

}
