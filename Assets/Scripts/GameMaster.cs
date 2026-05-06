using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMaster : MonoBehaviour
{
    public Boolean GamePlaying;
    public int waveNum;
    [SerializeField] private int waveStart;

    [SerializeField] private float waveDelay;

    [SerializeField] GameObject player;
    [SerializeField] EnemySpawner eSpawner;

    [SerializeField] TextMeshProUGUI startGameText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GamePlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            ToggleGame();
        }
    }

    void ToggleGame()
    {
        // update variables
        GamePlaying = !GamePlaying;
        waveNum = waveStart;

        // update UI
        startGameText.gameObject.SetActive(!GamePlaying);
        Cursor.visible = !GamePlaying;
        
        // start enemy spawn loop, number of enemies is waveNum
        if (GamePlaying)
        {
            eSpawner.StartWave(waveNum);
        }
        else
        {
            eSpawner.StopWave();
        }
    }
}
