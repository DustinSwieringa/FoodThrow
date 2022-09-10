using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _foodPrefabs;

    public void SpawnFood()
    {
        int randomIndex = Random.Range(0, _foodPrefabs.Length);
        GameObject randomPrefab = _foodPrefabs[randomIndex];
        Instantiate(randomPrefab, transform.position, Random.rotation);
    }
}
