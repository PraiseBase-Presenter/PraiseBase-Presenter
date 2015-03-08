using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PraiseBase.Presenter.Persistence
{
    public static class SongFilePluginFactory
    {
        private static Dictionary<Type, ISongFilePlugin> plugins = new Dictionary<Type, ISongFilePlugin>();

        private static Dictionary<String, HashSet<Type>> SupportedExtensionMapping = new Dictionary<string, HashSet<Type>>();

        /// <summary>
        /// A list of supported file name extensions
        /// </summary>
        public static List<String> SupportedExtensions { get { return SupportedExtensionMapping.Keys.ToList(); } }

        static SongFilePluginFactory()
        {
            var interfaceType = typeof(ISongFilePlugin);
            var AllTypes = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(x => x.GetTypes())
              .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            foreach (var atype in AllTypes)
            {
                ISongFilePlugin inst = (ISongFilePlugin)Activator.CreateInstance(atype);
                plugins.Add(atype, inst);
                if (!SupportedExtensionMapping.Keys.Contains(inst.GetFileExtension()))
                {
                    SupportedExtensionMapping.Add(inst.GetFileExtension(), new HashSet<Type>(new[] { atype }));
                }
                else
                {
                    SupportedExtensionMapping[inst.GetFileExtension()].Add(atype);
                }
            }
        }

        /// <summary>
        /// Returns a SongFileReader based on the requested type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ISongFilePlugin Create(Type type)
        {
            if (plugins[type] != null)
            {
                return plugins[type];
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a ISongFilePlugin based on the file name
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static ISongFilePlugin Create(string filename)
        {
            string ext = Path.GetExtension(filename);

            if (SupportedExtensionMapping[ext] != null)
            {
                foreach (Type t in SupportedExtensionMapping[ext])
                {
                    var reader = Create(t);
                    if (reader.IsFileSupported(filename))
                    {
                        return reader;
                    }
                }
            }
            throw new NotImplementedException();
        }

        public static List<ISongFilePlugin> GetPlugins()
        {
            return new List<ISongFilePlugin>(plugins.Values);
        }

        public static List<ISongFilePlugin> GetWriterPlugins()
        {
            List<ISongFilePlugin> list = new List<ISongFilePlugin>();
            foreach(ISongFilePlugin p in plugins.Values) 
            {
                if (p.IsWritingSupported())
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}
