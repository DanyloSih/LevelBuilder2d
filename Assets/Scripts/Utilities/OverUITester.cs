using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LevelBuilder2d.Utilities
{
    public class OverUITester
    {
        private int _UILayer;
        private MainControls _mainControls;

        public OverUITester(int uILayer)
        {
            _UILayer = uILayer;
            _mainControls = new MainControls();
            _mainControls.Enable();
        }

        //Returns 'true' if we touched or hovering on Unity UI element.
        public bool IsPointerOverUIElement()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            return IsPointerOverUIElement(
                GetEventSystemRaycastResults(mousePosition));
        }

        //Returns 'true' if we touched or hovering on Unity UI element.
        public bool IsPointerOverUIElement(Vector2 pointerPosition)
        {
            return IsPointerOverUIElement(
                GetEventSystemRaycastResults(pointerPosition));
        }

        //Returns 'true' if we touched or hovering on Unity UI element.
        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                RaycastResult curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.layer == _UILayer)
                    return true;
            }
            return false;
        }


        //Gets all event system raycast results of current mouse or touch position.
        private List<RaycastResult> GetEventSystemRaycastResults(Vector2 mousePosition)
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = mousePosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
    }
}
