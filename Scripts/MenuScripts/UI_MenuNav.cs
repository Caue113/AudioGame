using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_MenuNav : MonoBehaviour
{   
    [SerializeField]
    Canvas[] CanvasList;

    [SerializeField]
    Button[] MenuButtonList, CofiguracoesButtonList;

    [SerializeField]
    Slider[] AlterarVolumeList;
    
    Canvas Menu, Configuracoes, AlterarVolume;

    Button btnContinuar, btnConfiguracoes, btnSairDoJogo,
            btnAlterarVolume, btnSairMenu;

    Slider sldVolume;

    [SerializeField]
    public AudioClip[] menuAudioClip, gameAudioClip;
    public AudioSource audioSource;

    public static float GameVolume = 0.8f;
    bool isFocusOnMenu = false;

    bool activeCamera = true;


    /*
     * YET TO IMPLEMENT!!
     * 
    enum MenuAudioClips 
    {
        AlterarVolume,
        ContinuarAoJogo,
        IrParaConfiguracoes,
        MexaSetinhaBaixo,
        MexaSetinhaCima,
        PressioneEsc,
        SairDoJogo,
        VoceEstaEmAlterarVolume,
        VoceEstaEmConfiguracoes,
        VoceEstaEmMenu,
        VoltarParaMenu
    }
    */

    protected virtual void Start()
    {
        //Define menu-canvases
        Menu = CanvasList[0];
        Configuracoes = CanvasList[1];
        AlterarVolume = CanvasList[2];

        //Define Menu-Buttons
        btnContinuar = MenuButtonList[0];
        btnConfiguracoes = MenuButtonList[1];
        btnSairDoJogo = MenuButtonList[2];

        //Define Configuration-Buttons
        btnAlterarVolume = CofiguracoesButtonList[0];
        btnSairMenu = CofiguracoesButtonList[1];

        //Define AlterarVolume - Sliders
        sldVolume = AlterarVolumeList[0];

        UnloadAllCanvas();


        //Define AudioSource (in player)
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();

    }

    void Update()
    {
        KeyboardListener();
    }

    void KeyboardListener() 
    {     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isFocusOnMenu = !isFocusOnMenu; //Invert between true/false        

            ToggleBetweenGameAndMenu();
        };

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            activeCamera = !activeCamera;
            GameManager.playerCamera.gameObject.SetActive(activeCamera);
        }

    }
    

    public void ToggleBetweenGameAndMenu() 
    {
        if (isFocusOnMenu)
        {
            Time.timeScale = 0f;
            MenuLoad();
        }
        else
        {
            GameLoad();
            UnloadAllCanvas();
        }
    }
    void UnloadAllCanvas()
    {
        foreach (var canvas in CanvasList)
        {
            canvas.gameObject.SetActive(false);
            canvas.enabled = false;
        }
    }

    public void GameLoad()
    {
        UnloadAllCanvas();
        isFocusOnMenu = false;
        Time.timeScale = 1f;
    }

    public void MenuLoad() 
    {
        UnloadAllCanvas();

        //Load current Canvas
        Menu.enabled = true;
        Menu.gameObject.SetActive(true);

        //Play Audio when entering
        audioSource.clip = menuAudioClip[9];
        audioSource.Play();

        btnContinuar.Select();
       
    }
    public void ConfiguracoesLoad() 
    {
        UnloadAllCanvas();

        //Load current Canvas
        Configuracoes.enabled = true;
        Configuracoes.gameObject.SetActive(true);

        //Play Audio when entering
        audioSource.clip = menuAudioClip[8];
        audioSource.Play();

        btnAlterarVolume.Select();
    }
    public void AlterarVolumeLoad() 
    {
        UnloadAllCanvas();

        //Load current Canvas
        AlterarVolume.enabled = true;
        AlterarVolume.gameObject.SetActive(true);

        //Play Audio when entering
        audioSource.clip = menuAudioClip[7];
        audioSource.Play();


        sldVolume.Select();
    }
    
    

    #region NavegacaoComBotoes

    //SlideVolume
    public void UpdateGameVolume() 
    {
        GameVolume = sldVolume.value;

    }

    public void SairDoJogo() 
    {
        Application.Quit();
    }

    #endregion


}
