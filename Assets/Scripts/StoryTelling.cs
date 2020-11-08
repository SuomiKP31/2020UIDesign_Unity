using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StoryTelling : MonoBehaviour
{
    static StoryTelling m_instance;
    [SerializeField] private GameObject m_StoryGalleryContainer;
    [SerializeField] private GameObject m_StoryBookPrefab;

    [SerializeField] private GameObject m_StoryTeller;
    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        } else {
            m_instance = this;
        }
    }

    private void OnEnable()
    {
        // Purge old story entry
        foreach (Transform child in m_StoryGalleryContainer.transform)
        {
            Destroy(child.gameObject);
        }
        // Initialize all story books
        foreach (List<int> seq in GameManager.Get().m_stories)
        {
            var sbook = Instantiate(m_StoryBookPrefab, m_StoryGalleryContainer.transform, false);
            var sbook_script = sbook.GetComponent<StoryBook>();
            sbook_script.Initialize(seq);
        }
    }

    public static StoryTelling Get()
    {
        return m_instance;
    }

    public void StartTellStory(List<int> StorySeq)
    {
        var st = StoryTeller.Get();
        st.LoadStorySeq(StorySeq);
        st.StartTellStory();
    }
}
