using UnityEngine;

public class CurserManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTextureDefault;

    [SerializeField] private Vector2 clickPosition = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
    }

    void Update()
    {
        
    }
}
