using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class HoverButton : MonoBehaviour
{
    public string SceneTarget;
    public Material Material;

    private bool _selected;

    void Start()
    {
        _selected = false;

        if (Material != null)
            Material.color = new Color(0.5f, 0.5f, 0.5f);
    }

    void LateUpdate()
    {
        // not needed, will use the XR events instead
        if (XRSettings.enabled || !_selected)
            return;

        if (Input.GetMouseButtonDown(0))
            ButtonInteract();
    }

    void OnMouseEnter()
    {
        _selected = true;
        ButtonHoverEnter();
    }

    void OnMouseExit()
    {
        _selected = false;
        ButtonHoverExit();
    }

    public void ButtonHoverEnter()
    {
        if (Material == null)
            return;

        Material.color = Color.white;
    }

    public void ButtonHoverExit()
    {
        if (Material == null)
            return;

        Material.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void ButtonInteract()
    {
        if (string.IsNullOrWhiteSpace(SceneTarget))
            return;

        SceneManager.LoadScene(SceneTarget);
    }
}
