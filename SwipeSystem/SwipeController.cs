using Internal.Codebase.GameplayLogic.Items;
using UnityEngine;

namespace Internal.Codebase.SwipeSystem
{
    public class SwipeController : MonoBehaviour
    {
        private const int MinSwipeRange = 5;
        
        [SerializeField] private Camera mainCamera;
        
        private bool isDragging;
        private Item item;
        private Vector2 startTouchPosition;
        private Vector2 currentTouchPosition;

        private void Update() => 
            InputChecker();

        private void InputChecker()
        {
            if (Input.GetMouseButtonDown(0))
                StartDragging();
            else if (Input.GetMouseButtonUp(0))
                StopDragging();
            else if (isDragging) 
                Dragging();
        }

        private void StartDragging()
        {
            item = RayLaunch();
            
            if (item == null)
                return;
            
            startTouchPosition = Input.mousePosition;
            isDragging = true;
        }

        private Item RayLaunch()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            Physics.Raycast(ray, out var hitInfo);

            if (hitInfo.collider == null)
            {
                Debug.Log("Не попал");
                return null;
            }

            return item = hitInfo.collider.GetComponent<Item>();
        }

        private void Dragging()
        {
            currentTouchPosition = GetTapPosition();
            var deltaPosition = currentTouchPosition - startTouchPosition;

            if (Mathf.Abs(deltaPosition.x) <= MinSwipeRange)
                return;

            if (deltaPosition.x > 0)
            {
                item.ItemMover.MoveSideways(Sides.Right);
            }
            else if (deltaPosition.x < 0)
            {
                item.ItemMover.MoveSideways(Sides.Left);
            }
            
            startTouchPosition = currentTouchPosition;
        }

        private void StopDragging()
        {
            isDragging = false;
            item = null;
        }
        
        private Vector3 GetTapPosition() => 
            Input.mousePosition;
    }
}
