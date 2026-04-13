using UnityEngine;

public class WingAnimation : MonoBehaviour
{

    public float flapRate = 0.5f;
    public GameObject wing1;
    public GameObject wing2;
    private float flapTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flapTime -= Time.fixedDeltaTime;
        if(flapTime < 0)
        {
            wing1.SetActive(!wing1.activeSelf);
            wing2.SetActive(!wing1.activeSelf);
            flapTime = flapRate;
        }
    }
}
