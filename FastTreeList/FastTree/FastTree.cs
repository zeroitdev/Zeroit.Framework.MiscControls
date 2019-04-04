// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 11-30-2018
// ***********************************************************************
// <copyright file="FastTree.cs" company="Zeroit Dev Technologies">
//    This program is for creating various controls.
//    Copyright ©  2017  Zeroit Dev Technologies
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
//    You can contact me at zeroitdevnet@gmail.com or zeroitdev@outlook.com
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// Class ZeroitFastTree.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.ZeroitFastListBase" />
    [ToolboxItem(true)]
    [DefaultEvent("NodeChildrenNeeded")]
    public class ZeroitFastTree : ZeroitFastListBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether [automatic collapse].
        /// </summary>
        /// <value><c>true</c> if [automatic collapse]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool AutoCollapse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show root node].
        /// </summary>
        /// <value><c>true</c> if [show root node]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowRootNode { get; set; }

        /// <summary>
        /// Gets the expanded nodes.
        /// </summary>
        /// <value>The expanded nodes.</value>
        [Browsable(false)]
        public IEnumerable<object> ExpandedNodes { get { return expandedNodes; } }

        /// <summary>
        /// Gets the selected nodes.
        /// </summary>
        /// <value>The selected nodes.</value>
        [Browsable(false)]
        public IEnumerable<object> SelectedNodes { get { return SelectedItemIndexes.OrderBy(i => i).Select(i => nodes[i]); } }

        /// <summary>
        /// Gets the selected node.
        /// </summary>
        /// <value>The selected node.</value>
        [Browsable(false)]
        public object SelectedNode { get { return SelectedNodes.FirstOrDefault(); } }

        /// <summary>
        /// Gets the checked nodes.
        /// </summary>
        /// <value>The checked nodes.</value>
        [Browsable(false)]
        public IEnumerable<object> CheckedNodes { get { return CheckedItemIndex.OrderBy(i => i).Select(i => nodes[i]); } }

        /// <summary>
        /// Gets or sets a value indicating whether [uncheck child when collapsed].
        /// </summary>
        /// <value><c>true</c> if [uncheck child when collapsed]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool UncheckChildWhenCollapsed { get; set; }

        /// <summary>
        /// List of all visible nodes
        /// </summary>
        /// <value>The nodes.</value>
        [Browsable(false)]
        public IEnumerable<object> Nodes { get { return nodes; } }

        /// <summary>
        /// The nodes
        /// </summary>
        protected List<object> nodes = new List<object>();
        /// <summary>
        /// The levels
        /// </summary>
        protected List<int> levels = new List<int>();
        /// <summary>
        /// The expanded nodes
        /// </summary>
        protected HashSet<object> expandedNodes = new HashSet<object>();
        /// <summary>
        /// The has children
        /// </summary>
        protected BitArray hasChildren;

        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        /// <value>The item count.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int ItemCount
        {
            get { return base.ItemCount; }
            set { base.ItemCount = value; }
        }

        /// <summary>
        /// Gets or sets the item indent default.
        /// </summary>
        /// <value>The item indent default.</value>
        [DefaultValue(16)]
        public override int ItemIndentDefault
        {
            get { return base.ItemIndentDefault; }
            set { base.ItemIndentDefault = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitFastTree"/> class.
        /// </summary>
        public ZeroitFastTree()
        {
            AutoCollapse = true;
            ShowRootNode = false;
            ShowExpandBoxes = true;
            UncheckChildWhenCollapsed = true;
            ItemIndentDefault = 16;

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                Build(new object[] { "Node 1", "Node 2", "Node 3" });
                SelectedItemIndexes.Add(0);
            }
        }

        #region Events

        /// <summary>
        /// Occurs when [node height needed].
        /// </summary>
        public event EventHandler<IntNodeEventArgs> NodeHeightNeeded;
        /// <summary>
        /// Occurs when [node text needed].
        /// </summary>
        public event EventHandler<StringNodeEventArgs> NodeTextNeeded;
        /// <summary>
        /// Occurs when [node check state needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> NodeCheckStateNeeded;
        /// <summary>
        /// Occurs when [node icon needed].
        /// </summary>
        public event EventHandler<ImageNodeEventArgs> NodeIconNeeded;
        /// <summary>
        /// Occurs when [node line alignment needed].
        /// </summary>
        public event EventHandler<StringAlignmentNodeEventArgs> NodeLineAlignmentNeeded;
        /// <summary>
        /// Occurs when [node CheckBox visible needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> NodeCheckBoxVisibleNeeded;
        /// <summary>
        /// Occurs when [node back color needed].
        /// </summary>
        public event EventHandler<ColorNodeEventArgs> NodeBackColorNeeded;
        /// <summary>
        /// Occurs when [node indent needed].
        /// </summary>
        public event EventHandler<IntNodeEventArgs> NodeIndentNeeded;
        /// <summary>
        /// Occurs when [node fore color needed].
        /// </summary>
        public event EventHandler<ColorNodeEventArgs> NodeForeColorNeeded;
        /// <summary>
        /// Occurs when [node visibility needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> NodeVisibilityNeeded;
        /// <summary>
        /// Occurs when [can unselect node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanUnselectNodeNeeded;
        /// <summary>
        /// Occurs when [can select node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanSelectNodeNeeded;
        /// <summary>
        /// Occurs when [can uncheck node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanUncheckNodeNeeded;
        /// <summary>
        /// Occurs when [can check node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanCheckNodeNeeded;
        /// <summary>
        /// Occurs when [can expand node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanExpandNodeNeeded;
        /// <summary>
        /// Occurs when [can collapse node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanCollapseNodeNeeded;
        /// <summary>
        /// Occurs when [can edit node needed].
        /// </summary>
        public event EventHandler<BoolNodeEventArgs> CanEditNodeNeeded;

        /// <summary>
        /// Occurs when [node checked state changed].
        /// </summary>
        public event EventHandler<NodeCheckedStateChangedEventArgs> NodeCheckedStateChanged;
        /// <summary>
        /// Occurs when [node expanded state changed].
        /// </summary>
        public event EventHandler<NodeExpandedStateChangedEventArgs> NodeExpandedStateChanged;
        /// <summary>
        /// Occurs when [node selected state changed].
        /// </summary>
        public event EventHandler<NodeSelectedStateChangedEventArgs> NodeSelectedStateChanged;
        /// <summary>
        /// Occurs when [node text pushed].
        /// </summary>
        public event EventHandler<NodeTextPushedEventArgs> NodeTextPushed;

        /// <summary>
        /// Occurs when [paint node].
        /// </summary>
        public event EventHandler<PaintNodeContentEventArgs> PaintNode;

        /// <summary>
        /// Occurs when [node children needed].
        /// </summary>
        public event EventHandler<NodeChildrenNeededEventArgs> NodeChildrenNeeded;

        /// <summary>
        /// Occurs when user start to drag node
        /// </summary>
        public event EventHandler<NodeDragEventArgs> NodeDrag;

        /// <summary>
        /// Occurs when user drag object over node
        /// </summary>
        public event EventHandler<DragOverItemEventArgs> DragOverNode;

        /// <summary>
        /// Occurs when user drop object on given node
        /// </summary>
        public event EventHandler<DragOverItemEventArgs> DropOverNode;

        /// <summary>
        /// Gets the node visibility.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool GetNodeVisibility(object node)
        {
            if (NodeVisibilityNeeded != null)
            {
                boolArg.Node = node;
                boolArg.Result = true;
                NodeVisibilityNeeded(this, boolArg);
                return boolArg.Result;
            }
            return true;
        }

        /// <summary>
        /// Gets the item text.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.String.</returns>
        protected override string GetItemText(int itemIndex)
        {
            return GetStringNodeProperty(itemIndex, NodeTextNeeded, nodes[itemIndex].ToString());
        }

        /// <summary>
        /// Gets the item checked.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemChecked(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, NodeCheckStateNeeded, CheckedItemIndex.Contains(itemIndex));
        }

        /// <summary>
        /// Gets the item icon.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Image.</returns>
        protected override Image GetItemIcon(int itemIndex)
        {
            return GetImageNodeProperty(itemIndex, NodeIconNeeded, ImageDefaultIcon);
        }

        /// <summary>
        /// Gets the item line alignment.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>StringAlignment.</returns>
        protected override StringAlignment GetItemLineAlignment(int itemIndex)
        {
            return GetLineAlignmentNodeProperty(itemIndex, NodeLineAlignmentNeeded, ItemLineAlignmentDefault);
        }


        /// <summary>
        /// Gets the height of the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        protected override int GetItemHeight(int itemIndex)
        {
            return GetIntNodeProperty(itemIndex, NodeHeightNeeded, ItemHeightDefault);
        }

        /// <summary>
        /// Gets the item CheckBox visible.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemCheckBoxVisible(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, NodeCheckBoxVisibleNeeded, ShowCheckBoxes);
        }

        /// <summary>
        /// Gets the color of the item back.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected override Color GetItemBackColor(int itemIndex)
        {
            return GetColorNodeProperty(itemIndex, NodeBackColorNeeded, Color.Empty);
        }

        /// <summary>
        /// Gets the color of the item fore.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>Color.</returns>
        protected override Color GetItemForeColor(int itemIndex)
        {
            return GetColorNodeProperty(itemIndex, NodeForeColorNeeded, ForeColor);
        }

        /// <summary>
        /// Determines whether this instance [can unselect item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can unselect item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanUnselectItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanUnselectNodeNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can select item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can select item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanSelectItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanSelectNodeNeeded, AllowSelectItems);
        }

        /// <summary>
        /// Determines whether this instance [can uncheck item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can uncheck item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanUncheckItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanUncheckNodeNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can check item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can check item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanCheckItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanCheckNodeNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can collapse item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can collapse item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanCollapseItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanCollapseNodeNeeded, true);
        }

        /// <summary>
        /// Determines whether this instance [can edit item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can edit item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanEditItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanEditNodeNeeded, true);
        }

        /// <summary>
        /// Called when [item checked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemChecked(int itemIndex)
        {
            if (NodeCheckedStateChanged != null)
                NodeCheckedStateChanged(this, new NodeCheckedStateChangedEventArgs { Node = nodes[itemIndex], Checked = true });

            base.OnItemChecked(itemIndex);
        }

        /// <summary>
        /// Called when [item unchecked].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemUnchecked(int itemIndex)
        {
            if (NodeCheckedStateChanged != null)
                NodeCheckedStateChanged(this, new NodeCheckedStateChangedEventArgs { Node = nodes[itemIndex], Checked = false });

            base.OnItemUnchecked(itemIndex);
        }

        /// <summary>
        /// Called when [item text pushed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="text">The text.</param>
        protected override void OnItemTextPushed(int itemIndex, string text)
        {
            if (NodeTextPushed != null)
                NodeTextPushed(this, new NodeTextPushedEventArgs { Node = nodes[itemIndex], Text = text });

            base.OnItemTextPushed(itemIndex, text);
        }

        /// <summary>
        /// Called when [item expanded].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemExpanded(int itemIndex)
        {
            OnNodeExpanded(nodes[itemIndex]);
            base.OnItemExpanded(itemIndex);
        }

        /// <summary>
        /// Called when [node expanded].
        /// </summary>
        /// <param name="node">The node.</param>
        protected virtual void OnNodeExpanded(object node)
        {
            if (NodeExpandedStateChanged != null)
                NodeExpandedStateChanged(this, new NodeExpandedStateChangedEventArgs { Node = node, Expanded = true });
        }

        /// <summary>
        /// Called when [item collapsed].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemCollapsed(int itemIndex)
        {
            if (NodeExpandedStateChanged != null)
                NodeExpandedStateChanged(this, new NodeExpandedStateChangedEventArgs { Node = nodes[itemIndex], Expanded = false });

            base.OnItemCollapsed(itemIndex);
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemSelected(int itemIndex)
        {
            if (NodeSelectedStateChanged != null)
                NodeSelectedStateChanged(this, new NodeSelectedStateChangedEventArgs { Node = nodes[itemIndex], Selected = true });

            base.OnItemSelected(itemIndex);
        }

        /// <summary>
        /// Called when [item unselected].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemUnselected(int itemIndex)
        {
            if (NodeSelectedStateChanged != null)
                NodeSelectedStateChanged(this, new NodeSelectedStateChangedEventArgs { Node = nodes[itemIndex], Selected = false });

            base.OnItemUnselected(itemIndex);
        }

        /// <summary>
        /// Called when [item drag].
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        protected override void OnItemDrag(HashSet<int> itemIndex)
        {
            var nodes = new HashSet<object>(itemIndex.Select(i => this.nodes[i]));

            if (NodeDrag != null)
                NodeDrag(this, new NodeDragEventArgs {Nodes = nodes});
            else
                DoDragDrop(nodes, DragDropEffects.Copy);

            base.OnItemDrag(itemIndex);
        }

        /// <summary>
        /// Draws the item.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="info">The information.</param>
        protected override void DrawItem(Graphics gr, VisibleItemInfo info)
        {
            if (PaintNode != null)
                PaintNode(this, new PaintNodeContentEventArgs { Graphics = gr, Info = info, Node = nodes[info.ItemIndex]});
            else
                base.DrawItem(gr, info);
        }

        /// <summary>
        /// Handles the <see cref="E:DragOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs" /> instance containing the event data.</param>
        protected override void OnDragOverItem(DragOverItemEventArgs e)
        {
            base.OnDragOverItem(e);

            e.Tag = nodes[e.ItemIndex];

            if (DragOverNode != null)
                DragOverNode(this, e);
        }

        /// <summary>
        /// Handles the <see cref="E:DropOverItem" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DragOverItemEventArgs" /> instance containing the event data.</param>
        protected override void OnDropOverItem(DragOverItemEventArgs e)
        {
            e.Tag = nodes[e.ItemIndex];

            if (DropOverNode != null)
                DropOverNode(this, e);

            base.OnDropOverItem(e);
        }

        #endregion Events

        #region Build

        /// <summary>
        /// The root
        /// </summary>
        protected object root;

        /// <summary>
        /// Builds the specified root.
        /// </summary>
        /// <param name="root">The root.</param>
        public void Build(object root)
        {
            this.root = root;
            //create set of selected and checked nodes
            var selected = new HashSet<object>();
            var check = new HashSet<object>();

            foreach (var i in SelectedItemIndexes)
                selected.Add(nodes[i]);

            foreach (var i in CheckedItemIndex)
                check.Add(nodes[i]);

            //
            nodes.Clear();
            levels.Clear();
            SelectedItemIndexes.Clear();
            CheckedItemIndex.Clear();

            //build list of expanded nodes
            if (ShowRootNode)
                AddNode(root, 0);
            else
                AddNodeChildren(root, 0);
            //restore indexes of selected and checked nodes
            var newExpanded = new HashSet<object>();
            hasChildren = new BitArray(nodes.Count);

            for (int i = 0; i < nodes.Count;i++)
            {
                var node = nodes[i];
                if (selected.Contains(node)) SelectedItemIndexes.Add(i);
                if (check.Contains(node)) CheckedItemIndex.Add(i);
                if (expandedNodes.Contains(node)) newExpanded.Add(node);
                hasChildren[i] = GetNodeChildren(nodes[i]).Cast<object>().Any();
            }

            expandedNodes = newExpanded;
            ItemCount = nodes.Count;
            base.Build();
        }

        /// <summary>
        /// Rebuilds this instance.
        /// </summary>
        public void Rebuild()
        {
            if(root != null)
                Build(root);
        }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="level">The level.</param>
        private void AddNode(object node, int level)
        {
            if (node == null || !GetNodeVisibility(node))
                return;
            //
            nodes.Add(node);
            levels.Add(level);
            //
            if (expandedNodes.Contains(node))
                AddNodeChildren(node, level + 1);
        }

        /// <summary>
        /// Adds the node children.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="level">The level.</param>
        private void AddNodeChildren(object node, int level)
        {
            foreach (var child in GetNodeChildren(node))
                AddNode(child, level);
        }

        /// <summary>
        /// Gets the node children.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>IEnumerable.</returns>
        protected virtual IEnumerable GetNodeChildren(object node)
        {
            if(NodeChildrenNeeded != null)
            {
                var arg = new NodeChildrenNeededEventArgs() {Node = node};
                NodeChildrenNeeded(this, arg);
                if (arg.Children != null)
                    foreach (var child in arg.Children)
                        yield return child;
            }else
            if(node is IEnumerable)
            {
                if (!(node is string))
                foreach (var child in node as IEnumerable)
                    yield return child;
            }
        }

        #endregion Build

        #region Additional methods

        /// <summary>
        /// Gets the index of the node by.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Object.</returns>
        public virtual object GetNodeByIndex(int index)
        {
            if (index < 0 || index >= nodes.Count) return null;
            return nodes[index];
        }

        /// <summary>
        /// Gets the item level.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public virtual int GetItemLevel(int index)
        {
            return levels[index];
        }

        /// <summary>
        /// Expands the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool ExpandItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= nodes.Count)
                return false;

            var list = GetNodeChildren(nodes[itemIndex]).Cast<object>().ToList();
            if(list.Count > 0)
            if(CanExpandItem(itemIndex))
            {
                expandedNodes.Add(nodes[itemIndex]);
                Build(root);
                if (itemIndex < nodes.Count)
                    OnItemExpanded(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Expands the nodes unsafe.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public virtual void ExpandNodesUnsafe(IEnumerable<object> nodes)
        {
            foreach(var node in nodes)
                expandedNodes.Add(node);
            BuildNeeded();
            Invalidate();
        }

        /// <summary>
        /// Collapses the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool CollapseItem(int itemIndex)
        {
            return CollapseItem(itemIndex, true);
        }

        /// <summary>
        /// Collapses the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="build">if set to <c>true</c> [build].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected virtual bool CollapseItem(int itemIndex, bool build)
        {
            if (itemIndex < 0 || itemIndex >= nodes.Count)
                return false;

            if (CanCollapseItem(itemIndex))
            {
                //range of collapsing nodes
                var i = itemIndex + 1;
                var level = levels[itemIndex];
                while (i < nodes.Count && levels[i] > level)
                    i++;

                var from = itemIndex + 1;
                var to = i - 1;
                if (to < from)
                    return true;

                //check selection, checked
                foreach (var j in SelectedItemIndexes)
                    if (j >= from && j <= to)
                        if (!CanUnselectItem(j))
                            return false;

                foreach (var j in CheckedItemIndex)
                    if (j >= from && j <= to)
                        if (!CanUncheckItem(j))
                            return false;

                for (var j = from; j <= to; j++)
                    if (expandedNodes.Contains(nodes[j]))
                        if (!CanCollapseItem(j))
                            return false;

                //unselect, uncheck
                for (int j = from; j <= to; j++)
                {
                    UnselectItem(j);
                    if(UncheckChildWhenCollapsed)
                        UncheckItem(j);
                    if (expandedNodes.Contains(nodes[j]))
                    {
                        expandedNodes.Remove(nodes[j]);
                        OnItemCollapsed(j);
                    }
                }
                //remove
                expandedNodes.Remove(nodes[itemIndex]);
                //
                OnItemCollapsed(itemIndex);
                if (build)
                    Build(root);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Unselects the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UnselectNode(object node)
        {
            return base.UnselectItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Selects the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="unselectOtherItems">if set to <c>true</c> [unselect other items].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool SelectNode(object node, bool unselectOtherItems = true)
        {
            return base.SelectItem(nodes.IndexOf(node), unselectOtherItems);
        }

        /// <summary>
        /// Unchecks the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool UncheckNode(object node)
        {
            return base.UncheckItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Checks the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool CheckNode(object node)
        {
            return base.CheckItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Determines whether [is node selected] [the specified node].
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if [is node selected] [the specified node]; otherwise, <c>false</c>.</returns>
        public virtual bool IsNodeSelected(object node)
        {
            return SelectedItemIndexes.Contains(nodes.IndexOf(node));
        }

        /// <summary>
        /// Determines whether [is node checked] [the specified node].
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if [is node checked] [the specified node]; otherwise, <c>false</c>.</returns>
        public virtual bool IsNodeChecked(object node)
        {
            return GetItemChecked(nodes.IndexOf(node));
        }

        /// <summary>
        /// Determines whether [is node expanded] [the specified node].
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if [is node expanded] [the specified node]; otherwise, <c>false</c>.</returns>
        public virtual bool IsNodeExpanded(object node)
        {
            return expandedNodes.Contains(node);
        }

        /// <summary>
        /// Expands the node and children.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="maxExpandLevelCount">The maximum expand level count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool ExpandNodeAndChildren(object node, int maxExpandLevelCount)
        {
            var list = GetNodeChildren(node).Cast<object>().ToList();
            if (list.Count > 0)
                if (CanExpandNode(node))
                {
                    expandedNodes.Add(node);
                    OnNodeExpanded(node);

                    if (maxExpandLevelCount > 1)
                    foreach (var child in list)
                        ExpandNodeAndChildren(child, maxExpandLevelCount - 1);

                    return true;
                }

            return false;
        }

        /// <summary>
        /// Expands the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="expandChildren">if set to <c>true</c> [expand children].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ExpandNode(object node, bool expandChildren = false)
        {
            if (expandChildren)
            {
                if(ExpandNodeAndChildren(node, int.MaxValue))
                {
                    Build(root);
                    return true;
                }
                return false;
            }
            else
                return ExpandItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Expands the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="maxExpandLevelCount">The maximum expand level count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ExpandNode(object node, int maxExpandLevelCount)
        {
            if (maxExpandLevelCount > 1)
            {
                if (ExpandNodeAndChildren(node, maxExpandLevelCount))
                {
                    Build(root);
                    return true;
                }
                return false;
            }
            else
                return ExpandItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Collapses the node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CollapseNode(object node)
        {
            return CollapseItem(nodes.IndexOf(node));
        }

        /// <summary>
        /// Expands all.
        /// </summary>
        public void ExpandAll()
        {
            if (ShowRootNode)
                ExpandNodeAndChildren(root, int.MaxValue);
            else
                foreach (var child in GetNodeChildren(root))
                    ExpandNodeAndChildren(child, int.MaxValue);

            Build(root);
        }

        /// <summary>
        /// Collapses all.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CollapseAll()
        {
            var res = true;

            for (int i = nodes.Count - 1; i >= 0; i--)
            if (expandedNodes.Contains(nodes[i]))
                res &= CollapseItem(i, false);

            Build(root);

            return res;
        }

        /// <summary>
        /// Returns all expanded children of the node
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="onlyFirstLevel">if set to <c>true</c> [only first level].</param>
        /// <returns>IEnumerable.</returns>
        public virtual IEnumerable GetNodeExpandedChildren(object node, bool onlyFirstLevel = false)
        {
            var itemIndex = nodes.IndexOf(node);
            if (itemIndex < 0) 
                yield break;

            foreach (var i in GetItemExpandedChildren(itemIndex, onlyFirstLevel))
                yield return nodes[i];
        }

        /// <summary>
        /// Returns all expanded children of the item
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="onlyFirstLevel">if set to <c>true</c> [only first level].</param>
        /// <returns>IEnumerable&lt;System.Int32&gt;.</returns>
        public virtual IEnumerable<int> GetItemExpandedChildren(int itemIndex, bool onlyFirstLevel = false)
        {
            var i = itemIndex + 1;
            var level = levels[itemIndex];
            while (i < nodes.Count && levels[i] > level)
            {
                if ((!onlyFirstLevel) || (levels[i] == level + 1))
                    yield return i;
                i++;
            }
        }

        /// <summary>
        /// Gets the item index of node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.Int32.</returns>
        public int GetItemIndexOfNode(object node)
        {
            return nodes.IndexOf(node);
        }

        /// <summary>
        /// Scrolls to node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="tryToCenter">if set to <c>true</c> [try to center].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool ScrollToNode(object node, bool tryToCenter = false)
        {
            var itemIndex = GetItemIndexOfNode(node);
            if (itemIndex < 0 || itemIndex >= ItemCount)
                return false;

            var y = GetItemY(itemIndex);
            var height = GetItemHeight(itemIndex);
            if (tryToCenter)
            {
                y -= ClientSize.Height/2 - 10;
                height += ClientSize.Height - 10;
            }
            ScrollToRectangle(new Rectangle(0, y, ClientRectangle.Width, height));
            return true;
        }

        #endregion

        #region Overrided methods

        /// <summary>
        /// Gets the item indent.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>System.Int32.</returns>
        public override int GetItemIndent(int itemIndex)
        {
            return GetIntNodeProperty(itemIndex, NodeIndentNeeded, levels[itemIndex] * ItemIndentDefault);
        }

        /// <summary>
        /// Gets the item expanded.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool GetItemExpanded(int itemIndex)
        {
            return expandedNodes.Contains(nodes[itemIndex]);
        }

        /// <summary>
        /// Determines whether this instance [can expand item] the specified item index.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if this instance [can expand item] the specified item index; otherwise, <c>false</c>.</returns>
        protected override bool CanExpandItem(int itemIndex)
        {
            return GetBoolNodeProperty(itemIndex, CanExpandNodeNeeded, hasChildren[itemIndex]);
        }

        /// <summary>
        /// This method is used only for programmatically expanding.
        /// For GUI expanding - use CanExpandItem
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns><c>true</c> if this instance [can expand node] the specified node; otherwise, <c>false</c>.</returns>
        protected virtual bool CanExpandNode(object node)
        {
            if (CanExpandNodeNeeded != null)
            {
                boolArg.Node = node;
                boolArg.Result = true;
                CanExpandNodeNeeded(this, boolArg);
                return boolArg.Result;
            }

            return true;
        }

        /// <summary>
        /// Checks the item.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public override bool CheckItem(int itemIndex)
        {
            if (GetItemChecked(itemIndex))
                return true;

            Invalidate();

            if (CanCheckItem(itemIndex))
            {
                if (NodeCheckStateNeeded == null)//add to CheckedItemIndex only if handler of NodeCheckStateNeeded is not assigned
                    CheckedItemIndex.Add(itemIndex);
                OnItemChecked(itemIndex);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is item height fixed.
        /// </summary>
        /// <value><c>true</c> if this instance is item height fixed; otherwise, <c>false</c>.</value>
        protected override bool IsItemHeightFixed
        {
            get
            {
                return NodeHeightNeeded == null;
            }
        }

        /// <summary>
        /// Draws the drag over insert effect.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="e">The <see cref="DragOverItemEventArgs" /> instance containing the event data.</param>
        protected override void DrawDragOverInsertEffect(Graphics gr, DragOverItemEventArgs e)
        {
            var c1 = Color.FromArgb(255, SelectionColor);
            var c2 = Color.Transparent;
            var c3 = BackColor;

            if (!visibleItemInfos.ContainsKey(e.ItemIndex))
                return;

            gr.ResetClip();
            var info = visibleItemInfos[e.ItemIndex];
            var rect = new Rectangle(info.X_ExpandBox + 1, info.Y, 10000, info.Height);
            if (e.ItemIndex <= 0)
                rect.Offset(0, 2);

            switch (e.InsertEffect)
            {
                case InsertEffect.Replace:
                    using (var brush = new SolidBrush(c1))
                        gr.FillRectangle(brush, rect);
                    break;

                case InsertEffect.InsertBefore:
                    rect.Offset(0, -rect.Height / 2 - ItemInterval - 1);
                    DrawDragDropMarker(gr, rect, c1, c2, c3);
                    break;

                case InsertEffect.InsertAfter:
                    rect.Offset(0, rect.Height / 2);
                    DrawDragDropMarker(gr, rect, c1, c2, c3);
                    break;

                case InsertEffect.AddAsChild:
                    if (e.ItemIndex >= 0 && e.ItemIndex < ItemCount)
                    {
                        var dx = GetItemIndent(e.ItemIndex) + ItemIndentDefault;
                        var r = new Rectangle(dx, rect.Y + rect.Height / 2, rect.Width, rect.Height);
                        DrawDragDropMarker(gr, r, c1, c2, c3);
                        using (var pen = new Pen(c1))
                            gr.DrawLines(pen, new PointF[] { new Point(r.Left, r.Top + r.Height / 2), new Point(rect.Left + 8, r.Top + r.Height / 2), new Point(rect.Left + 8, r.Top + r.Height / 2 - 5) });
                    }
                    break;
            }
        }

        /// <summary>
        /// Draws the drag drop marker.
        /// </summary>
        /// <param name="gr">The gr.</param>
        /// <param name="rect">The rect.</param>
        /// <param name="c1">The c1.</param>
        /// <param name="c2">The c2.</param>
        /// <param name="c3">The c3.</param>
        private static void DrawDragDropMarker(Graphics gr, Rectangle rect, Color c1, Color c2, Color c3)
        {
            var h = rect.Height;
            using (var brush = new LinearGradientBrush(rect, Color.Empty, Color.Empty, LinearGradientMode.Vertical))
            {
                brush.InterpolationColors = new ColorBlend()
                {
                    Positions = new float[] { 0, 0.2f, 0.8f, 1.0f },
                    Colors = new Color[] { c2, c3, c3, c2 }
                };
                gr.FillRectangle(brush, new RectangleF(0, rect.Top, rect.Width, rect.Height));
            }

            rect = new Rectangle(rect.Left, rect.Top + h / 2 - 2, 50, 4);
            using (var brush = new SolidBrush(c3))
            using (var pen = new Pen(c1))
            {
                gr.FillRectangle(brush, rect);
                gr.DrawRectangle(pen, rect);
            }
        }

        #endregion

        #region Event Helpers

        /// <summary>
        /// The int argument
        /// </summary>
        private IntNodeEventArgs intArg = new IntNodeEventArgs();
        /// <summary>
        /// The bool argument
        /// </summary>
        private BoolNodeEventArgs boolArg = new BoolNodeEventArgs();
        /// <summary>
        /// The string argument
        /// </summary>
        private StringNodeEventArgs stringArg = new StringNodeEventArgs();
        /// <summary>
        /// The image argument
        /// </summary>
        private ImageNodeEventArgs imageArg = new ImageNodeEventArgs();
        /// <summary>
        /// The align argument
        /// </summary>
        private StringAlignmentNodeEventArgs alignArg = new StringAlignmentNodeEventArgs();
        /// <summary>
        /// The color argument
        /// </summary>
        private ColorNodeEventArgs colorArg = new ColorNodeEventArgs();

        /// <summary>
        /// Gets the int node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int32.</returns>
        int GetIntNodeProperty(int itemIndex, EventHandler<IntNodeEventArgs> handler, int defaultValue)
        {
            if (handler != null)
            {
                intArg.Node = nodes[itemIndex];
                intArg.Result = defaultValue;
                handler(this, intArg);
                return intArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the string node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.String.</returns>
        string GetStringNodeProperty(int itemIndex, EventHandler<StringNodeEventArgs> handler, string defaultValue)
        {
            if (handler != null)
            {
                stringArg.Node = nodes[itemIndex];
                stringArg.Result = defaultValue;
                handler(this, stringArg);
                return stringArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the bool node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool GetBoolNodeProperty(int itemIndex, EventHandler<BoolNodeEventArgs> handler, bool defaultValue)
        {
            if (handler != null)
            {
                boolArg.Node = nodes[itemIndex];
                boolArg.Result = defaultValue;
                handler(this, boolArg);
                return boolArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the image node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Image.</returns>
        Image GetImageNodeProperty(int itemIndex, EventHandler<ImageNodeEventArgs> handler, Image defaultValue)
        {
            if (handler != null)
            {
                imageArg.Node = nodes[itemIndex];
                imageArg.Result = defaultValue;
                handler(this, imageArg);
                return imageArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the line alignment node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>StringAlignment.</returns>
        StringAlignment GetLineAlignmentNodeProperty(int itemIndex, EventHandler<StringAlignmentNodeEventArgs> handler, StringAlignment defaultValue)
        {
            if (handler != null)
            {
                alignArg.Node = nodes[itemIndex];
                alignArg.Result = defaultValue;
                handler(this, alignArg);
                return alignArg.Result;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the color node property.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Color.</returns>
        Color GetColorNodeProperty(int itemIndex, EventHandler<ColorNodeEventArgs> handler, Color defaultValue)
        {
            if (handler != null)
            {
                colorArg.Node = nodes[itemIndex];
                colorArg.Result = defaultValue;
                handler(this, colorArg);
                return colorArg.Result;
            }

            return defaultValue;
        }

        #endregion Helpers
    }

    /// <summary>
    /// Class GenericNodeResultEventArgs.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.EventArgs" />
    public class GenericNodeResultEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>The node.</value>
        public object Node { get; internal set; }
        /// <summary>
        /// The result
        /// </summary>
        public T Result;
    }

    /// <summary>
    /// Class IntNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.Int32}" />
    public class IntNodeEventArgs : GenericNodeResultEventArgs<int>
    {
    }

    /// <summary>
    /// Class StringNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.String}" />
    public class StringNodeEventArgs : GenericNodeResultEventArgs<string>
    {
    }

    /// <summary>
    /// Class ImageNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.Drawing.Image}" />
    public class ImageNodeEventArgs : GenericNodeResultEventArgs<Image>
    {
    }

    /// <summary>
    /// Class StringAlignmentNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.Drawing.StringAlignment}" />
    public class StringAlignmentNodeEventArgs : GenericNodeResultEventArgs<StringAlignment>
    {
    }

    /// <summary>
    /// Class ColorNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.Drawing.Color}" />
    public class ColorNodeEventArgs : GenericNodeResultEventArgs<Color>
    {
    }

    /// <summary>
    /// Class BoolNodeEventArgs.
    /// </summary>
    /// <seealso cref="Zeroit.Framework.MiscControls.GenericNodeResultEventArgs{System.Boolean}" />
    public class BoolNodeEventArgs : GenericNodeResultEventArgs<bool>
    {
    }

    /// <summary>
    /// Class NodeCheckedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeCheckedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The node
        /// </summary>
        public object Node;
        /// <summary>
        /// The checked
        /// </summary>
        public bool Checked;
    }

    /// <summary>
    /// Class NodeExpandedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeExpandedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The node
        /// </summary>
        public object Node;
        /// <summary>
        /// The expanded
        /// </summary>
        public bool Expanded;
    }

    /// <summary>
    /// Class NodeSelectedStateChangedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeSelectedStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The node
        /// </summary>
        public object Node;
        /// <summary>
        /// The selected
        /// </summary>
        public bool Selected;
    }

    /// <summary>
    /// Class NodeTextPushedEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeTextPushedEventArgs : EventArgs
    {
        /// <summary>
        /// The node
        /// </summary>
        public object Node;
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
    }

    /// <summary>
    /// Class PaintNodeContentEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class PaintNodeContentEventArgs : EventArgs
    {
        /// <summary>
        /// The graphics
        /// </summary>
        public Graphics Graphics;
        /// <summary>
        /// The information
        /// </summary>
        public ZeroitFastListBase.VisibleItemInfo Info;
        /// <summary>
        /// The node
        /// </summary>
        public object Node;
    }

    /// <summary>
    /// Class NodeDragEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeDragEventArgs : EventArgs
    {
        /// <summary>
        /// The nodes
        /// </summary>
        public HashSet<object> Nodes;
    }

    /// <summary>
    /// Class NodeChildrenNeededEventArgs.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class NodeChildrenNeededEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>The node.</value>
        public object Node { get; internal set; }
        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>The children.</value>
        public IEnumerable Children { get; set; }
    }
}
