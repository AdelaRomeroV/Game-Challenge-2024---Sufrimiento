using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetCoins : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private TextMeshProUGUI textBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            int coin = collision.GetComponent<Coin>().value;
            coins += coin;
            textBox.text = "Puntaje: " + coins;
            Destroy(collision.gameObject);
        }
    }
}
