using Unity.VisualScripting;
using UnityEngine;

public class HammerCursorManager : MonoBehaviour
{
    private Animator _hammerAnimator;
    void Start()
    {
        
        _hammerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        
        transform.position = (mousePos+new Vector3(0.3635f,-0.45f,0));

        if (Input.GetMouseButtonDown(0))
        {
            _hammerAnimator.SetTrigger("Swing");
        }

        
    }
}
