using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Ezfx.Csv
{
    public class CsvConfigCollection : ObservableCollection<CsvConfig>
    {
        public CsvConfigCollection()
        {
            PropertyChanged += new PropertyChangedEventHandler(CsvConfigs_PropertyChanged);
            CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CsvConfigs_CollectionChanged);
        }

        void CsvConfigs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsChanged = true;
        }

        void CsvConfigs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            IsChanged = true;
        }

        public bool IsChanged { get; set; }

        /// <summary>
        /// null if not found
        /// </summary>
        /// <param name="csvType"></param>
        /// <returns></returns>
        public CsvConfig GetConfig(string csvType)
        {
            foreach (CsvConfig config in this)
            {
                if (config.ObjectType == csvType)
                {
                    return config;
                }
            }
            return null;
        }

        public CsvConfig this[string csvType]
        {
            get
            {
                foreach (CsvConfig config in this)
                {
                    if (config.ObjectType == csvType)
                    {
                        return config;
                    }
                }
                throw new CsvException();
            }
            set
            {
                for (int i = 0; i < this.Count; i++)// CsvConfig config in this)
                {
                    if (this[i].ObjectType == csvType)
                    {
                        this[i] = value;
                        return;
                    }
                }
                throw new CsvException();
            }
        }
    }

    public class CsvConfig : INotifyPropertyChanged
    {
        const int UNICODE_CODEPAGE = 1200;

        #region Properties
        private string _Name = string.Empty;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        private bool _HasHeader;
        public bool HasHeader
        {
            get { return _HasHeader; }
            set
            {
                if (_HasHeader != value)
                {
                    _HasHeader = value;
                    NotifyPropertyChanged("HasHeader");
                }
            }
        }

        private bool _IsCustomized;
        public bool IsCustomized
        {
            get { return _IsCustomized; }
            set
            {
                if (_IsCustomized != value)
                {

                    _IsCustomized = value;
                    NotifyPropertyChanged("IsCustomized");
                }
            }
        }

        private CsvMappingType _MappingType;
        public CsvMappingType MappingType
        {
            get { return _MappingType; }
            set
            {
                if (_MappingType != value)
                {

                    _MappingType = value;
                    NotifyPropertyChanged("MappingType");
                }
            }
        }

        public Collection<CsvColumn> Columns { get; set; }

        public bool IsChanged { get; set; }
        #endregion
        /// <summary>
        /// CSV Class that this Config applied to.
        /// </summary>
        public string ObjectType { get; set; }

        private int _CodePage = Encoding.Default.CodePage;
        public int CodePage
        {
            get
            {
                return _CodePage;
            }
            set
            {
                if (_CodePage != value)
                {
                    _CodePage = value;
                    NotifyPropertyChanged("CodePage");
                }
            }
        }

        private string _Delimiter = ",";
        public string Delimiter
        {
            get
            {
                return _Delimiter;
            }
            set
            {
                if (_Delimiter != value)
                {
                    _Delimiter = value;
                    NotifyPropertyChanged("Delimiter");
                }
            }
        }

        public string EncodingName
        {
            get
            {
                return Encoding.GetEncoding(CodePage).EncodingName;
            }
            set
            {
                foreach (EncodingInfo encoding in Encoding.GetEncodings())
                {
                    if (encoding.DisplayName == value
                        || encoding.Name == value)
                    {
                        CodePage = encoding.CodePage;
                        return;
                    }
                }
                throw new CsvEncodingNotFoundException();
            }
        }

        public CsvConfig()
        {
            this.HasHeader = true;
            this.Columns = new ObservableCollection<CsvColumn>();
            this.MappingType = CsvMappingType.Title;
            this.CodePage = Encoding.Default.CodePage;
            this.IsChanged = false;
            PropertyChanged += new PropertyChangedEventHandler(CsvConfig_PropertyChanged);
        }

        public CsvConfig(Type csvType)
            : this()
        {
            CsvObjectAttribute objAttr = csvType.GetAttribute<CsvObjectAttribute>();
            if (objAttr != null)
            {
                this.CodePage = objAttr.CodePage;
                this.HasHeader = objAttr.HasHeader;
                this.MappingType = objAttr.MappingType;
                this.Delimiter = objAttr.Delimiter;
                this.Name = objAttr.Name;
                this.ObjectType = csvType.Name + ", " + csvType.Assembly.GetName().Name;
            }
            else
            {
                this.Name = csvType.Name;
            }

            this.IsChanged = false;

            this.Columns.Clear();
            foreach (PropertyInfo pi in csvType.GetProperties())
            {
                SystemCsvColumnAttribute colAttr = pi.GetAttribute<SystemCsvColumnAttribute>();
                if (colAttr != null)
                {
                    this.Columns.Add(colAttr.Column);
                }
            }
        }

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        void CsvConfig_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsChanged = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Static
        static CsvConfig _default = null;
        public static CsvConfig Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new CsvConfig();
                }
                return _default;
            }
        }
        #endregion

        public bool ContainsColumn(string name)
        {
            foreach (CsvColumn col in this.Columns)
            {
                if (col.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetAlias(string name)
        {
            foreach (CsvColumn col in this.Columns)
            {
                if (col.Name == name)
                {
                    return col.Alias;
                }
            }
            throw new CsvNameNotFoundException();
        }
    }
}
