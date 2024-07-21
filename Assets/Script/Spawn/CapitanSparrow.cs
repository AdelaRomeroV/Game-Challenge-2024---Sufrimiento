
using UnityEngine;

public class CapitanSparrow : MonoBehaviour
{
    [SerializeField] public int valueInstate;
    [SerializeField] private Spawn left;
    [SerializeField] private Spawn mid;
    [SerializeField] private Spawn right;

    private void Update()
    {
        if (left.finish == true && mid.finish == true && right.finish == true)
        {
            RandomInstate();
            StartCorutineSpawns();
        }
    }

    private void StartCorutineSpawns()
    {
        left.finish = false;
        mid.finish = false;
        right.finish = false;
        left.StartCorutineSpawn();
        mid.StartCorutineSpawn();
        right.StartCorutineSpawn();
    }

    public void RandomInstate()
    {
        valueInstate = Random.Range(0, 6);
    }
}
