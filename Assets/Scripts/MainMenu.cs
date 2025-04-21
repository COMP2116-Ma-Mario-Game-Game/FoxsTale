using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;
    public string rankingBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.Find("MarkObject"))
        {
            Destroy(GameObject.Find("MarkObject"));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    public void RankingBoard()
    {
        SceneManager.LoadScene(rankingBoard);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
