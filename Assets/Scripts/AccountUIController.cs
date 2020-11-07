using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class AccountUIController : MonoBehaviour
{
    private const double REFRESH_MAX_TIMER = 2.5;

    private float current_timer = 0;

    private int m_heartBeat = 50;

    private double m_bodyTemp = 37.0;

    private float m_closeInteractionTime = 0;

    private float m_excitedTime = 0;

    [SerializeField] private TMP_Text m_heartText;

    [SerializeField] private TMP_Text m_tempText;

    [SerializeField] private TMP_Text m_StatText;
    [SerializeField] private TMP_Text m_interactionTimer, m_excitedTimer;
    
    Random rng = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        current_timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        current_timer += Time.deltaTime;
        RefreshStats(current_timer);
    }

    private void OnEnable()
    {
        m_closeInteractionTime += (float)rng.NextDouble() * 2;
        m_excitedTime += (float)rng.NextDouble() * 2;
        m_interactionTimer.text = m_closeInteractionTime.ToString("0.##");
        m_excitedTimer.text = m_excitedTime.ToString("0.##");
    }

    void RefreshStats(float time)
    {
        if (time >= REFRESH_MAX_TIMER)
        {
            current_timer = 0;
            
            m_heartBeat = rng.Next(39,101);
            m_heartText.text = m_heartBeat.ToString();
            m_tempText.text = m_bodyTemp.ToString("0.##");
            m_bodyTemp = rng.Next(34,38)+rng.NextDouble();
            if (m_heartBeat > 70)
            {
                m_StatText.text = "Excited";
            }
            else if (m_heartBeat < 50)
            {
                m_StatText.text = "Sleeping";
            }
            else
            {
                m_StatText.text = "Normal";
            }
        }
    }
    
}
