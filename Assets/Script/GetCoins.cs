using TMPro;
using UnityEngine;

public class GetCoins : MonoBehaviour
{
    [SerializeField] public int coins;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private GameObject panelTextVivo;
    [SerializeField] private TextMeshProUGUI txtFinal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins") || collision.CompareTag("CoinsDoradas"))
        {
            int coin = collision.GetComponent<Coin>().value;
            coins += coin;
            textBox.text = "Puntaje: " + coins;
            Destroy(collision.gameObject);
        }
    }
    private void OnDisable()
    {
        if (panelTextVivo != null) panelTextVivo.SetActive(false);
        txtFinal.text = "Puntaje Final: " + coins;
    }
}
