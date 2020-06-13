/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Reflection;

namespace DCoreyDuke.CodeBase
{
    [ComplexType, Serializable]
    public sealed class MimeType
    {
        public MimeType()
        {
            ContentType = string.Empty;
            FileExtension = string.Empty;
            Description = string.Empty;
        }

        public MimeType(string contentType, string fileExtension, string description)
        {
            ContentType = contentType;
            FileExtension = fileExtension;
            Description = description;
        }

        public string ContentType { get; set; }

        public string Description { get; set; }

        public string FileExtension { get; set; }
    }

    public sealed class MimeTypes
    {
        private readonly string _MimeTypesFile = @"data\MimeTypes.csv";

        public MimeTypes()
        {
        }

        public MimeType GetMimeType(string fileExtension)
        {
            return GetMimeTypes().Find(m => m.FileExtension == fileExtension);
        }

        public List<MimeType> GetMimeTypes()
        {
            string path = Path.Combine(this.GetDir(), this._MimeTypesFile);

            if (!System.IO.File.Exists(path))
            {
                throw new Exception("MimeTypes.csv was not found!");
            }

            List<MimeType> l = new List<MimeType>();

            using (var rdr = new StreamReader(path))
            {
                while (!rdr.EndOfStream)
                {
                    var line = rdr.ReadLine().Split(',');
                    MimeType m = new MimeType(line[0].Trim(), line[1].Trim(), line[2].Trim());
                    l.Add(m);
                }
            }

            return l;
        }

        private string GetDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}