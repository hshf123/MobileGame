using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EquipmentPopup : UI_Popup
{
    enum Buttons
    {
        CheckButton,
        CancelButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<Button>(typeof(Buttons));

        Get<Button>((int)Buttons.CheckButton).gameObject.BindEvent(OnClickCheckButton);
        Get<Button>((int)Buttons.CancelButton).gameObject.BindEvent(OnClickCancelButton);

        return true;
    }

    void OnClickCheckButton()
    {
        Managers.Game.SelectEquipment(Managers.Game.EquipmentSlotNumber++ % 4, Managers.Inven.SelectedItem);
        Managers.UI.ClosePopupUI();
        Managers.UI.Root.FindChild("UI_InventoryPopup").GetComponent<UI_InventoryPopup>().RefreshUI();
        Managers.Game.Save();
    }
    void OnClickCancelButton()
    {
        Managers.UI.ClosePopupUI();
        Managers.UI.Root.FindChild("UI_InventoryPopup").GetComponent<UI_InventoryPopup>().RefreshUI();
    }
}
