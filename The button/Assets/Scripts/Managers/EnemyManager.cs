using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _spliEnemy;
    [SerializeField] GameObject _spliPart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(SpawnEnemiesWithDelay());
        }
    }

    private IEnumerator SpawnEnemiesWithDelay()
    {
        float[] spawnXPositions = new float[] { 8f, -8f, 8f, -8f };

        foreach (float xPos in spawnXPositions)
        {
            float randomY = Random.Range(-3f, 3f); // Random Y mellan -3 och 3
            Vector3 spawnPos = new Vector3(xPos, randomY, 0f);

            SpawnSplittingEnemy(spawnPos);
            yield return new WaitForSeconds(5f);
        }

    }

    public void SpawnSplittingEnemy(Vector3 position)
    {
        Quaternion rotation = Quaternion.identity;

        if (position.x > 0)
        {
            rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        GameObject enemy = Instantiate(_spliEnemy, position, rotation);

        SplittingEnemy1 script = enemy.GetComponent<SplittingEnemy1>();
        script.SetSplittingPart(_spliPart); // Skicka prefab-referensen hit!
    }
}
