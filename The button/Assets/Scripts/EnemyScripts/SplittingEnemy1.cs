using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class SplittingEnemy1 : MonoBehaviour
{
    public GameObject _splittingPart;  // OBS: GameObject, inte SplittingPart komponent

    private Rigidbody2D enemyRb;
    [SerializeField] float _moveSpeed;
    [SerializeField] int _amountOfClones;
    public List<GameObject> allSplitparts = new List<GameObject>();
    private GameObject bigEnemy;
    [SerializeField] int hp;
    [SerializeField] bool noSpam = false;

    void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        bigEnemy = transform.Find("BigEnemy").gameObject;
    }

    void Update()
    {
        BigEnemyMovement();
        OnDeath();

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                hp -= 1;
            }
        }
    }

    private void BigEnemyMovement()
    {
        enemyRb.linearVelocity = transform.right * _moveSpeed; // �ndrat till velocity ist�llet f�r linearVelocity
    }

    private void OnDeath()
    {
        if (hp == 0)
        {
            Destroy(bigEnemy);
            if (noSpam == false)
            {
                StartCoroutine(AddingSplitParts());
            }
            
        }
    }

    private IEnumerator AddingSplitParts()
    {
        noSpam = true;
        float angleAdder = 0f;

        for (int i = 0; i < _amountOfClones; i++)
        {
            Vector3 _spawnPosition = transform.position;
            Quaternion _spawnRotation = Quaternion.Euler(0, 0, angleAdder);
            GameObject clone = Instantiate(_splittingPart, _spawnPosition, _spawnRotation);
            allSplitparts.Add(clone);
            angleAdder += 90f;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void SetSplittingPart(GameObject partPrefab)
    {
        _splittingPart = partPrefab;
    }
}