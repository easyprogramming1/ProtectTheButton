using UnityEngine;

public class HammerCursorManager : MonoBehaviour
{
    
    void Awake()
    {
        
    }

    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        
        transform.position = (mousePos+new Vector3(0.38f,-0.5f,0));
    }
}
