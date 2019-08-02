/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-11-02 17:30:26
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    [CustomEditor(typeof(EZTransformAnimation), true), CanEditMultipleObjects]
    public class EZTransformAnimationEditor : EZAnimationEditor
    {
        protected EZTransformAnimation transformAnimation;
        protected SerializedProperty m_PathMode;

        protected override void GetOtherProperties()
        {
            transformAnimation = target as EZTransformAnimation;
            m_PathMode = serializedObject.FindProperty("m_PathMode");
        }
        protected override void DrawPropertiesAboveSegments()
        {
            EditorGUILayout.PropertyField(m_PathMode);
        }

        protected override void DrawSegmentListHeader(Rect rect)
        {
            rect.x += headerIndent; rect.width -= headerIndent;
            float width = rect.width / 2; rect.width -= horizontalSpace;
            EditorGUI.LabelField(rect, "Start Point");
            rect.x += width;
            EditorGUI.LabelField(rect, "End Point");
        }
        protected override float GetSegmentListElementHeight(int index)
        {
            return base.GetSegmentListElementHeight(index) * 2;
        }
        protected override Rect OnSegmentProperty(Rect rect, SerializedProperty segment)
        {
            SerializedProperty startPoint = segment.FindPropertyRelative("m_StartPoint");
            SerializedProperty endPoint = segment.FindPropertyRelative("m_EndPoint");
            float width = rect.width / 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, width - horizontalSpace, singleLineHeight), startPoint, GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x + width, rect.y, width - horizontalSpace, singleLineHeight), endPoint, GUIContent.none);
            rect.y += singleLineHeight + verticalSpace;
            rect.height /= 2;
            return rect;
        }

        private void OnSceneGUI()
        {
            if (transformAnimation.pathMode == EZTransformAnimation.PathMode.Bezier)
            {
                for (int i = 0; i < transformAnimation.segments.Count; i++)
                {
                    EZTransformSegment segment = transformAnimation.segments[i];
                    if (segment.startPoint != null)
                    {
                        EZTransformPathPointEditor.DrawTangentHandles(segment.startPoint);
                    }
                    if (segment.endPoint != null)
                    {
                        EZTransformPathPointEditor.DrawTangentHandles(transformAnimation.segments[i].endPoint);
                    }
                }
            }
        }
    }
}