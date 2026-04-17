using System.Collections;
using UnityEngine;

public class RainCloudFunction : MonoBehaviour
{
    public Transform cloudTransform;
    private PlayerController playerController;
    private float randomizeAmount;
    [SerializeField] private GameObject dropletPrefab;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        playerController.Restart = RandomizePosition;
        InvokeRepeating("SpawnDroplet", 1, 0.65f);
    }

    void SpawnDroplet()
    {
        if (!playerController.inShop)
        {
            Instantiate(dropletPrefab, new Vector3(cloudTransform.position.x + Random.Range(-1.8f, 1.8f), cloudTransform.position.y, cloudTransform.position.z), Quaternion.identity);
        }
    }

    private void RandomizePosition()
    {
        gameObject.transform.Translate(-randomizeAmount, 0, 0);
        randomizeAmount = Random.Range(-12.5f, 12.5f);
        gameObject.transform.Translate(randomizeAmount, 0, 0);
    }
}
