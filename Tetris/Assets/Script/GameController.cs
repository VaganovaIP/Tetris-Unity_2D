using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class GameController : MonoBehaviour
{

    public Text text;
    public static int scorecopy;
    public Text levelText;
    public int level; 
    [SerializeField] private float time;
    [SerializeField] private Text timerText;
 
    private float _timeLeft = 0f;
    private bool _timerOn = false;
 

    void Start()
    {
        text.text = "0";
        scorecopy = 0;
        _timeLeft = time;
        _timerOn = true;
        level = 0;
    }


    public void AddScore()
    {
        scorecopy += 10;
    }


    void Update()
    {

         text.text = scorecopy.ToString();

        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                level++;
                levelText.text = level.ToString();
            }
        }
        else { 
             _timeLeft = 60;
            _timerOn = true;
        }
       
        
    }

    void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }


}
