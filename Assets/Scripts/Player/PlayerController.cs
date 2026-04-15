using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameObject cameraObj;
    public GameObject shop;

    private float speed = 5f;
    public float xBound = 6f;
    private float yBound = 4.5f;

    private Vector3 spawnPos;
    private bool canMove = true;

    public bool xBounded;

    [SerializeField] private GameObject[] pollen;
    void Start()
    {
        spawnPos = transform.position;
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


        if (canMove)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        }
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Beehive")
        {
            SceneManager.LoadScene("Shop");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //transform.position = spawnLocation;
            //Destroy(gameObject);
            //maybe loose nector
            Respawn();
        }
        if (other.gameObject.CompareTag("Beehive"))
        {
            canMove = false;
            //this moves the bee to the bee hive and opens the shop when close enough
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(other.transform.position.x, other.transform.position.y - 0.5f, transform.position.z), speed * Time.deltaTime);
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(other.transform.position.x, other.transform.position.y - 0.5f)) < 0.2f)
            {
                foreach (GameObject p in pollen)
                {
                    p.SetActive(true);
                }
                shop.SetActive(true);
                //SceneManager.LoadScene("Shop");
            }
        }
    }

    public void Respawn()
    {
        shop.SetActive(false);
        canMove = true;
        transform.position = spawnPos;
    }

}
