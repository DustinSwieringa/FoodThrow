using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private Food[] _foodPrefabs;

    [SerializeField]
    private GameController _gameController;

    public void SpawnFood()
    {
        int randomIndex = Random.Range(0, _foodPrefabs.Length);
        Food randomPrefab = _foodPrefabs[randomIndex];
        Food foodCopy = Instantiate(randomPrefab, transform.position, Random.rotation);
        foodCopy.Initialize(_gameController);
    }
}
