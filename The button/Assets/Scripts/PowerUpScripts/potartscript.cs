using UnityEngine;

public class potartscript : MonoBehaviour
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
        nottuching = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        nottuching = true;
    }
}
