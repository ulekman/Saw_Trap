using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour

{
    
    float timeCounter = 0;
    bool isTimerStopped = false;

    public Button takeCoinButton;
   

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinHolderText;

    

    

    int coinHolder;
    int coinAmount = 0;

    public int fastestTime;
    public int middleTime;
    


    // Start is called before the first frame update
    void Start()
    {
        coinHolder = PlayerPrefs.GetInt("coinHolder");
        coinHolderText.text = coinHolder.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimerStopped)
        {
            timeCounter += Time.deltaTime;
        }

        GiveCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            isTimerStopped = true;
            Debug.Log("Timer Stopped. Time: " + timeCounter);
            
        }
    }

    public void GiveCoin()
    {
        if(timeCounter<=  fastestTime)
        {
            coinAmount = 50;
            coinText.text = coinAmount.ToString();
        }

        else if(timeCounter >fastestTime &&  timeCounter <=middleTime)
        {
            coinAmount = 25;
            coinText.text = coinAmount.ToString();
        }
        else
        {
            coinAmount = 10;
            coinText.text = coinAmount.ToString();
        }

        
    }

    public void TakeCoin()
    {
        coinHolder += coinAmount;
        coinHolderText.text = coinHolder.ToString();
        takeCoinButton.interactable = false;
        PlayerPrefs.SetInt("coinHolder", coinHolder);
    }
}
