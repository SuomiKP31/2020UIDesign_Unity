using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryTeller : MonoBehaviour
{
    private static StoryTeller m_instance;

    [SerializeField] private AudioSource m_audioSource;
    [SerializeField] private RawImage m_storyBoardImage;
    [SerializeField] private TMP_Text m_text;
    [SerializeField] private Texture m_FinishTexture;

    private List<int> m_storySeq;
    private AudioClip m_currentAudioClip;
    private int m_currentSeqPosition;
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
        m_storySeq = new List<int>();
        m_currentSeqPosition = 0;
    }

    private void OnEnable()
    {
        m_storyBoardImage.gameObject.SetActive(false);
    }

    public static StoryTeller Get()
    {
        return m_instance;
    }
    public void LoadStorySeq(List<int> StorySeq)
    {
        m_storySeq = StorySeq;
    }

    public void StartTellStory()
    {
        m_currentSeqPosition = 0;
        m_storyBoardImage.gameObject.SetActive(true);
        PlayStory(0);
    }

    private void PlayStory(int StoryIndex)
    {
        if (StoryIndex >= m_storySeq.Count)
        {
            FinishStory();
            return;
        }
        // StoryIndex is the index of the story inside the GameManager
        var story = GameManager.Get().m_storyList[m_storySeq[StoryIndex]];
        m_currentAudioClip = story.m_audioClip;
        m_storyBoardImage.texture = story.m_texture;
        m_text.text = story.m_text;
        m_audioSource.PlayOneShot(m_currentAudioClip);
        StartCoroutine(WaitForSound());
    }

    private void FinishStory()
    {
        m_storyBoardImage.texture = m_FinishTexture;
        m_text.text = "The Story Ends";
        StopCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        yield return new WaitUntil(() => m_audioSource.isPlaying == false);
        PlayStory(++m_currentSeqPosition);
    }
}
