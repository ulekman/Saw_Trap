using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizeManager : MonoBehaviour
{
    public Button NextButton;
    public Button PreviousButton;
    public Button buyButton;


    public int currentIndex;
    public GameObject[] balls;

    public BallBlueprint[] ballsToBuy;

    // Start is called before the first frame update
    void Start()
    {

        foreach (BallBlueprint ballToBuy in ballsToBuy)
        {
            if (ballToBuy.price == 0)
            {
                ballToBuy.isUnlocked = true;
            }
            else
            {
                ballToBuy.isUnlocked = PlayerPrefs.GetInt(ballToBuy.name, 12) == 0 ? false : true;
            }




        }

        currentIndex = PlayerPrefs.GetInt("SelectedBall", 0);
        foreach (GameObject ball in balls)
        {
            ball.SetActive(false);

            balls[currentIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        balls[currentIndex].SetActive(false);
        currentIndex++;

        if (currentIndex == balls.Length)
        {
            currentIndex = 0;

        }


        balls[currentIndex].SetActive(true);

        BallBlueprint b = ballsToBuy[currentIndex];
        if (!b.isUnlocked)
        {
            return;
        }


        PlayerPrefs.SetInt("SelectedBall", currentIndex);

    }

    public void ChangePrevious()
    {
        balls[currentIndex].SetActive(false);
        currentIndex--;

        if (currentIndex == -1)
        {
            currentIndex = balls.Length - 1;

        }


        balls[currentIndex].SetActive(true);

        BallBlueprint b = ballsToBuy[currentIndex];
        if (!b.isUnlocked)
        {
            return;
        }


        PlayerPrefs.SetInt("SelectedBall", currentIndex);

    }

    public void UpdateUI()
    {
        BallBlueprint b = ballsToBuy[currentIndex];
        if (b.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);

            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy -" + b.price;

            if (b.price < PlayerPrefs.GetInt("CoinHolder", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }

        }


    }

    public void UnlockBall()
    {
        BallBlueprint b = ballsToBuy[currentIndex];

        PlayerPrefs.SetInt(b.name, 1);
        PlayerPrefs.SetInt("SelectedBall", currentIndex);
        b.isUnlocked = true;
        PlayerPrefs.SetInt("CoinHolder", PlayerPrefs.GetInt("CoinHolder", 0)-b.price);
    }
}
