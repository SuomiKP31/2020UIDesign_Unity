using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class StoryBook : MonoBehaviour
{
    [SerializeField] private Button m_button;
    [SerializeField] private RawImage m_jacket;
    private List<int> m_storySeq;

    public void Initialize(List<int> input_seq)
    {
        m_storySeq = input_seq;
    }

    public void OnStoryBookClick()
    {
        StoryTelling.Get().StartTellStory(m_storySeq);
    }
}
