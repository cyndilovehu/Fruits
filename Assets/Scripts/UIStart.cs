using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIStart : MonoBehaviour {
    private Button btn;
    private Button sound;
    private AudioSource bgsound;
    private Image image;
    public Sprite[] sprite;
	// Use this for initialization
	void Start () {
        GetComponents();
        btn.onClick.AddListener(onplayclick);
        sound.onClick.AddListener(onsoundclick);
    }
    private void GetComponents()
    {
        btn = transform.Find("start").GetComponent<Button>();
        sound = transform.Find("sound").GetComponent<Button>();
        bgsound = sound.GetComponent<AudioSource>();
        image = sound.GetComponent<Image>();
    }
    void onplayclick()
    {
        SceneManager.LoadScene("play", LoadSceneMode.Single);
    }
    void onsoundclick()
    {
        if(bgsound.isPlaying)
        {
            bgsound.Pause();
            image.sprite = sprite[1];
        }
        else
        {

            bgsound.Play();
            image.sprite = sprite[0];
        }
    }
    void OnDestroy()
    {

        btn.onClick.RemoveListener(onplayclick);
        sound.onClick.RemoveListener(onsoundclick);
    }
}
