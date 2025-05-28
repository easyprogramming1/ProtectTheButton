using Unity.VisualScripting;
using UnityEngine;

public class HammerCursorManager : MonoBehaviour
{
    private Animator _hammerAnimator;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] public bool _SwitchToHammer = true;
    void Start()
    {
        Cursor.visible = false;
        _hammerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _SwitchToHammer = true;
    }


    void Update()
    {
        ChangeToHammer();
        ChangeToNormal();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _SwitchToHammer = !_SwitchToHammer;
        }
    }

    public void ChangeToHammer()
    {
        if (_SwitchToHammer)
        {
            Cursor.visible = false;

            if (_spriteRenderer != null)
                _spriteRenderer.enabled = true; // Gör synlig

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            transform.position = mousePos + new Vector3(0.3635f, -0.45f, 0);

            if (Input.GetMouseButtonDown(0))
            {
                _hammerAnimator.SetTrigger("Swing");
            }
        }
    }

    public void ChangeToNormal()
    {
        if (!_SwitchToHammer)
        {
            Cursor.visible = true;

            if (_spriteRenderer != null)
                _spriteRenderer.enabled = false; // Gör osynlig
        }
    }

}
