using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SplittingPart : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] float _moveSpeed;
    
    void Awake()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector2 _Direction = (transform.up + transform.right).normalized;
        _enemyRb.linearVelocity = _Direction * _moveSpeed;
    }
}
