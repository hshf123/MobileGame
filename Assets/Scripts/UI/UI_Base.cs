using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class UI_Base : MonoBehaviour
{
    protected Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    protected bool _init = false;

    public virtual bool Init()
    {
        if (_init)
            return false;

        return _init = true;
    }

    void Start()
    {
        Init();
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objects);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Utils.FindChild(gameObject, names[i], true);
            else
                objects[i] = Utils.FindChild<T>(gameObject, names[i], true);

            if (objects[i] == null)
                Debug.Log($"Failed to bind({names[i]})");
        }
    }
    protected void BindText(Type type)
    {
        Bind<TextMeshProUGUI>(type);
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }
    protected TextMeshProUGUI GetText(int idx)
    {
        return Get<TextMeshProUGUI>(idx);
    }

    public static void BindEvent(GameObject go, Action action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Pressed:
                evt.OnPressedHandler -= action;
                evt.OnPressedHandler += action;
                break;
            case Define.UIEvent.PointerDown:
                evt.OnDownHandler -= action;
                evt.OnDownHandler += action;
                break;
            case Define.UIEvent.PointerUp:
                evt.OnUpHandler -= action;
                evt.OnUpHandler += action;
                break;
        }
    }
}
