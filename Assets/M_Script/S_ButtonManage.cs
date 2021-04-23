using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_ButtonManage : MonoBehaviour
{
    public GameObject introduction;
    public GameObject credit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void B_BackMenu()
    { 
        SceneManager.LoadScene("MainMenu");
    }

    public void B_Introduction()
    {
        introduction.SetActive(true);
    }

    public void B_CloseIntroduction()
    {
        introduction.SetActive(false);
    }

    public void B_Credit()
    {
        credit.SetActive(true);
    }

    public void B_CloseCredit()
    {
        credit.SetActive(false);
    }

    public void B_QuitGame()
    {
        Application.Quit();
    }
}
