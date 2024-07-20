using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private void Awake()
    {
        StartCoroutine(CapitanSparrow());
    }
    IEnumerator CapitanSparrow()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < objects.Length; i++)
        {
            Instantiate(objects[i], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
