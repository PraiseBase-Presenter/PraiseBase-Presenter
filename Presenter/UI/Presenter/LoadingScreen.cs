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

namespace PraiseBase.Presenter.Forms
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
            //SongManager.Instance.SongLoaded += new SongManager.SongLoad(SongManager_SongLoaded);
            ImageManager.Instance.ThumbnailCreated += new ImageManager.ThumbnailCreate(ImageManager_ThumbnailCreated);
        }

        private void SongManager_SongLoaded(SongManager.SongLoadEventArgs e)
        {
            this.setLabel("Lade Lieder " + e.Number + "/" + e.Total);
        }

        void  ImageManager_ThumbnailCreated(ImageManager.ThumbnailCreateEventArgs e)
        {
            this.setLabel("Erstelle Miniaturbilder " + e.Number + "/" + e.Total);
        }

        public void setLabel(string message)
        {
            label1.Text = message;
            Application.DoEvents();
        }
    }
}