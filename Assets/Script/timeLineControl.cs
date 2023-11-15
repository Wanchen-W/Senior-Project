using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector timeline;
    public timeLineScriptable played;
    private bool timelinePlayed;
    public GameObject healthCanvas;
    void Start()
    {
        timelinePlayed = played.hasPlayed;
        if (!timelinePlayed)
        {
            PlayTimeline();
        }
        else
        {
            timeline.Stop();
        }
    }
    void Update()
    {
        if (timeline.state != PlayState.Playing)
        {
            healthCanvas.SetActive(true);
        }
    }

    void PlayTimeline()
    {
        timeline.Play();
        played.hasPlayed = true;
    }
}
