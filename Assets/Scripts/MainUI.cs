using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    MainMenu = 0,
    Account = 1,
    StoryMaking = 2,
    StoryTelling = 3,
}

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_AccountMenu;
    [SerializeField] private GameObject m_StoryMaking;
    [SerializeField] private GameObject m_StoryTelling;

    private UIState m_state;

    private void Start()
    {
        m_state = UIState.MainMenu;
    }

    public void SwitchUIState(int state)
    {
        if ((int)m_state == state)
        {
            return;
        }
        DeactivateAllUI();
        switch (state)
        {
            case 0:
                m_MainMenu.SetActive(true);
                m_state = UIState.MainMenu;
                break;
            case 1:
                m_AccountMenu.SetActive(true);
                m_state = UIState.Account;
                break;
            case 2:
                m_StoryMaking.SetActive(true);
                m_state = UIState.StoryMaking;
                break;
            case 3:
                m_StoryTelling.SetActive(true);
                m_state = UIState.StoryTelling;
                break;
            default:
                m_MainMenu.SetActive(true);
                m_state = UIState.MainMenu;
                break;
        }
    }

    private void DeactivateAllUI()
    {
        m_MainMenu.SetActive(false);
        m_AccountMenu.SetActive(false);
        m_StoryMaking.SetActive(false);
        m_StoryTelling.SetActive(false);
    }
}
