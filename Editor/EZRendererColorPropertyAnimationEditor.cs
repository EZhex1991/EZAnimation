/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-11-02 17:31:02
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [CustomEditor(typeof(EZRendererColorPropertyAnimation), true), CanEditMultipleObjects]
    public class EZRendererColorPropertyAnimationEditor : EZAnimationEditor
    {
        protected SerializedProperty m_PropertyName;

        protected override void GetOtherProperties()
        {
            m_PropertyName = serializedObject.FindProperty("m_PropertyName");
        }
        protected override void DrawPropertiesAboveSegments()
        {
            EditorGUILayout.PropertyField(m_PropertyName);
        }

        protected override float GetSegmentListElementHeight(int index)
        {
            return base.GetSegmentListElementHeight(index) * 2;
        }
        protected override Rect OnSegmentProperty(Rect rect, SerializedProperty segment)
        {
            SerializedProperty gradient = segment.FindPropertyRelative("m_Gradient");
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, singleLineHeight), gradient, GUIContent.none);
            rect.y += singleLineHeight + verticalSpace;
            rect.height /= 2;
            return rect;
        }
    }
}