using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpinningEnemyScript : MonoBehaviour
{
    private Rigidbody2D _enemyRb;
    [SerializeField] GameObject _button;
    private bool _isIncreasing = false;
    [Header("Floats")]
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _sightOffset;
    [SerializeField] float _angleAdjuster;
    [Header("Angles")]
    [SerializeField] float _rotationAngle;
    [SerializeField] float _targetAngle;
    [SerializeField] float _angelDifference;
    [SerializeField] float _addDegree;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _button = GameObject.FindWithTag("Button");
    }


    void Update()
    {
        CalculateAngles();
        FindDirection();
        if (!_isIncreasing)
        {
            StartCoroutine(AddDegrees());
        }
    }

    private void FindDirection()
    {
        Vector2 _TargetDireciton = new Vector2(_button.transform.position.x - transform.position.x, _button.transform.position.y - transform.position.y);
        Vector2 _Direction = transform.up;
        _angelDifference = Mathf.DeltaAngle(_rotationAngle, _targetAngle);
       if(_angelDifference < 0)
            {
                transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime * -1);
            }
            else
            {
                transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
            }
        
        _enemyRb.linearVelocity = _Direction * _moveSpeed;
        
    }

    private void CalculateAngles()
    {
        _rotationAngle = transform.eulerAngles.z + 155f;
        Vector2 _Direction = (_button.transform.position - transform.position);
        _targetAngle = Mathf.Atan2(_Direction.y,_Direction.x) * Mathf.Rad2Deg;
    }
    private IEnumerator AddDegrees()
    {
        if(_rotationSpeed < 1080f)
        {
            _isIncreasing = true;
            yield return new WaitForSeconds(0.25f);
            _rotationSpeed += 3.75f;
            if(_moveSpeed <= 11)
            {
                _moveSpeed += 0.5f;
            }

            _isIncreasing = false;

        }
        
    }
}
