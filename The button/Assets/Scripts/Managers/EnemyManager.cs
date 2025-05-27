using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _spliEnemy;
    [SerializeField] GameObject _spliPart;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 spawnPosition = transform.position;
            SpawnSplittingEnemy(spawnPosition);
        }
    }

    public void SpawnSplittingEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(_spliEnemy, position, Quaternion.identity);

        SplittingEnemy1 script = enemy.GetComponent<SplittingEnemy1>();
        script.SetSplittingPart(_spliPart);
    }
}
