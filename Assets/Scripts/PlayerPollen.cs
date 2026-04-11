using UnityEngine;

public class PlayerPollen : MonoBehaviour
{

    public GameObject Pollen1;
    public GameObject Pollen2;
    public GameObject Pollen3;
    public GameObject Pollen4;
    
    public int PollenCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdatePollenRender();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdatePollenRender()
    {
        if(PollenCount > 0)
        {
            Pollen1.SetActive(true);
        }
        else
        {
            Pollen1.SetActive(false);
        }
        if (PollenCount > 1)
        {
            Pollen2.SetActive(true);
        }
        else
        {
            Pollen2.SetActive(false);
        }
        if (PollenCount > 2)
        {
            Pollen3.SetActive(true);
        }
        else
        {
            Pollen3.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("bee trigger something!");
        if (other.CompareTag("Pollen"))
        {
            Destroy(other.gameObject);
            PollenCount += 1;
            UpdatePollenRender();
        }
    }
}
