using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillPopup : UI_Popup
{
    bool _skillSelected = false;

    enum Texts
    {
        LevelText,
        NickNameText,
        MoneyText,
    }

    enum Buttons
    {
        SkillButton1,
        SkillButton2,
        SkillButton3,
        SkillButton4,
        SkillListButton1,
        SkillListButton2,
        SkillListButton3,
        SkillListButton4,
        SkillListButton5,
        SkillListButton6,
        SkillListButton7,
        SkillListButton8,
        SkillListButton9,
        SkillListButton10,
        SkillListButton11,
        SkillListButton12,
        SkillListButton13,
        SkillListButton14,
        SkillListButton15,
        SkillListButton16,
        SkillWindowButton,
        StageAndBossButton,
        InventoryWindowButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<Button>(typeof(Buttons));
        BindText(typeof(Texts));

        Get<Button>((int)Buttons.SkillWindowButton).gameObject.BindEvent(OnClickSkillWindowButton);
        Get<Button>((int)Buttons.StageAndBossButton).gameObject.BindEvent(OnClickStageAndBossButton);
        Get<Button>((int)Buttons.InventoryWindowButton).gameObject.BindEvent(OnClickInventoryWindowButton);

        Get<Button>((int)Buttons.SkillListButton1).gameObject.BindEvent(OnClickSkillListButton);

        RefreshUI();

        return true;
    }

    void RefreshUI()
    {
        GetText((int)Texts.LevelText).text = Managers.Game.Level.ToString();
        GetText((int)Texts.NickNameText).text = Managers.Game.Name;
        GetText((int)Texts.MoneyText).text = Managers.Game.Money.ToString();
    }

    void OnClickSkillListButton()
    {
        if (_skillSelected)
        {
            _skillSelected = false;
            return;
        }

        _skillSelected = true;

    }


    void OnClickSkillWindowButton()
    {
        Managers.Sound.Play("Sound_MainButton", Define.Sound.Effect);
        Debug.Log("OnClickSkillWindowButton");
    }
    void OnClickStageAndBossButton()
    {
        Managers.Sound.Play("Sound_MainButton", Define.Sound.Effect);
        Managers.UI.ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_PlayPopup>();
    }
    void OnClickInventoryWindowButton()
    {
        Managers.Sound.Play("Sound_MainButton", Define.Sound.Effect);
        Managers.UI.ClosePopupUI();
        Managers.UI.ShowPopupUI<UI_InventoryPopup>();
    }
}
