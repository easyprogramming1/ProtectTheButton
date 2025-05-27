using UnityEngine;

public class potScript : MonoBehaviour
{
    public Transform button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GameObject.Find("The Button").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.name == "pot(Clone)")
        {
            button.BroadcastMessage("IEXIST");
        }
    }
}
