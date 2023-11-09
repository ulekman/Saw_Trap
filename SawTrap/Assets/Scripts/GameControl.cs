using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{

    public GameObject ball;
    public TextMeshProUGUI levelCompleteText;
    public TextMeshProUGUI levelFailedText;
    public GameObject nextLevelMenuUI;
    public GameObject failedMenuUI;
    public Button pauseButton;
   
    ParticleSystem pop;
    public float disableDelay = 2f;

    

   
   
    

   

    

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText.enabled = false;
        levelFailedText.enabled = false;

        pop = GetComponent<ParticleSystem>();
        pop.Stop();

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {

            levelCompleteText.enabled = true;
            StartCoroutine(DisableTextAfterDelay());
            
            
        }
    }

    private IEnumerator DisableTextAfterDelay()
    {
        yield return new WaitForSeconds(disableDelay);
        levelCompleteText.enabled = false;
        levelFailedText.enabled = false;
        nextLevelMenuUI.SetActive(true);
        pauseButton.interactable = false;

        
        

        Time.timeScale = 0f;
    }

    private IEnumerator DisableTextAfterDelay2()
    {
        yield return new WaitForSeconds(disableDelay);
        levelCompleteText.enabled = false;
        levelFailedText.enabled = false;
        failedMenuUI.SetActive(true);
        pauseButton.interactable = false;




        Time.timeScale = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SawTooth"))
        {
            pop.Play();

            levelFailedText.enabled = true;
            
            StartCoroutine(DisableTextAfterDelay2());

            ball.GetComponent<MeshRenderer>().enabled = false;

        } 
    }


}

