using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryPad : MonoBehaviour
{
    [SerializeField] private int m_next_number = 0; //0-Last story board, 1/2 - one/two stories ahead
    [SerializeField] private int m_story_index = 0; //index of the story's info inside game manager. Needed for sequence storation
    // Cheat here: story pad for chara selection and BG selection have story_index = -1, which will not be stored in story sequence.

    [SerializeField] private List<GameObject> m_nextStoryPadPrefab;

    private GameObject m_container; // The parent of StoryPads. Need to be initialized when created
    private List<int> m_currentSequenceList;

    public void NextPad(int index)
    {
        if (m_next_number != 0)
        {
            //Not the Last one - index need to be 0 or 1, next_number needs to be non-zero
            var next_pad = Instantiate(m_nextStoryPadPrefab[index], m_container.transform, false);
            var pad_script = next_pad.GetComponent<StoryPad>();
            pad_script.Initialize(m_container);
        }

        Destroy(gameObject);
    }

    public void Initialize(GameObject container)
    {
        m_container = container;
        if (m_story_index != -1)
        {
            StoryMaking.Get().AddStory(m_story_index);
        }
    }
}
