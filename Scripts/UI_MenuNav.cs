using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public static float GameVolume;

    bool isFocusOnMenu = false;


    void Start()
    {
        //Define menus
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

    }

    // Update is called once per frame
    void Update()
    {
        KeyboardListener();
    }

    void KeyboardListener() 
    {     
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pressed ESC");
            isFocusOnMenu = !isFocusOnMenu; //Invert between true/false        

            ToggleBetweenGameAndMenu();
        };
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
        }
    }
    void UnloadAllCanvas()
    {
        foreach (var Canvas in CanvasList)
        {
            Canvas.enabled = false;
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

        Menu.enabled = true;
        btnContinuar.Select();
    }
    public void ConfiguracoesLoad() 
    {
        UnloadAllCanvas();

        Configuracoes.enabled = true;
        btnAlterarVolume.Select();
    }
    public void AlterarVolumeLoad() 
    {
        UnloadAllCanvas();
        AlterarVolume.enabled = true;

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
