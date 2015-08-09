using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleBackground : MonoBehaviour
{
	public float fadeTime = 10.0f;

	public Image backgroundImage;
	public RawImage backgroundMovieImage;
	public GameObject titlePanel;
	public MusicManager musicManager;
	MovieTexture backgroundMovie;
	float movieStartTime;
	float movieEndTime;

	void Awake ()
	{
		backgroundMovie = (MovieTexture)backgroundMovieImage.mainTexture;
	}

	// Use this for initialization
	void Start ()
	{
		movieStartTime = Time.time;
		movieEndTime = movieStartTime + backgroundMovie.duration - fadeTime;
		backgroundMovie.Play ();
		musicManager.PlayTitleClip ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (backgroundMovie.isPlaying) {
			float alpha = Time.deltaTime / (fadeTime / 2f);

			if (Input.GetButtonDown ("Cancel") || Time.time >= (movieEndTime + fadeTime)) {
				backgroundMovie.Stop ();
				backgroundMovieImage.enabled = false;
				titlePanel.SetActive (true);
			} else if (Time.time >= (movieEndTime + (fadeTime / 2f))) {
				backgroundImage.color = new Color (backgroundImage.color.r, 
				                                  backgroundImage.color.g, 
				                                  backgroundImage.color.b, 
				                                  backgroundImage.color.a + alpha);

			} else if (Time.time >= movieEndTime) {
				backgroundMovieImage.color = new Color (backgroundMovieImage.color.r, 
				                                       backgroundMovieImage.color.g, 
				                                       backgroundMovieImage.color.b, 
				                                       backgroundMovieImage.color.a - alpha);
			}
		}
	}
}
