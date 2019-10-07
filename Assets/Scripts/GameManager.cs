using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerController player;

    // UI references
    public GameObject ScoreBoard;
    private TextMeshProUGUI lifeText;
    private TextMeshProUGUI goldText;

    public GameObject GameOverBoard;
    private TextMeshProUGUI gameOverText;

    // temporary variables
    private bool terminaterd;

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
        if(terminaterd && Input.GetMouseButton(0))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Debug.Log("Restart Game");
            terminaterd = false;
        }
        
    }
}
