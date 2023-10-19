using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeControl : MonoBehaviour
{
    public List<GameObject> balls;
    private int currentIndex = 0;
    public Button nextButton;
    public Button previousButton;

    public Material ballColor;
    


    // Start is called before the first frame update
    void Start()
    {
        UpdateBallColor();
        

        GameObject otherGameObject = GameObject.Find("OtherGameObject"); // Diðer GameObject'i bulun

        if (otherGameObject != null)
        {
            Renderer renderer = otherGameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = ballColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextBall()
    {
        currentIndex = Mathf.Min(currentIndex + 1, 11);
        UpdateBallColor();
        CheckButtons();
    }

    public void PreviousBall()
    {
        currentIndex = Mathf.Max(currentIndex - 1, 0);
        UpdateBallColor();
        CheckButtons();
    }


    private void UpdateBallColor()
    {
        foreach (var ball in balls)
        {
            ball.SetActive(false);
        }

        balls[currentIndex].SetActive(true);
        


    }

    private void CheckButtons()
    {

        nextButton.interactable = currentIndex <= 11;


        previousButton.interactable = currentIndex >= 0;


    }

    public void SetMaterial()
    {
        
       
    }

}