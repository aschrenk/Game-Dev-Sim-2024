using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlighter : MonoBehaviour
{
    public List<MenuButton> possibleSelectors;
    public bool exclusive = true;
    public bool selectOnEnable = true;
    public bool clearLastSelectedOnDisable = true;

    private MenuButton lastSelected = null; // Only includes the lastSelected if it's part of the possibleSelectors, unlike the built-in one.

    private void SetSelectedGameObject(GameObject newSelected)
    {
        EventSystem.current.SetSelectedGameObject(newSelected);
    }
    private void OnEnable()
    {
        if (selectOnEnable)
        {
            if (clearLastSelectedOnDisable || lastSelected == null)
                SetSelectedGameObject(possibleSelectors[0].gameObject);
            else SetSelectedGameObject(lastSelected.gameObject);
        }
    }
    private void OnDisable()
    {
        if (clearLastSelectedOnDisable)
            lastSelected = null;
    }
    private void Update()
    {
        if (exclusive)
        {
            if (EventSystem.current.currentSelectedGameObject == null)
            {
                SetLastSelectedOrFirstPossibleSelector();
            }
            else if (!possibleSelectors.Contains(EventSystem.current.currentSelectedGameObject.GetComponent<MenuButton>()))
                SetSelectedGameObject(possibleSelectors[0].gameObject);

        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject == null)
                SetLastSelectedOrFirstPossibleSelector();
        }

        if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.currentSelectedGameObject.GetComponent<MenuButton>())
            lastSelected = EventSystem.current.currentSelectedGameObject.GetComponent<MenuButton>();
    }

    private void SetLastSelectedOrFirstPossibleSelector()
    {
        if (lastSelected != null) SetSelectedGameObject(lastSelected.gameObject);
        else SetSelectedGameObject(possibleSelectors[0].gameObject);
    }
}
