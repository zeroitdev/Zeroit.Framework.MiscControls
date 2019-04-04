// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="FastTreeNode.cs" company="Zeroit Dev Technologies">
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
using System.Collections.Generic;
using System.Linq;

namespace Zeroit.Framework.MiscControls
{
    /// <summary>
    /// General tree data model
    /// </summary>
    [Serializable]
    public class ZeroitFastTreeNode
    {
        /// <summary>
        /// The childs
        /// </summary>
        protected readonly List<ZeroitFastTreeNode> childs = new List<ZeroitFastTreeNode>();

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public object Tag { get; set; }

        /// <summary>
        /// The parent
        /// </summary>
        private ZeroitFastTreeNode parent;
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public ZeroitFastTreeNode Parent
        {
            get { return parent; }
            set
            {
                if (parent == value)
                    return;

                SetParent(value);

                if(parent != null)
                    parent.childs.Add(this);
            }
        }

        /// <summary>
        /// Sets the parent.
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void SetParent(ZeroitFastTreeNode value)
        {
            if (parent != null && parent != value)
                parent.childs.Remove(this);

            parent = value;
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="node">The node.</param>
        public virtual void RemoveNode(ZeroitFastTreeNode node)
        {
            childs.Remove(node);
            SetParent(null);
        }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="node">The node.</param>
        public virtual void AddNode(ZeroitFastTreeNode node)
        {
            if(node.Parent != this)
                childs.Add(node);
            SetParent(this);
        }

        /// <summary>
        /// Inserts the node.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="node">The node.</param>
        public virtual void InsertNode(int index, ZeroitFastTreeNode node)
        {
            childs.Insert(index, node);
            SetParent(this);
        }

        /// <summary>
        /// Inserts the node before.
        /// </summary>
        /// <param name="existsNode">The exists node.</param>
        /// <param name="node">The node.</param>
        public virtual void InsertNodeBefore(ZeroitFastTreeNode existsNode, ZeroitFastTreeNode node)
        {
            var i = childs.IndexOf(existsNode);
            if (i < 0) i = 0;

            InsertNode(i, node);
        }

        /// <summary>
        /// Inserts the node after.
        /// </summary>
        /// <param name="existsNode">The exists node.</param>
        /// <param name="node">The node.</param>
        public virtual void InsertNodeAfter(ZeroitFastTreeNode existsNode, ZeroitFastTreeNode node)
        {
            var i = childs.IndexOf(existsNode) + 1;
            InsertNode(i, node);
        }

        /// <summary>
        /// Removes the node.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public virtual void RemoveNode(IEnumerable<ZeroitFastTreeNode> nodes)
        {
            var hash = new HashSet<ZeroitFastTreeNode>(nodes);
            var j = 0;
            for (int i = 0; i < childs.Count; i++)
            {
                if (hash.Contains(childs[i]))
                    j++;
                else
                    childs[i].SetParent(null);
                childs[i] = childs[i + j];
            }

            if(j > 0)
                childs.RemoveRange(childs.Count - j, j);
        }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public virtual void AddNode(IEnumerable<ZeroitFastTreeNode> nodes)
        {
            childs.AddRange(nodes);
            foreach(var node in nodes)
                node.SetParent(this);
        }

        /// <summary>
        /// Inserts the node.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="nodes">The nodes.</param>
        public virtual void InsertNode(int index, IEnumerable<ZeroitFastTreeNode> nodes)
        {
            childs.InsertRange(index, nodes);
            foreach (var node in nodes)
                node.SetParent(this);
        }

        /// <summary>
        /// Inserts the node before.
        /// </summary>
        /// <param name="existsNode">The exists node.</param>
        /// <param name="nodes">The nodes.</param>
        public virtual void InsertNodeBefore(ZeroitFastTreeNode existsNode,  IEnumerable<ZeroitFastTreeNode> nodes)
        {
            var i = childs.IndexOf(existsNode);
            if (i < 0)
                i = 0;

            InsertNode(i, nodes);
        }

        /// <summary>
        /// Inserts the node after.
        /// </summary>
        /// <param name="existsNode">The exists node.</param>
        /// <param name="nodes">The nodes.</param>
        public virtual void InsertNodeAfter(ZeroitFastTreeNode existsNode, IEnumerable<ZeroitFastTreeNode> nodes)
        {
            var i = childs.IndexOf(existsNode) + 1;
            InsertNode(i, nodes);
        }

        /// <summary>
        /// Indexes the of.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>System.Int32.</returns>
        public int IndexOf(ZeroitFastTreeNode node)
        {
            return childs.IndexOf(node);
        }

        /// <summary>
        /// Gets the childs.
        /// </summary>
        /// <value>The childs.</value>
        public IEnumerable<ZeroitFastTreeNode> Childs
        {
            get 
            {
                return childs;
            }
        }

        /// <summary>
        /// Gets the childs.
        /// </summary>
        /// <typeparam name="TagType">The type of the tag type.</typeparam>
        /// <returns>IEnumerable&lt;ZeroitFastTreeNode&gt;.</returns>
        public IEnumerable<ZeroitFastTreeNode> GetChilds<TagType>()
        {
            return GetChilds(t=>t is TagType);
        }

        /// <summary>
        /// Gets the childs.
        /// </summary>
        /// <param name="tagCondition">The tag condition.</param>
        /// <returns>IEnumerable&lt;ZeroitFastTreeNode&gt;.</returns>
        public IEnumerable<ZeroitFastTreeNode> GetChilds(Predicate<object> tagCondition)
        {
            return childs.Where(c=>tagCondition(c.Tag));
        }

        /// <summary>
        /// Gets all childs.
        /// </summary>
        /// <value>All childs.</value>
        public IEnumerable<ZeroitFastTreeNode> AllChilds
        {
            get
            {
                yield return this;

                foreach(var c in childs)
                    foreach (var cc in c.AllChilds)
                        yield return cc;
            }
        }

        /// <summary>
        /// Gets all childs.
        /// </summary>
        /// <typeparam name="TagType">The type of the tag type.</typeparam>
        /// <returns>IEnumerable&lt;ZeroitFastTreeNode&gt;.</returns>
        public IEnumerable<ZeroitFastTreeNode> GetAllChilds<TagType>()
        {
            return GetAllChilds(t => t is TagType);
        }

        /// <summary>
        /// Gets all childs.
        /// </summary>
        /// <param name="tagCondition">The tag condition.</param>
        /// <returns>IEnumerable&lt;ZeroitFastTreeNode&gt;.</returns>
        public IEnumerable<ZeroitFastTreeNode> GetAllChilds(Predicate<object> tagCondition)
        {
            return AllChilds.Where(c => tagCondition(c.Tag));
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <typeparam name="TagType">The type of the tag type.</typeparam>
        /// <returns>ZeroitFastTreeNode.</returns>
        public ZeroitFastTreeNode GetParent<TagType>()
        {
            return GetParent(t => t is TagType);
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <param name="tagCondition">The tag condition.</param>
        /// <returns>ZeroitFastTreeNode.</returns>
        public ZeroitFastTreeNode GetParent(Predicate<object> tagCondition)
        {
            var parent = Parent;
            while (parent != null && !tagCondition(parent.Tag))
                parent = parent.parent;
            return parent;
        }
    }
}
