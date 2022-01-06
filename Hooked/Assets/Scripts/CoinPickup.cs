/*---------The Platformers-------
 * Contributors: Mario Mendoza, John Paduh
 * Prupose: Handle the collections of coins and increase score on the UI
 * GameObjects associated: Canvas, Coins, ScoreText
 * Files Associated: AttackDetails
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPickup : MonoBehaviour
{
    private int Coins = 0;
    [SerializeField] private Text CoinText;
    [SerializeField] private TMP_Text Score;

    private void Start()
    {
        Score.text = ScoreData.score.ToString();
        //Coins = (int)ScoreData.score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {

            Destroy(other.gameObject);
            Coins++;
            CoinText.text = "Coins: " + Coins;
            ScoreData.UpdateScore(1);
            RefreshScoreText();
        }
    }
    
    public  void RefreshScoreText()
    {
        Score.text = ScoreData.score.ToString();
    }
}