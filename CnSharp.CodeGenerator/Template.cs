using System;
using System.Collections.Generic;
using System.ComponentModel;
using CnSharp.Serialization;

namespace CnSharp.CodeGenerator
{
    [Serializable]
    public class Template
    {
        #region Constants and Fields

        private string _author;

        private DateTime _createTime = DateTime.Now;

        private string _description;

        private string _language;

        private string _languageVersion;

        private DateTime _lastModifyTime;

        private bool _modified;

        private string _name = "New Template";

        private List<OutputOption> _options = new List<OutputOption>();

        private SourceType _sourceType = SourceType.Table;

        private List<TemplateFile> _templateFiles = new List<TemplateFile>();

        private string _version = "1.0.0.0";

        #endregion

        #region Public Properties

        [Category("Descriptions")]
        [Description("Author")]
        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                _modified = true;
            }
        }

        [Category("Version")]
        [Description("Template CreateTime")]
        public DateTime CreateTime
        {
            get => _createTime;
            set
            {
                _createTime = value;
                _modified = true;
            }
        }

        [Category("Descriptions")]
        [Description("Template Description")]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                _modified = true;
            }
        }

        [Category("Descriptions")]
        [Description("Target language to generate")]
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                _modified = true;
            }
        }

        [Category("Descriptions")]
        [Description("Supported version of target language")]
        public string LanguageVersion
        {
            get => _languageVersion;
            set
            {
                _languageVersion = value;
                _modified = true;
            }
        }

        //private string extension;

        //[CategoryAttribute("Descriptions"), Description("File extension of target language")]
        //public string Extension
        //{
        //    get { return extension; }
        //    set { extension = value; modified = true; }
        //}

        [Category("Version")]
        [Description("Template last modify time")]
        public DateTime LastModifyTime
        {
            get => _lastModifyTime < _createTime ? _createTime : _lastModifyTime;
            set
            {
                _lastModifyTime = value;
                _modified = true;
            }
        }

        [Browsable(false)] public bool Modified => _modified;

        [Category("Descriptions")]
        [Description("Template Name")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                _modified = true;
            }
        }
        

        [Category("Options")]
        [Description("Code Options")]
        [Browsable(false)]
        public List<OutputOption> Options
        {
            get => _options;
            set
            {
                _options = value;
                _modified = true;
            }
        }

        [Browsable(false)] public List<string> Resources { get; set; } = new List<string>();

        [Category("Options")]
        [Description("Source type(table/stored procedure)")]
        public SourceType SourceType
        {
            get => _sourceType;
            set
            {
                _sourceType = value;
                _modified = true;
            }
        }

        [Browsable(false)]
        public List<TemplateFile> TemplateFiles
        {
            get => _templateFiles;
            set => _templateFiles = value;
        }

        [Category("Version")]
        [Description("Template Version")]
        public string Version
        {
            get => _version;
            set
            {
                _version = value;
                _modified = true;
            }
        }

        #endregion

        //[CategoryAttribute("Files"), Description("Template include files")]
        //public List<string> IncludeFiles { get; set; }

        #region Public Methods

        public void AddFile(TemplateFile file)
        {
            foreach (var item in _templateFiles)
            {
                if (string.Compare(file.Path, item.Path, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    throw new Exception("File path is already exists!");
                }
            }

            _templateFiles.Add(file);
            _modified = true;
        }

        public void Save(string fileName)
        {
            XmlSerializationHelper.SerializeToXmlFile(this, fileName);
            _modified = false;
        }

        public void SetModified(bool hasModified)
        {
            _modified = hasModified;
        }

        #endregion
    }

    public enum SourceType
    {
        Database,

        Table,

        StoredProcedure
    }
}