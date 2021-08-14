using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float timeElapsed;
    private float distance;
    [SerializeField]
    private GameObject timeTextObject;
    [SerializeField]
    private GameObject distanceTextObject;
    private TextMeshProUGUI timeText;
    private TextMeshProUGUI distanceText;
    private float timeCalculation;
    [SerializeField]
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeText = timeTextObject.GetComponent<TextMeshProUGUI>();
        distanceText = distanceTextObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.IsGamePaused)
        {
            timeCalculation += Time.deltaTime;

            if (timeCalculation >= 0.5f)
            {
                TimeElapsed += 0.5f;
                timeCalculation = 0f;
            }

            Distance = TimeElapsed * 10;

            timeText.text = TimeElapsed.ToString() + " s";
            distanceText.text = Distance.ToString() + " m";
        }
    }

    public float TimeElapsed { get => timeElapsed; set => timeElapsed = value; }
    public float Distance { get => distance; set => distance = value; }
}
