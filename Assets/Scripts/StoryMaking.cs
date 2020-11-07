using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

[System.Serializable]
public struct CharacterPair
{
    [SerializeField]
    private string name1,name2;
    [SerializeField]
    private Texture tex1, tex2;
}

public class StoryMaking : MonoBehaviour
{
    static StoryMaking m_instance;

    [SerializeField] private GameObject m_firstStoryPadPrefab;
    [SerializeField] private GameObject m_container;

    private List<int> m_currentStorySeq;
    private GameObject m_currentStoryPad;
    
    

    private void OnEnable()
    {
        // All selections are faked for now, e.g. Chara/BG selection is fake, they are nothing but story boards.
        m_currentStoryPad = Instantiate(m_firstStoryPadPrefab, m_container.transform, false);
        var pad_script = m_currentStoryPad.GetComponent<StoryPad>();
        pad_script.Initialize(m_container);
    }
    
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } else {
            m_instance = this;
        }
    }

    public static StoryMaking Get()
    {
        return m_instance;
    }

    public void AddStory(int index)
    {
        m_currentStorySeq.Add(index);
    }
}
