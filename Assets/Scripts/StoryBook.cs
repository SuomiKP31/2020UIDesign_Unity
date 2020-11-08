using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class StoryBook : MonoBehaviour
{
    [SerializeField] private RawImage m_jacket;
    private List<int> m_storySeq;

    public void Initialize(List<int> input_seq)
    {
        m_storySeq = input_seq;
        m_jacket.texture = GameManager.Get().m_storyList[input_seq[0]].m_texture;
    }

    public void OnStoryBookClick()
    {
        StoryTelling.Get().StartTellStory(m_storySeq);
    }
}
