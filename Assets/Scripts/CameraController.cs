using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject startBeehive;
    public GameObject endBeehive;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = playerCharacter.GetComponent<PlayerController>();
    }
    void Update()
    {
        float playerPosX = playerCharacter.transform.position.x;

        if (playerPosX < startBeehive.transform.position.x || playerPosX > endBeehive.transform.position.x)
        {
            playerController.xBounded = true;
            return;
        }
        else
        {
            playerController.xBounded = false;
            transform.position = new Vector2(playerPosX, transform.position.y);
        }
    }
}
