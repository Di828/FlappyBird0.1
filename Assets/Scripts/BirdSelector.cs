using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSelector : MonoBehaviour
{    
    int currentBirdNumber = 0;
    GameObject currentBird;
    private void Awake()
    {        
        currentBirdNumber = GameManager.selectedBirdNumber;
        currentBird = Instantiate(GameManager.Instance.birdsList[currentBirdNumber], 
            GameManager.Instance.birdsList[currentBirdNumber].transform.position,
            GameManager.Instance.birdsList[currentBirdNumber].transform.rotation);
    }
    public void LeftArrowClick()
    {
        if (currentBirdNumber > 0)
            currentBirdNumber--;
        else
            currentBirdNumber = GameManager.Instance.birdsList.Count - 1;
        BirdChanged();
    }
    public void RightArrowClick()
    {
        if (currentBirdNumber < GameManager.Instance.birdsList.Count - 1)
            currentBirdNumber++;
        else
            currentBirdNumber = 0;
        BirdChanged();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    private void BirdChanged()
    {
        Destroy(currentBird);
        currentBird = Instantiate(GameManager.Instance.birdsList[currentBirdNumber], 
            GameManager.Instance.birdsList[currentBirdNumber].transform.position,
            GameManager.Instance.birdsList[currentBirdNumber].transform.rotation);
    }
    public void SelectButtonClick()
    {                
        GameManager.selectedBirdNumber = currentBirdNumber;
        GameManager.SavePlayerData();
    }
}
