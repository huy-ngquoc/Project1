
using UnityEngine;
using UnityEngine.UI;

public class SkillLineDrawer : MonoBehaviour
{
    public RectTransform fromNode;
    public RectTransform toNode;
    public RectTransform lineImage;
    void Awake() {
        lineImage = gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (fromNode == null || toNode == null || lineImage == null)
            return;

        Vector3 dir = toNode.position - fromNode.position;
        float distance = dir.magnitude;

        lineImage.position = fromNode.position + dir / 2f;
        lineImage.sizeDelta = new Vector2(distance, lineImage.sizeDelta.y);
        lineImage.rotation = Quaternion.FromToRotation(Vector3.right, dir);
    }
}
