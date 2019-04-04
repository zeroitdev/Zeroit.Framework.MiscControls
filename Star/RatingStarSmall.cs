// ***********************************************************************
// Assembly         : Zeroit.Framework.MiscControls
// Author           : ZEROIT
// Created          : 11-22-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-19-2018
// ***********************************************************************
// <copyright file="RatingStarSmall.cs" company="Zeroit Dev Technologies">
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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Zeroit.Framework.MiscControls
{
    #region Rating Star Small

    #region Control

    /// <summary>
    /// A class collection for rendering a rating control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Panel" />
    public class ZeroitSmallRating : Panel
    {
        /// <summary>
        /// The components
        /// </summary>
        private Container _components;

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <value>The width.</value>
        public new int Width { get; private set; }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <value>The height.</value>
        public new int Height { get; private set; }

        /// <summary>
        /// The off image
        /// </summary>
        private Image _offImage;

        /// <summary>
        /// Sets the off image.
        /// </summary>
        /// <value>The off image.</value>
        public Image OffImage
        {
            set
            {
                _offImage = value;
                SetUpStars();
            }
        }

        /// <summary>
        /// The on images
        /// </summary>
        private List<Image> _onImages;

        /// <summary>
        /// Sets the on images.
        /// </summary>
        /// <value>The on images.</value>
        public List<Image> OnImages
        {
            set
            {
                _onImages = value;
                SetUpStars();
            }
        }

        /// <summary>
        /// The star count
        /// </summary>
        private int _starCount;

        /// <summary>
        /// Gets or sets the star count.
        /// </summary>
        /// <value>The star count.</value>
        public int StarCount
        {
            get { return _starCount; }
            set
            {
                _starCount = value;
                SetUpStars();
            }
        }

        /// <summary>
        /// The current star value
        /// </summary>
        private int _currentStarValue;

        /// <summary>
        /// Gets or sets the current star value.
        /// </summary>
        /// <value>The current star value.</value>
        public int CurrentStarValue
        {
            get { return _currentStarValue; }
            set
            {
                _currentStarValue = value;
                DrawCurrentState(_currentStarValue, true);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZeroitSmallRating" /> class.
        /// </summary>
        public ZeroitSmallRating()
        {
            Height = 0;
            Width = 0;
            InitializeComponent();
            SetFlickerFreePainting();

            _offImage = new Bitmap(GetType(), "Resources.StarOff.bmp");
            _onImages = LoadDefaultImages();
            _starCount = 5;

            SetUpStars();
        }

        /// <summary>
        /// Sets up stars.
        /// </summary>
        private void SetUpStars()
        {
            AddTheStars();
            DrawCurrentState(_currentStarValue, false);
            SetControlSize();
        }

        /// <summary>
        /// Adds the stars.
        /// </summary>
        private void AddTheStars()
        {
            Controls.Clear();
            for (var x = 0; x < _starCount; x++)
            {
                Controls.Add(new Star(x + 1, _offImage, _onImages, _onImages[Math.Min(_onImages.Count - 1, x)],
                                      starNumber => _currentStarValue = _currentStarValue == starNumber ? 0 : starNumber,
                                      starNumber => DrawCurrentState(starNumber, false),
                                      () => DrawCurrentState(_currentStarValue, true)
                                 ));
            }
        }

        /// <summary>
        /// Draws the state of the current.
        /// </summary>
        /// <param name="starNumber">The star number.</param>
        /// <param name="useFinal">if set to <c>true</c> [use final].</param>
        private void DrawCurrentState(int starNumber, bool useFinal)
        {
            Controls.Cast<Star>().ToList().ForEach(s => s.ToggleStar(starNumber, useFinal));
        }

        /// <summary>
        /// Sets the size of the control.
        /// </summary>
        private void SetControlSize()
        {
            base.Width = Width = _offImage.Width * _starCount;
            base.Height = Height = _offImage.Height;
        }

        /// <summary>
        /// Loads the default images.
        /// </summary>
        /// <returns>List&lt;Image&gt;.</returns>
        private List<Image> LoadDefaultImages()
        {
            var red = new Bitmap(GetType(), "Resources.StarOnRed.bmp");
            var blue = new Bitmap(GetType(), "Resources.StarOnBlue.bmp");
            var green = new Bitmap(GetType(), "Resources.StarOnGreen.bmp");
            return new List<Image> { red, red, blue, green, green };
        }

        /// <summary>
        /// Sets the flicker free painting.
        /// </summary>
        private void SetFlickerFreePainting()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        /// <summary>
        /// Performs the work of setting the specified bounds of this control.
        /// </summary>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left" /> property value of the control.</param>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top" /> property value of the control.</param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width" /> property value of the control.</param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height" /> property value of the control.</param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified" /> values.</param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Width, Height, specified);
        }

        #region Component Designer generated code

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }

    #endregion

    #region Star PictureBox

    /// <summary>
    /// A class collection for rendering a star control.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.PictureBox" />
    [ToolboxItem(false)]
    public class Star : PictureBox
    {
        /// <summary>
        /// The components
        /// </summary>
        private Container _components;
        /// <summary>
        /// Gets the star number.
        /// </summary>
        /// <value>The star number.</value>
        public int StarNumber { get; private set; }

        /// <summary>
        /// The clicked
        /// </summary>
        private readonly Action<int> _clicked;
        /// <summary>
        /// The mouse enter
        /// </summary>
        private readonly Action<int> _mouseEnter;
        /// <summary>
        /// The mouse leave
        /// </summary>
        private readonly Action _mouseLeave;
        /// <summary>
        /// The on images
        /// </summary>
        private readonly List<Image> _onImages;
        /// <summary>
        /// The off image
        /// </summary>
        private readonly Image _offImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Star"/> class.
        /// </summary>
        /// <param name="starNumber">The star number.</param>
        /// <param name="offImage">The off image.</param>
        /// <param name="onImages">The on images.</param>
        /// <param name="onImage">The on image.</param>
        /// <param name="clicked">The clicked.</param>
        /// <param name="mouseEnter">The mouse enter.</param>
        /// <param name="mouseLeave">The mouse leave.</param>
        internal Star(int starNumber, Image offImage, List<Image> onImages, Image onImage, Action<int> clicked, Action<int> mouseEnter, Action mouseLeave)
        {
            Size = new Size(offImage.Width, offImage.Height);
            Left = (Width * (starNumber - 1));

            _onImages = onImages;
            _offImage = offImage;
            StarNumber = starNumber;
            Image = _offImage;

            _clicked = clicked;
            _mouseEnter = mouseEnter;
            _mouseLeave = mouseLeave;


            InitializeComponent();
        }

        /// <summary>
        /// Toggles the star.
        /// </summary>
        /// <param name="selectedStar">The selected star.</param>
        /// <param name="useFinal">if set to <c>true</c> [use final].</param>
        public void ToggleStar(int selectedStar, bool useFinal)
        {
            Image = StarNumber > selectedStar ? _offImage : (_onImages[Math.Min(_onImages.Count, useFinal ? selectedStar : StarNumber) - 1]);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseEnter(StarNumber);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseLeave();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            _clicked(StarNumber);
        }

        #region Component Designer generated code

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            _components = new System.ComponentModel.Container();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.PictureBox" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release managed and unmanaged resources; false to release unmanaged resources only.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }

    #endregion

    #endregion
}
