using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] float _moveSpeed;
    
    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Vector2 _Direction = (transform.up + transform.right).normalized;
        _enemyRb.linearVelocity = _Direction * _moveSpeed;
    }
}
