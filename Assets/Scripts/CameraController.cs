using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCharacter;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = playerCharacter.GetComponent<PlayerController>();
    }
    void Update()
    {
        float playerPosX = playerCharacter.transform.position.x;

        if (playerPosX < 0 || playerPosX > (playerController.xBound * 11)) return;

        transform.position = new Vector2 (playerPosX, transform.position.y);
    }
}
