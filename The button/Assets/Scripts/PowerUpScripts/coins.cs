using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class coins : MonoBehaviour
{
    public TextMeshProUGUI coinss;
    public Transform button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinss.text = "Amount of coins: " + button.GetComponent<theButtonScript>().coins.ToString();
    }
}
