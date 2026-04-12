using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameObject cameraObj;

    private float speed = 5f;
    public float xBound = 6f;
    private float yBound = 4.5f;

    public bool xBounded;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayerBounds();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");



        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
    }

    void PlayerBounds()
    {
      if (xBounded) 
      { 
        float camBoundsPos = cameraObj.transform.position.x + xBound;
        float camBoundsNeg = cameraObj.transform.position.x - xBound;
        if (transform.position.x > camBoundsPos)
        {
            transform.position = new Vector3(camBoundsPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x < camBoundsNeg)
        {
            transform.position = new Vector3(camBoundsNeg, transform.position.y, transform.position.z);
        }
      }

        if (transform.position.y > yBound)
        {
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);
        }
        if (transform.position.y < -yBound)
        {
            transform.position = new Vector3(transform.position.x, -yBound, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Beehive"))
        {
            SceneManager.LoadScene("Shop");
        }
    }

}
