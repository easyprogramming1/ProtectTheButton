using UnityEngine;

public class turretartscript : MonoBehaviour
{
    public bool nottuching;
    public Vector2 potpoint;
    GameObject button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GameObject.Find("The Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "pot(Clone)")
        {
            nottuching = true;
            potpoint = collision.transform.position;
            button.GetComponent<theButtonScript>().theplotes = collision.gameObject;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nottuching = false;
    }
}
