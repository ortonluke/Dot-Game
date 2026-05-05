using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMaster : MonoBehaviour
{
    public Boolean GamePlaying;

    [SerializeField] GameObject player;

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
        GamePlaying = !GamePlaying;
        Cursor.visible = !GamePlaying;

        startGameText.gameObject.SetActive(!GamePlaying);
    }
}
