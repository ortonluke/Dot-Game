using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private GameMaster gm;

    [SerializeField] bool resetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.GamePlaying)
        {
            Vector2 mouseScreenPos = Mouse.current.position.ReadValue();

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0f;

            transform.position = mouseWorldPos;
        }
        else
        {
            if (resetPosition) transform.position = new Vector2 (0, 0);
        }
    }
}
