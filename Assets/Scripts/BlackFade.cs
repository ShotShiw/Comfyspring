using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{

    public GameObject shop;
    public float fadeTime = 2f;
    private Image myimage;
    [SerializeField] private Color cclear;
    [SerializeField] private Color cdarken;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myimage = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shop.activeSelf)
        {
            myimage.color = Color.Lerp(myimage.color, cdarken, fadeTime * Time.fixedDeltaTime);
        }
        else
        {
            myimage.color = Color.Lerp(myimage.color, cclear, fadeTime * Time.fixedDeltaTime);
        }
    }
}
