/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://praisebase.org
 *
 *   This program is free software; you can redistribute it and/or
 *   modify it under the terms of the GNU General Public License
 *   as published by the Free Software Foundation; either version 2
 *   of the License, or (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program; if not, write to the Free Software
 *   Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 */

using System.Windows.Forms;
using PraiseBase.Presenter.Manager;

namespace PraiseBase.Presenter.UI.Presenter
{
    public partial class LoadingScreen : Form
    {
        public bool ShowSongLoading { get; set; }

        public LoadingScreen(SongManager songManager)
        {
            InitializeComponent();
            if (ShowSongLoading)
            {
                songManager.SongLoaded += SongManager_SongLoaded;
            }
            ImageManager.Instance.ThumbnailCreated += ImageManager_ThumbnailCreated;
        }

        private void SongManager_SongLoaded(SongManager.SongLoadEventArgs e)
        {
            SetLabel("Lade Lieder " + e.Number + "/" + e.Total);
        }

        void  ImageManager_ThumbnailCreated(ImageManager.ThumbnailCreateEventArgs e)
        {
            SetLabel("Erstelle Miniaturbilder " + e.Number + "/" + e.Total);
        }

        public void SetLabel(string message)
        {
            label1.Text = message;
            Application.DoEvents();
        }
    }
}