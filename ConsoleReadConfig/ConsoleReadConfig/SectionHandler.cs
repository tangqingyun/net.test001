using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ConsoleReadConfig
{
    public class SectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("settings")]
       // [ConfigurationProperty("", Options = ConfigurationPropertyOptions.IsDefaultCollection)]
        public SettingCollection Settings
        {
            get { return (SettingCollection)this["settings"]; }
        }
    }

    [ConfigurationCollection(typeof(SettingElement), AddItemName = "setting", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class SettingCollection : ConfigurationElementCollection
    {
        public SettingElement this[int index]
        { 
            get{ 
                return (SettingElement)base.BaseGet(index);
            }
        }

        // 下面二个方法中抽象类中必须要实现的。
        protected override ConfigurationElement CreateNewElement() 
        { 
            return new SettingElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var settingElement = element as SettingElement;
            return settingElement != null ? settingElement.Name : "";
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override string ElementName
        {
            get { return "setting"; }
        }
    }

    public class SettingElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue="", IsRequired = true)]    
        public string Name {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("user", IsRequired = true)]    
        public string User
        {
            get { return this["user"] as string; }
        }

        [ConfigurationProperty("password", IsRequired = true)]    
        public string Password
        {
            get { return this["password"] as string; }
        }
    }

}
