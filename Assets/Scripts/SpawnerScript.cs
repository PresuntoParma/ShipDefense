using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] balls;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float valueY;
    [SerializeField] private float spawnTime;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Instantiate(balls[Random.Range(0,2)], new Vector2(Random.Range(minX, maxX), valueY), Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(Spawn());
    }
}
