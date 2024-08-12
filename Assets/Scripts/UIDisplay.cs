using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider slider;
    [SerializeField] Health playerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI myText;
    ScoreKeeper scoreKeeper;
    
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        slider.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = playerHealth.GetHealth();
        myText.text = scoreKeeper.GetCurrentScore().ToString("000000000");
    }
    

}
