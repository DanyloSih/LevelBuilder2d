using UnityEngine;

namespace LevelBuilder2d.Selection
{
    public class SelectionBox : MonoBehaviour, ISelectionArea
    {
        [SerializeField] private RectTransform _rectTransform;

        private Bounds _realBounds = new Bounds();

        public void Disable()
            => gameObject.SetActive(false);

        public void Enable()
            => gameObject.SetActive(true);

        public bool IsContain(IObstacle obstacle)
        {
            Vector3 b = obstacle.GetClosestPoint(_realBounds.center);
            Vector3 a = _realBounds.ClosestPoint(b);

            float aDistance = Vector3.Distance(_realBounds.center, a);
            float bDistance = Vector3.Distance(_realBounds.center, b);

            return aDistance >= bDistance || _realBounds.Contains(obstacle.Center);
        }

        public void UpdateRect(Vector2 startPoint, Vector2 endPoint)
        {
            Vector2 position = Vector2.zero;
            position.x = endPoint.x < startPoint.x
                ? endPoint.x
                : startPoint.x;

            position.y = endPoint.y < startPoint.y
                ? startPoint.y
                : endPoint.y;

            Vector2 size = new Vector2(
                Mathf.Abs(endPoint.x - startPoint.x),
                Mathf.Abs(endPoint.y - startPoint.y));

            UpdateRealRect(position, size);
            _rectTransform.position = position;
            _rectTransform.sizeDelta = size;
            _rectTransform.localScale = Vector3.one;
        }

        private void UpdateRealRect(Vector2 position, Vector2 size)
        {
            size.y = -size.y;
            Camera mainCamer = Camera.main;
            Vector3 ul = mainCamer.ScreenToWorldPoint(position);
            ul.z = -100;
            Vector3 br = mainCamer.ScreenToWorldPoint(position + size);
            br.z = 100;
            float tmpY = ul.y;
            ul.y = br.y;
            br.y = tmpY;
            _realBounds.min = ul;
            _realBounds.max = br;
        }
    }
}
