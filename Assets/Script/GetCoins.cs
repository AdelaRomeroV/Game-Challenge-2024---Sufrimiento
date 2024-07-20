using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCoins : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            int coin = collision.GetComponent<Coin>().value;
            textBox.text = "Puntaje: " + coin;
            Destroy(collision.gameObject);
        }
    }
}
