using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;

    public int gemsCollected;

    public string levelToLoad;

    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCountdown());
    }

    private IEnumerator RespawnCountdown()
    {
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(8);
        yield return new WaitForSeconds(waitToRespawn - (1 / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1 / UIController.instance.fadeSpeed) * 0.2f);
        UIController.instance.FadeFromBlack();
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        LevelUI.instance.StopTimeing();
        StartCoroutine(EndLevelCountdown());

    }
    public IEnumerator EndLevelCountdown()
    {
        PlayerController.instance.stopInput = true;

        CameraController.instance.stopFollow = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) * 0.25f);

        SceneManager.LoadScene(levelToLoad);
    }

}
