using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplittingEnemy1 : MonoBehaviour
{
    [SerializeField] GameObject _splittingPart;
    private Rigidbody2D enemyRb;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _angleAdder;
    [SerializeField] int _amountOfClones;
    public List<GameObject> allSplitparts = new List<GameObject>();
    private GameObject bigEnemy;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        bigEnemy = transform.Find("BigEnemy").gameObject;
    }

    
    void Update()
    {
        BigEnemyMovement();
        OnDeath();
    }

    private void BigEnemyMovement()
    {
        Vector2 _Direction = transform.right;
        enemyRb.linearVelocity = transform.right;
        
    }

    private void OnDeath()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(bigEnemy);
            StartCoroutine(AddingSplitParts());
        }
    }

    private IEnumerator AddingSplitParts()
    {
        float angleAdder = 0f;

        for (int i = 0; i < _amountOfClones; i++)
        {
            Vector3 _spawnPosition = transform.position;
            Quaternion _spawnRotation = Quaternion.Euler(0, 0, angleAdder);
            Instantiate(_splittingPart, _spawnPosition, _spawnRotation);
            angleAdder += 90f;
            yield return new WaitForSeconds(0f);
        }
        angleAdder = 0f;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
