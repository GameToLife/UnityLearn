using UnityEngine;
using System.Collections;


[RequireComponent(typeof(MMT.MobileMovieTexture))]
public class TestMobileTexture : MonoBehaviour 
{
    private  AudioSource music;/**/
    private MMT.MobileMovieTexture m_movieTexture;

    void Awake()
    {
        m_movieTexture = GetComponent<MMT.MobileMovieTexture>();

        m_movieTexture.onFinished += OnFinished;
        music = GetComponent<AudioSource>();/**/
    }

    void OnFinished(MMT.MobileMovieTexture sender)
    {
        Debug.Log(sender.Path + " has finished ");
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0.0f, 0.0f, Screen.width, Screen.height));

        var currentPosition = (float)m_movieTexture.PlayPosition;
		
		var newPosition = GUILayout.HorizontalSlider(currentPosition,0.0f,(float)m_movieTexture.Duration);

        if (newPosition != currentPosition)
        {
			m_movieTexture.PlayPosition = newPosition;
        }
        
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();

		if (GUILayout.Button(m_movieTexture.IsPlaying ? "Pause" : "Play"))
		{
			if(m_movieTexture.IsPlaying)
			{
				m_movieTexture.Pause = true;
                music.Pause();/**/
			}
			else 
			{
				if(!m_movieTexture.Pause)
				{
					m_movieTexture.Play();
                    music.Play();/**/
				}
				else
				{
					m_movieTexture.Pause = false;
                    music.Play();/**/
                    
				}
			}

		}
		
		if (GUILayout.Button("Stop"))
		{
			m_movieTexture.Stop();
            music.Stop();/**/
		}
        

        GUILayout.EndHorizontal();

        GUILayout.EndArea();

     }
}
