using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    
    [SerializeField] private GameObject m_canvas;
    [SerializeField] private List<Texture> m_textureVault;
    
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

    public static GameManager Get()
    {
        return m_instance;
    }
    public GameObject GetCanvas()
    {
        return m_canvas;
    }
    
    
}
