using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objects0;
    [SerializeField] private GameObject[] objects1;
    [SerializeField] private GameObject[] objects2;
    [SerializeField] private GameObject[] objects3;
    [SerializeField] private GameObject[] objects4;
    [SerializeField] private GameObject[] objects5;
    [SerializeField] private GameObject[] objects6;
    [SerializeField] private GameObject[] objects7;
    [SerializeField] private GameObject[] objects8;

    [SerializeField] public bool finish = false;

    [SerializeField] public CapitanSparrow capitanSparrow;
    [SerializeField] public float spawnear;
    private void Awake()
    {
        StartCoroutine(PirateSparrow());
    }

    public void StartCorutineSpawn()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator PirateSparrow()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < objects0.Length; i++)
        {
            Instantiate(objects0[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
        finish = true;
    }
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(1.5f);
        switch (capitanSparrow.valueInstate)
        {
            case 0:
                for (int i = 0; i < objects0.Length; i++)
                {
                    Instantiate(objects0[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 1:
                for (int i = 0; i < objects1.Length; i++)
                {
                    Instantiate(objects1[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 2:
                for (int i = 0; i < objects2.Length; i++)
                {
                    Instantiate(objects2[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 3:
                for (int i = 0; i < objects3.Length; i++)
                {
                    Instantiate(objects3[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 4:
                for (int i = 0; i < objects4.Length; i++)
                {
                    Instantiate(objects4[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 5:
                for (int i = 0; i < objects5.Length; i++)
                {
                    Instantiate(objects5[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 6:
                for (int i = 0; i < objects6.Length; i++)
                {
                    Instantiate(objects6[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 7:
                for (int i = 0; i < objects7.Length; i++)
                {
                    Instantiate(objects7[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
            case 8:
                for (int i = 0; i < objects8.Length; i++)
                {
                    Instantiate(objects8[i], transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnear);
                }
                break;
        }
        finish = true;
    }
}
