/*---------The Platformers-------
 * Contributors: Dillion
 * Prupose: Timer class to update the timer on the UI
 * GameObjects associated: Timer Text UI 
 * Files Associated: 
 * Source:
 *--------------------------------*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public TMP_Text timerTextTMP;
    private float startTime;
    public float min;
    public float sec;
    private float displayedMinute;
    private bool flipMin = true;
    public bool timerActive = true;
    public float currentSecond;
    private CoinPickup score;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        displayedMinute = min;
        score = GetComponent<CoinPickup>();

    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;
   
        currentSecond = (int)sec - (t % 60); 
        float displayedSecond = currentSecond;
            
        if (timerActive == true)
        {  

            if (currentSecond < 0)
            {
                displayedSecond = 59 + currentSecond;

                if (flipMin == true)
                {
                    displayedMinute = displayedMinute - 1;
                    flipMin = false;
                }  
            } 

            if (currentSecond >= 0)
            {
                flipMin = true;
            }
            
            string minutes = displayedMinute.ToString("00");
            string seconds = displayedSecond.ToString("00");

            timerText.text = minutes + ":" + seconds;
            timerTextTMP.text = minutes + ":" + seconds;

            if ((minutes == "00") && (seconds == "00"))
            {
                SceneManager.LoadScene("GameOver");
        
            }
        }
        
        if (Input.GetKeyDown("l"))
        {
            Invoke("timeScore", 0);
        }

        
    }

    void timeScore()
    {
        if (timerActive)
        {
            timerActive = false;

            float total = displayedMinute * 60;

            total += currentSecond;

            total /= 10;

            total *= 1000;
    
            Debug.Log("The timescore is: " + total); 
            ScoreData.UpdateScore(total);
            score.RefreshScoreText();
            
        }
        else
        {
            timerActive = true;
        }
    }



}
