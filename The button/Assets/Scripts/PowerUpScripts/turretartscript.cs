using UnityEngine;

public class turretartscript : MonoBehaviour
{
    public bool nottuching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("tuch");
        if(collision.name == "pot(Clone)")
        {
            nottuching = true;
            Debug.Log("bruh");
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nottuching = false;
        Debug.Log("exit");
    }
}
