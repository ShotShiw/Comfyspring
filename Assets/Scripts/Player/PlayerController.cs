//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public GameObject cameraObj;
    public GameObject shop;
    public Rigidbody2D rb2D;
    public PlayerPollen playerPollen;
    

    private float speed = 5f;
    public float xBound = 6f;
    private float yBound = 4.5f;

    private Vector3 spawnPos;
    private bool canMove = true;

    public bool xBounded;
    public bool invincible;


    [HideInInspector] public bool inShop = true;

    [SerializeField] private GameObject[] pollen;
    [SerializeField] private SpriteRenderer[] bodySprites;
    public GameObject webStatusImage;
    void Start()
    {
        spawnPos = transform.position;
        pollen = GameObject.FindGameObjectsWithTag("Pollen");
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
            if (horizontalInput != 0)
            {
                foreach (SpriteRenderer sprite in bodySprites)
                {
                    sprite.flipX = (horizontalInput < 0);
                }
            }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Beehive")
        {
            AudioManager.AM.Soundboard(1);
            //SceneManager.LoadScene("Shop");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //transform.position = spawnLocation;
            //Destroy(gameObject);
            //maybe loose nector
            Die();
        }
        if (other.gameObject.CompareTag("Beehive"))
        {
            canMove = false;
            inShop = true;
            invincible = true;
            //this moves the bee to the bee hive and opens the shop when close enough
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(other.transform.position.x, other.transform.position.y, transform.position.z), speed * Time.deltaTime);
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(other.transform.position.x, other.transform.position.y)) < 0.2f)
            {
                foreach (GameObject p in pollen)
                {
                    p.SetActive(true);
                }
                shop.SetActive(true);
            }
        }
    }

    public void Respawn()
    {
        AudioManager.AM.Soundboard(1);
        AudioManager.AM.Soundboard(8);
        shop.SetActive(false);
        canMove = true;
        inShop = false;
        invincible = false;
        transform.position = spawnPos;
        Invoke("LatePollenCheck", 0.8f);
    }

    public void Die()
    {
        AudioManager.AM.Soundboard(3);
        shop.SetActive(false);
        canMove = true;
        inShop = false;
        invincible = false;
        transform.position = spawnPos;
        playerPollen.LosePollen(playerPollen.pollenCount / 2);
    }

    private void LatePollenCheck()
    {
        pollen = GameObject.FindGameObjectsWithTag("Pollen");
    }

    public void ObstacleCollision(int lostPollen)
    {
        StartCoroutine(MoveStun(0.5f));
        StartCoroutine(MercyInvincibility());
        playerPollen.LosePollen(lostPollen);
        
    }

    IEnumerator MoveStun(float stunTime)
    {
        canMove = false;

        yield return new WaitForSeconds(stunTime);

        canMove = true;
    }

    IEnumerator MercyInvincibility()
    {
        invincible = true;
        foreach (SpriteRenderer sprite in bodySprites)
        { 
            sprite.color = new Color(0.7f, 0.7f, 0.7f);
        }

        yield return new WaitForSeconds(3);

        invincible = false;
        foreach (SpriteRenderer sprite in bodySprites)
        {
            sprite.color = new Color(1, 1, 1);
        }
    }

    public void SpiderwebCollision()
    {
        AudioManager.AM.Soundboard(7);
        StartCoroutine(SlowEffect(2, 8));
        ObstacleCollision(4);
    }

    IEnumerator SlowEffect(float slowInt, float duration)
    {
        speed -= slowInt;
        webStatusImage.SetActive(true);

        yield return new WaitForSeconds(duration);

        speed += slowInt;
        webStatusImage.SetActive(false);
    }

}
