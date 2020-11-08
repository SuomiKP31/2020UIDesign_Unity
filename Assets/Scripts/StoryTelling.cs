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
        m_StoryGalleryContainer.SetActive(true);
        // Purge old story entry
        foreach (Transform child in m_StoryGalleryContainer.transform)
        {
            Destroy(child.gameObject);
        }
        // Initialize all story books
        var gm = GameManager.Get().GetStoriesList();
        foreach (StorySeq seq in gm)
        {
            var sbook = Instantiate(m_StoryBookPrefab, m_StoryGalleryContainer.transform, false);
            var sbook_script = sbook.GetComponent<StoryBook>();
            sbook_script.Initialize(seq.m_sequence);
        }
    }

    public static StoryTelling Get()
    {
        return m_instance;
    }

    public void StartTellStory(List<int> StorySeq)
    {
        m_StoryGalleryContainer.SetActive(false);
        var st = StoryTeller.Get();
        st.LoadStorySeq(StorySeq);
        st.StartTellStory();
    }
}
