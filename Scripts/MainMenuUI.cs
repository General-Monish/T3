using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
  /*  [SerializeField] private GameObject settings;*/
/*    [SerializeField] private GameObject settingsBtn;*/
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject mainMenu;
/*    [SerializeField] private GameObject fadePanel;*/
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource aD;
    [SerializeField] private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
       /* Fadein();*/
        mainMenu.SetActive(true);
      /*  settings.SetActive(false);*/
        howToPlay.SetActive(false);
        credits.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  public void SettingBtnClicked()
    {
        SoundUI();
        mainMenu.SetActive(false);
        settings.SetActive(true);
        settingsBtn.SetActive(false);
        anim.SetTrigger("in");
    }*/
 
    public void CreditsBtnClicked()
    {
        SoundUI();
        mainMenu.SetActive(false);
        credits.SetActive(true);
    } 

   

    public void PlayBtnClicked()
    {
      /*  Fadeout();*/
        SoundUI();
        StartCoroutine(DelayLevel());
      
    }
    public void AIbtn()
    {
        SoundUI();
        StartCoroutine(DelayLevel());
        SceneManager.LoadScene(1);
    }

    IEnumerator DelayLevel()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(0);
    }

    private void SoundUI()
    {
        aD.PlayOneShot(audioClip);
    }

 
}
