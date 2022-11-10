using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainScene : UI_Scene
{
    bool _soundOnOff = true;
    Sprite _soundOnImage;
    Sprite _soundOffImage;

    enum Buttons
    {
        SoundOnOffButton,
        PlayerInfoButton,
    }

    enum Images
    {
        SoundOnOffButtonIcon,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));

        Get<Button>((int)Buttons.SoundOnOffButton).gameObject.BindEvent(OnClickSoundOnOffButton);
        Get<Button>((int)Buttons.PlayerInfoButton).gameObject.BindEvent(OnClickPlayerInfoButton);

        _soundOnImage = Managers.Resource.Load<Sprite>("Sprites/Icon/icon_sound_on");
        _soundOffImage = Managers.Resource.Load<Sprite>("Sprites/Icon/icon_sound_off");

        return true;
    }

    void OnClickSoundOnOffButton()
    {
        if(_soundOnOff)
        {
            Managers.Sound.SoundOff();
            _soundOnOff = false;
            Get<Image>((int)Images.SoundOnOffButtonIcon).sprite = _soundOffImage;
        }
        else
        {
            Managers.Sound.SoundOn();
            _soundOnOff = true;
            Get<Image>((int)Images.SoundOnOffButtonIcon).sprite = _soundOnImage;
        }
    }

    void OnClickPlayerInfoButton()
    {
        Managers.UI.ShowPopupUI<UI_PlayerInfoPopup>();
    }
}