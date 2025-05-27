using UnityEngine;

public class SplittingEnemy1 : MonoBehaviour
{
    [SerializeField] GameObject _splittingPart;
    private Rigidbody2D enemyRb;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }
}
