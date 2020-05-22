using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Set in inspector
    public GameObject completeLevelUI;
    public GameObject deathUI;
    public GameObject[] enemies;

    private GameObject player;

    // public CameraManager cameraManager;

    static GameManager _instance;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance {
        get => _instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    public void ColorTint (ColorType colorType) {
        foreach (GameObject enemy in enemies) {
            enemy.GetComponentInChildren<Skeleton>().ColorTint(colorType);
        }
    }

    public void GameOver()
    {
        StartCoroutine("ShowDeathUI");
        //TODO: Make character look forward, perform death animation
    }

    public void Win()
    {
        completeLevelUI.SetActive(true);
        StartCoroutine("LoadMenu");
    }


    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(7.0f);
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator ShowDeathUI()
    {
        yield return new WaitForSeconds(7.6f);
        deathUI.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        deathUI.GetComponentInChildren<Image>().color = Color.black;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainMenu");
    }
}
