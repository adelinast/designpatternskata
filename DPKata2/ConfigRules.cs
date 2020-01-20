using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPKata2
{
    public enum Action
    {
        NONE,
        ALLOW,
        BLOCK
    }
        public class ConfigRules
    {
        string _name;
        string[] _applications;
        string[] _fileTypes;
        Action _fileBlockAction;

        public void ConfigAntivirusRule(string Name)
        {
            _name = Name;
        }

        public void ConfigFileBlockingRule(string Name, string[] Applications, string[] FileTypes, Action Action)
        {
            _name = Name;
            _applications = Applications;
            _fileTypes = FileTypes;
            _fileBlockAction = Action;
        }
    }
}