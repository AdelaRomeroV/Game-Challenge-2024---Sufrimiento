using System.Collections;
using UnityEngine;

public class SpawnDecos : MonoBehaviour
{
    [SerializeField] private GameObject[] decos;
    [SerializeField] public float spawnear;

    private void Awake()
    {
        StartCoroutine(SpawnDeco());
    }
    IEnumerator SpawnDeco()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < decos.Length; i++)
        {
            Instantiate(decos[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnear);
        }
        StartCoroutine(SpawnDeco());
    }
}
