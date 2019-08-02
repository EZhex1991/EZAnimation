/* Author:          ezhex1991@outlook.com
 * CreateTime:      2017-10-31 17:30:50
 * Organization:    #ORGANIZATION#
 * Description:     
 */
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EZhex1991.EZAnimation
{
    public abstract class EZAnimationEditor : Editor
    {
        protected EZAnimation animation;

        protected SerializedProperty m_Target;
        protected SerializedProperty m_Loop;
        protected SerializedProperty m_PlayOnAwake;
        protected SerializedProperty m_RestartOnEnable;
        protected SerializedProperty m_UpdateMode;
        protected SerializedProperty m_Status;
        protected SerializedProperty m_Time;
        protected SerializedProperty m_Segments;
        protected ReorderableList segments;

        protected float horizontalSpace = 5;
        protected float headerIndent = 15;
        protected float singleLineHeight = EditorGUIUtility.singleLineHeight;
        protected float verticalSpace = EditorGUIUtility.standardVerticalSpacing;

        protected void OnEnable()
        {
            animation = target as EZAnimation;

            m_Target = serializedObject.FindProperty("m_Target");
            m_Loop = serializedObject.FindProperty("m_Loop");
            m_PlayOnAwake = serializedObject.FindProperty("m_PlayOnAwake");
            m_RestartOnEnable = serializedObject.FindProperty("m_RestartOnEnable");
            m_UpdateMode = serializedObject.FindProperty("m_UpdateMode");
            m_Status = serializedObject.FindProperty("m_Status");
            m_Time = serializedObject.FindProperty("m_Time");
            m_Segments = serializedObject.FindProperty("m_Segments");
            segments = new ReorderableList(serializedObject, m_Segments, true, true, true, true)
            {
                drawHeaderCallback = DrawSegmentListHeader,
                elementHeightCallback = GetSegmentListElementHeight,
                drawElementCallback = DrawSegmentListElement,
            };
            GetOtherProperties();
        }
        protected virtual void GetOtherProperties()
        {

        }

        protected virtual void DrawSegmentListHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Segments");
        }
        protected virtual float GetSegmentListElementHeight(int index)
        {
            return singleLineHeight + verticalSpace;
        }
        protected virtual void DrawSegmentListElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty segment = segments.serializedProperty.GetArrayElementAtIndex(index);
            OnSegmentProperty(rect, segment);

            float originalLabelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 75f;
            SerializedProperty duration = segment.FindPropertyRelative("m_Duration");
            SerializedProperty curve = segment.FindPropertyRelative("m_Curve");
            rect.y += rect.height - singleLineHeight - verticalSpace;
            rect.height = singleLineHeight;
            float margin = 5f;
            float width = (rect.width - margin) / 2;
            rect.width = width;
            EditorGUI.PropertyField(rect, duration);
            rect.x += width + margin;
            Color curveColor = animation.segmentIndex == index ? Color.red : Color.green;
            Rect curveRect = new Rect(0, 0, 1, 1);
            curve.animationCurveValue = EditorGUI.CurveField(rect, curve.animationCurveValue, curveColor, curveRect);
            EditorGUIUtility.labelWidth = originalLabelWidth;
        }
        protected virtual Rect OnSegmentProperty(Rect rect, SerializedProperty segment)
        {
            return rect;
        }

        public sealed override void OnInspectorGUI()
        {
            serializedObject.Update();
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour(target as MonoBehaviour), typeof(MonoScript), false);
            GUI.enabled = true;

            DrawController();

            EditorGUILayout.PropertyField(m_Target);
            DrawPropertiesUnderTarget();

            EditorGUILayout.PropertyField(m_Loop);
            EditorGUILayout.PropertyField(m_PlayOnAwake);
            EditorGUILayout.PropertyField(m_RestartOnEnable);
            EditorGUILayout.PropertyField(m_UpdateMode);
            EditorGUILayout.PropertyField(m_Time);

            DrawPropertiesAboveSegments();
            segments.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
        protected virtual void DrawController()
        {
            GUI.enabled = Application.isPlaying;
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Play"))
                {
                    if (animation.status == Status.Stopped)
                        animation.Play();
                    else if (animation.status == Status.Paused)
                        animation.Resume();
                }
                if (GUILayout.Button("Pause"))
                {
                    animation.Pause();
                }
                if (GUILayout.Button("Stop"))
                {
                    animation.Stop();
                }
                GUILayout.EndHorizontal();
            }
            EditorGUILayout.PropertyField(m_Status);
            GUI.enabled = true;
        }
        protected virtual void DrawPropertiesUnderTarget()
        {

        }
        protected virtual void DrawPropertiesAboveSegments()
        {

        }
    }
}