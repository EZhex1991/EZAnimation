/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-11-02 17:31:02
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [CustomEditor(typeof(EZRendererFloatPropertyAnimation), true), CanEditMultipleObjects]
    public class EZRendererFloatPropertyAnimationEditor : EZAnimationEditor
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
            float originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 75f;
            SerializedProperty m_StartValue = segment.FindPropertyRelative("m_StartValue");
            SerializedProperty m_EndValue = segment.FindPropertyRelative("m_EndValue");
            rect.height = singleLineHeight;
            float margin = 5;
            float width = (rect.width - margin) / 2;
            rect.width = width;
            EditorGUI.PropertyField(rect, m_StartValue);
            rect.x += width + margin;
            EditorGUI.PropertyField(rect, m_EndValue);
            EditorGUIUtility.labelWidth = originalLabelWidth;
            return rect;
        }
    }
}