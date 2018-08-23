using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DMM365.DataContainers
{
    public class AllSettings : INotifyPropertyChanged
    {

        #region Constractors

        public AllSettings() { }


        #endregion Constractors


        #region Global Flags

        bool _isDirty = false;
        bool _isSameOrg = false;
        [XmlIgnore]
        public bool IsDirty
        {
            get
            {
                return this._isDirty;
            }

            set
            {
                if (value != this._isDirty)
                {
                    this._isDirty = value;
                    NotifyPropertyChanged("IsDirty");
                }
            }
        }


        public bool IsSameOrg
        {
            get
            {
                return this._isSameOrg;
            }

            set
            {
                if (value != this._isSameOrg)
                {
                    this._isSameOrg = value;
                    NotifyPropertyChanged("IsSameOrg");
                }
            }
        }


        #endregion Global Flags


        #region Project Settings

        string _projectPath = string.Empty;
        public string ProjectPath
        {
            get
            {
                return this._projectPath;
            }

            set
            {
                if (value != this._projectPath)
                {
                    this._projectPath = value;
                    NotifyPropertyChanged("ProjectPath");
                }
            }
        }

        #endregion Project Settings


        #region Connection Source Settings

        string _orgUniqueNameSource = string.Empty;
        string _serverUrlSource = string.Empty;
        string _usernameSource = string.Empty;
        string _passwordSource = string.Empty;
        public string OrgUniqueNameSource
        {
            get { return _orgUniqueNameSource; }
            set
            {
                if (value != this._orgUniqueNameSource)
                {
                    this._orgUniqueNameSource = value;
                    this.IsDirty = true;
                    NotifyPropertyChanged("OrgUniqueNameSource");
                }
            }
        }
        public string ServerUrlSource {
            get { return _serverUrlSource; }
            set
            {
                if (value != this._serverUrlSource)
                {
                    this._serverUrlSource = value;
                    this.IsDirty = true;
                    NotifyPropertyChanged("ServerUrlSource");
                }
            }
        }
        public string UsernameSource {
            get { return _usernameSource; }
            set
            {
                if (value != this._usernameSource)
                {
                    this._usernameSource = value;
                    this.IsDirty = true;
                    NotifyPropertyChanged("UsernameSource");
                }
            }
        }

        [XmlIgnore]
        public string PasswordSource {
            get { return _passwordSource; }
            set
            {
                if (value != this._passwordSource)
                {
                    this._passwordSource = value;
                    NotifyPropertyChanged("PasswordSource");
                }
            }
        }


        #endregion Connection Source Settings


        #region Views Settings


        public string SelectedViewsActionOperator { get;set; }


        public List<Guid> SelectedUserQueries { get; set; }


        #endregion Views Settings


        #region Copy Tool

        bool _replaceIDs = true;
        public bool ReplaceIDs
        {
            get { return _replaceIDs; }
            set
            {
                if (value != this._replaceIDs)
                {
                    this._replaceIDs = value;
                    NotifyPropertyChanged("ReplaceIDs");
                }
            }
        }

        #endregion Copy Tool


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged

    }
}
