using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct Story
{
    public Texture m_texture;
    public AudioClip m_audioClip;
    public string m_text;
}

[Serializable]
public struct StorySeq
{
    public List<int> m_sequence;

    public StorySeq(List<int> seq)
    {
        m_sequence = seq;
    }
}
public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    
    [SerializeField] private GameObject m_canvas;
    
    public List<Story> m_storyList;
    
    [SerializeField]
    private List<StorySeq> m_stories; //Basic idea: Storymaking generates a list of integer(sequence of a set of pictures' index), store inside this
    
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
        m_stories = new List<StorySeq>();
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
        m_stories.Add(new StorySeq(seq));
        Debug.Log("Sequence Added");
    }

    public List<StorySeq> GetStoriesList()
    {
        return m_stories;
    }
}
