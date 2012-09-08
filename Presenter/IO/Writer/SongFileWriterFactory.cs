/*
 *   PraiseBase Presenter
 *   The open source lyrics and image projection software for churches
 *
 *   http://code.google.com/p/praisebasepresenter
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
 *   Author:
 *      Nicolas Perrenoud <nicu_at_lavine.ch>
 *   Co-authors:
 *      ...
 *
 */

using System;
using System.Collections.Generic;
using Pbp.Data.Song;
using System.Reflection;
using System.Linq;

namespace Pbp.IO
{
    public class SongFileWriterFactory
    {
        public readonly Type PreferredType = typeof(PowerPraiseSongFileWriter);

        private Dictionary<Type, SongFileWriter> readers = new Dictionary<Type,SongFileWriter>();
        private Dictionary<String, HashSet<Type>> SupportedExtensionMapping = new Dictionary<string, HashSet<Type>>();

        /// <summary>
        /// A list of supported file name extensions
        /// </summary>
        public List<String> SupportedExtensions { get { return SupportedExtensionMapping.Keys.ToList(); } }

        /// <summary>
        /// Singleton variable
        /// </summary>
        private static SongFileWriterFactory _instance;

        /// <summary>
        /// Gets the singleton of this class (field alternative)
        /// </summary>
        public static SongFileWriterFactory Instance
        {
            get { return _instance ?? (_instance = new SongFileWriterFactory()); }
        }

        /// <summary>
        /// Initializes the available types and extensions
        /// </summary>
        private SongFileWriterFactory() 
        {
            IEnumerable<Type> AllTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(SongFileWriter)));
            foreach (var atype in AllTypes)
            {
                SongFileWriter inst = (SongFileWriter)Activator.CreateInstance(atype);
                readers.Add(atype, inst);
                if (! SupportedExtensionMapping.Keys.Contains(inst.FileExtension))
                {
                    SupportedExtensionMapping.Add(inst.FileExtension, new HashSet<Type>(new[] { atype }));
                }
                else
                {
                    SupportedExtensionMapping[inst.FileExtension].Add(atype);
                }
                Console.WriteLine("Loaded song writer: " + atype);
            }
        }

        public SongFileWriter CreateFactory(Type type)
        {
            if (readers[type] != null)
            {
                return readers[type];
            }            
            throw new NotImplementedException();
        }

        public SongFileWriter CreateFactoryByFile(string filename)
        {
            string ext = System.IO.Path.GetExtension(filename);

            if (SupportedExtensionMapping[ext] != null)
            {
                foreach (Type t in SupportedExtensionMapping[ext])
                {
                    return CreateFactory(t);
                }
            }
            throw new NotImplementedException();
        }

        public string GetFileBoxFilter()
        {
            String fltr = String.Empty;
            foreach (var t in readers.Values)
            {
                if (fltr != string.Empty)
                {
                    fltr += "|";
                }
                fltr += t.FileTypeDescription + " (*" + t.FileExtension + ")|*" + t.FileExtension;
            }
            return fltr;
        }
    }
}