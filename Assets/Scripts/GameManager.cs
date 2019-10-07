using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController player;
    private AudioListener main;

    // UI references
    public GameObject ScoreBoard;
    private TextMeshProUGUI lifeText;
    private TextMeshProUGUI goldText;

    public GameObject GameOverBoard;
    private TextMeshProUGUI gameOverText;

    // temporary variables
    private bool terminaterd;
    private bool canRestart;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        lifeText = GameObject.Find("Life").GetComponent<TextMeshProUGUI>();
        goldText = GameObject.Find("Gold").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "Life:" + player.life;
        goldText.text = "Gold:" + player.goldNum;
        if (player.life <= 0)
        {
            GameOverBoard.SetActive(true);
            gameOverText = GameObject.Find("GameOverText").GetComponent<TextMeshProUGUI>();
            gameOverText.text = "YOU DIED WITH " + player.goldNum + " G";
            terminaterd = true;
        }
        if (terminaterd && Input.GetMouseButton(0) && canRestart)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("Restart Game");
            terminaterd = false;
        }

    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(3);
        canRestart = true; 
    }
}
