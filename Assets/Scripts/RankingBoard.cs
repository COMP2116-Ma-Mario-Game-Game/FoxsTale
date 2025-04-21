using Newtonsoft.Json;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using static UnityEngine.Rendering.DebugUI;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Linq;

public class RankingBoard : MonoBehaviour
{
    public GameObject nameInput;
    public GameObject text;
    public GameObject inputName;
    public GameObject tryAgain;
    public GameObject rankingBoard;
    public GameObject loading;
    public Transform emtryContainer;
    public Transform emtryTemplate;
    public string mainScene;
    public string ServerDomain;

    private new string name;

    public class RankingBoardData
    {
        public string namechar { get; set; }
        public int mark { get; set; }
        public override string ToString()
        {
            return "Name: " + namechar + ":" + mark;
        }
    }
    void Start()
    {
        tryAgain.SetActive(false);
        rankingBoard.SetActive(false);
        if (GameObject.Find("MarkObject"))
        {
            loading.SetActive(false);
            inputName.SetActive(true);
        }
        else
        {
            loading.SetActive(true);
            inputName.SetActive(false);
            StartCoroutine(GetRequest("https://" + ServerDomain + "/"));
        }
    }
    public void ReStartGame()
    {
        SceneManager.LoadScene(mainScene);
    }
    public void GetRankingBoard()
    {
        name = nameInput.GetComponent<InputField>().text;
        if (String.IsNullOrWhiteSpace(name))
        {
            text.GetComponent<Text>().text = "The name can't empty.";
        }
        else if (name.Length > 15)
        {
            text.GetComponent<Text>().text = "The name can't exceed 15 characters.";
        }
        else if (!name.ToCharArray().All(c => c <= sbyte.MaxValue && (Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))))
        {
            text.GetComponent<Text>().text = "The name can only input English and numeric character.";
        }
        else if (GameObject.Find("MarkObject"))
        {
            StartCoroutine(GetRequest("https://" + ServerDomain + "/?name=" + name + "&mark=" + GameObject.Find("MarkObject").GetComponent<Mark>().mark.ToString()));
        }
        else
        {
            text.GetComponent<Text>().text = "Error!!!";
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
                inputName.SetActive(false);
                tryAgain.SetActive(true);
                loading.SetActive(false);
                rankingBoard.SetActive(false);
            }
            else
            {
                Debug.Log(webRequest.downloadHandler.text);
                Destroy(GameObject.Find("MarkObject"));
                inputName.SetActive(false);
                tryAgain.SetActive(false);
                loading.SetActive(false);
                rankingBoard.SetActive(true);
                var rankingBoardData = JsonConvert.DeserializeObject<List<RankingBoardData>>(webRequest.downloadHandler.text);
                foreach (RankingBoardData i in rankingBoardData)
                {
                    Debug.Log(i.ToString());
                }
                Debug.Log(rankingBoardData.Count.ToString());
                emtryTemplate.gameObject.SetActive(false);
                float templateHeight = 100f;
                for (int i = 0; i < rankingBoardData.Count; i++)
                {
                    Transform emtryTransform = Instantiate(emtryTemplate, emtryContainer);
                    RectTransform emtryRectTransform = emtryTransform.GetComponent<RectTransform>();
                    emtryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
                    emtryTransform.gameObject.SetActive(true);

                    emtryTransform.Find("Name").GetComponent<Text>().text = rankingBoardData[i].namechar;
                    emtryTransform.Find("Mark").GetComponent<Text>().text = rankingBoardData[i].mark.ToString();

                }

            }
        }
    }
}
