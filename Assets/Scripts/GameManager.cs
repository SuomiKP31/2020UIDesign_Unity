using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Story
{
    [SerializeField] private Texture m_texture;
    [SerializeField] private AudioClip m_audioClip;
    [SerializeField] private string m_text;
}

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    
    [SerializeField] private GameObject m_canvas;
    [SerializeField] private List<Story> m_storyList;
    
    public List<List<int>> m_stories; //Basic idea: Storymaking generates a list of integer(sequence of a set of pictures' index), store inside this
    public Dictionary<string, int> m_storyDictionary; // (name, story) map, used to find constructed story sequence.
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } else {
            m_instance = this;
        }
    }

    private void Start()
    {
        m_stories = new List<List<int>>();
    }

    public static GameManager Get()
    {
        return m_instance;
    }
    public GameObject GetCanvas()
    {
        return m_canvas;
    }

    public void AddStorySequence(List<int> seq)
    {
        m_stories.Add(seq);
    }
}
