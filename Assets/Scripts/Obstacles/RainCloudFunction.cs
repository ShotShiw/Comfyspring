using System.Collections;
using UnityEngine;

public class RainCloudFunction : MonoBehaviour
{
    public Transform cloudTransform;
    private PlayerController playerController;
    [SerializeField] private GameObject dropletPrefab;
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
        InvokeRepeating("SpawnDroplet", 1, 0.65f);
    }

    void SpawnDroplet()
    {
        if (!playerController.inShop)
        {
            Instantiate(dropletPrefab, new Vector3(cloudTransform.position.x + Random.Range(-1.8f, 1.8f), cloudTransform.position.y, cloudTransform.position.z), Quaternion.identity);
        }
    }
}
