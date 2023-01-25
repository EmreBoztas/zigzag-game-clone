using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int _chracterScore = 0;
    [SerializeField] private TMP_Text scoreText;
    
    public void scoreIncrease()
    {
        _chracterScore++;
        scoreText.text = "Score: " + _chracterScore.ToString();
    }
}
