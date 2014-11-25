using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SAF.Framework.Controls.Charts
{
    public enum GraphicsType
    {
        /// <summary>
        /// 光标
        /// </summary>
        Pointer = 0,
        /// <summary>
        /// 直线
        /// </summary>
        Line = 1,
        /// <summary>
        /// 虚线
        /// </summary>
        DotLine = 2,
        /// <summary>
        /// 绘制矩形
        /// </summary>
        Rectangle = 3,
        /// <summary>
        /// 绘制圆角矩形
        /// </summary>
        RoundedRectangle = 4,
        /// <summary>
        /// 绘制椭圆
        /// </summary>
        Ellipse = 5,
        /// <summary>
        /// 菱形
        /// </summary>
        Rhombus = 6,
        /// <summary>
        /// 文本
        /// </summary>
        Polygon = 7,
        /// <summary>
        /// 拖动
        /// </summary>
        Drag = 8,
        /// <summary>
        /// Actor
        /// </summary>
        [GraphicsDisplay(DiagramType.UserCase, "角色")]
        Actor = 9,
        /// <summary>
        /// Initial
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "开始")]
        [GraphicsDisplay(DiagramType.Workflow, "开始")]
        Initial = 10,
        /// <summary>
        /// Final
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "结束")]
        [GraphicsDisplay(DiagramType.Workflow, "结束")]
        Final = 11,
        /// <summary>
        /// ExitPoint
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "出口")]
        ExitPoint = 12,
        /// <summary>
        /// EntryPoint
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "入口")]
        EntryPoint = 13,
        /// <summary>
        /// Transition
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "状态转换线", Index = -1)]
        Transition = 14,
        /// <summary>
        /// 状态
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "状态")]
        State = 15,
        /// <summary>
        /// 终止
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "终止")]
        Terminate = 16,
        /// <summary>
        /// 分支
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "分支")]
        [GraphicsDisplay(DiagramType.UserCase, "分支")]
        [GraphicsDisplay(DiagramType.Workflow, "分支")]
        Choice = 17,
        /// <summary>
        /// Note
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "备注", int.MaxValue)]
        [GraphicsDisplay(DiagramType.UserCase, "备注", int.MaxValue)]
        [GraphicsDisplay(DiagramType.HSEntitySet, "备注", int.MaxValue)]
        [GraphicsDisplay(DiagramType.Workflow, "备注", int.MaxValue)]
        Note = 18,
        /// <summary>
        /// Objects
        /// </summary>
        [GraphicsDisplay(DiagramType.State, "对象")]
        [GraphicsDisplay(DiagramType.UserCase, "对象")]
        Objects = 19,
        /// <summary>
        /// UserCase
        /// </summary>
        [GraphicsDisplay(DiagramType.UserCase, "用例")]
        UserCase = 20,
        /// <summary>
        /// Use
        /// </summary>
        [GraphicsDisplay(DiagramType.UserCase, "引用线", Index = -1)]
        Use = 21,
        /// <summary>
        /// Invokes
        /// </summary>
        [GraphicsDisplay(DiagramType.UserCase, "调用线", Index = -1)]
        [GraphicsDisplay(DiagramType.HSEntitySet, "引用线", Index = -1)]
        Invokes = 22,
        /// <summary>
        /// 流程节点
        /// </summary>
        [GraphicsDisplay(DiagramType.Workflow, "流程节点")]
        FlowNode = 23,
        /// <summary>
        /// 连线
        /// </summary>
        [GraphicsDisplay(DiagramType.Workflow, "结点连线", Index = -1)]
        FlowLine = 24,
        /// <summary>
        /// 实体集
        /// </summary>
        [GraphicsDisplay(DiagramType.HSEntitySet, "实体集")]
        [GraphicsDisplay(DiagramType.UserCase, "实体集")]
        HSEntitySet = 25,
        /// <summary>
        /// 引用
        /// </summary>
        [GraphicsDisplay(DiagramType.HSEntitySet, "外键线", Index = -1)]
        [GraphicsDisplay(DiagramType.UserCase, "外键线")]
        Reference = 26,
        /// <summary>
        /// 泳道
        /// </summary>
        [GraphicsDisplay(DiagramType.HSEntitySet, "泳道")]
        [GraphicsDisplay(DiagramType.State, "泳道")]
        [GraphicsDisplay(DiagramType.UserCase, "泳道")]
        Swimlane = 27,
        /// <summary>
        /// 
        /// </summary>
        [GraphicsDisplay(DiagramType.UserCase, "继承线", Index = -1)]
        [GraphicsDisplay(DiagramType.HSEntitySet, "继承线", Index = -1)]
        InheritLine = 28
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public sealed class GraphicsDisplayAttribute : Attribute
    {
        public DiagramType DiagramType { get; set; }
        public int Index { get; set; }

        public string Name { get; set; }

        public GraphicsDisplayAttribute(DiagramType diagramType, string name, int index)
        {
            this.DiagramType = diagramType;
            this.Name = name;
            this.Index = index;
        }

        public GraphicsDisplayAttribute(DiagramType diagramType, string name)
            : this(diagramType, name, 1)
        { }

    }

}
