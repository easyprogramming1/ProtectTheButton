using UnityEngine;

public class SpinningEnemyScript : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] GameObject _button;
    [Header("Floats")]
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _sightOffset;
    [SerializeField] float _angleAdjuster;
    [Header("Angles")]
    [SerializeField] float _rotationAngle;
    [SerializeField] float _targetAngle;
    [SerializeField] float angelDifference;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

    }
}
