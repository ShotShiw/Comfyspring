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
        InvokeRepeating("SpawnDroplet", 1, 1.25f);
    }

    void SpawnDroplet()
    {
        if (!playerController.inShop)
        {
            Instantiate(dropletPrefab, new Vector3(cloudTransform.position.x + Random.Range(-2, 2), cloudTransform.position.y, cloudTransform.position.z), Quaternion.identity);
        }
    }
}
