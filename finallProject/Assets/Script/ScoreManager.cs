using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI txtScore;

    private int totalScore = 0;
    
    public int distanceMultiplier = 1;

    private Transform player;


    private void Awake(){
        if (instance == null){
            instance = this; 
        }
        else {
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void Update(){
        UpdateScore();
    }
    
    public void UpdateScore(){

        totalScore = Mathf.FloorToInt(player.position.z * distanceMultiplier);
        // Debug.Log("Coin: " + totalCoins);
        txtScore.text = totalScore.ToString();
    }
    
}
