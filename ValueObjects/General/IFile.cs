/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

namespace DCoreyDuke.CodeBase.ValueObjects.General
{
    using DCoreyDuke.CodeBase.Interfaces;
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum FileType
    {
        [Display(Name = "Code")]
        Code,

        [Display(Name = "Data")]
        Data,

        [Display(Name = "Document")]
        Document,

        [Display(Name = "Image")]
        Image,

        [Display(Name = "Video")]
        Video,

        [Display(Name = "Object")]
        Object,

        [Display(Name = "Settings")]
        Settings,

        [Display(Name = "Other")]
        Other
    }

    public interface IFile : IValueObject
    {
        string ContentType { get; set; }

        DateTime CreatedOn { get; set; }

        string FileName { get; set; }

        FileType FileType { get; set; }
    }

    public abstract class File : IFile
    {
        private File()
        {
        }

        protected File(string uniqueId, string fileName, string contentType, byte[] fileData, FileType fileType) : this()
        {
            UniqueId = uniqueId;
            FileName = fileName;
            ContentType = contentType;
            FileData = fileData;
            FileType = fileType;
            CreatedOn = DateTime.Now;
        }

        protected File(string uniqueId, string fileName, string contentType, byte[] fileData, FileType fileType, DateTime createdOn) : this()
        {
            UniqueId = uniqueId;
            FileName = fileName;
            ContentType = contentType;
            FileData = fileData;
            FileType = fileType;
            CreatedOn = createdOn;
        }

        public string ContentType { get; set; }

        public DateTime CreatedOn { get; set; }

        public byte[] FileData { get; set; }

        public string FileName { get; set; }

        public FileType FileType { get; set; }

        public string UniqueId { get; set; }
    }
}