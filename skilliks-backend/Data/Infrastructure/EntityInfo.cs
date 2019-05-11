using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Infrastructure
{
    public class EntityInfo<T>
    {
        public string Name
        {
            get
            {
                return typeof(T).Name;
            }
        }

        public string Key { get; private set; }

        public string RelacionalKey { get; private set; }

        public List<string> Properties { get; }

        public List<string> PropertiesForInsert { get; }

        public List<string> PropertiesorUpdate { get; }

        public List<string> Keys { get; }

        public EntityInfo()
        {
            Properties = new List<string>();
            PropertiesForInsert = new List<string>();
            PropertiesorUpdate = new List<string>();
            Keys = new List<string>();

            foreach (var propertie in typeof(T).GetProperties())
            {
                LoadProperty(propertie);
            }
        }


        private void LoadProperty(PropertyInfo propertie)
        {
            var name = propertie.Name;

            var category = propertie.CustomAttributes
                    .Where(x => x.AttributeType.Name.Equals("CategoryAttribute"))
                    .Select(x => x.ConstructorArguments.FirstOrDefault().Value)
                    .FirstOrDefault();

            switch (category)
            {
                case Domain.Constants.EntityPropertyCategory.Key:
                    LoadKey(name);
                    break;

                case Domain.Constants.EntityPropertyCategory.RelacionalKey:
                    LoadRelacionalKey(name);
                    break;

                case Domain.Constants.EntityPropertyCategory.ForeignKey:
                    LoadForeignKey(name);
                    break;

                case Domain.Constants.EntityPropertyCategory.InternalControl:
                    LoadInternalControl(name);
                    break;

                case Domain.Constants.EntityPropertyCategory.Model:
                    LoadModel(name);
                    break;

                default:
                    Properties.Add(name);
                    break;
            }
        }

        private void LoadKey(string name)
        {
            Properties.Add(name);
            Keys.Add(name);

            if (string.IsNullOrEmpty(Key)) Key = name;
            else throw new Exception(string.Format("The entity '{0}' must have only one key", Name));
        }

        private void LoadRelacionalKey(string name)
        {
            Properties.Add(name);
            Keys.Add(name);
            PropertiesForInsert.Add(name);

            if (string.IsNullOrEmpty(RelacionalKey)) RelacionalKey = name;
            else throw new Exception(string.Format("The entity '{0}' must have only one RelacionalKey", Name));
        }

        private void LoadForeignKey(string name)
        {
            Properties.Add(name);
            Keys.Add(name);
            PropertiesForInsert.Add(name);
        }

        private void LoadInternalControl(string name)
        {
            Properties.Add(name);
            PropertiesForInsert.Add(name);
        }

        private void LoadModel(string name)
        {
            Properties.Add(name);
            PropertiesForInsert.Add(name);
            PropertiesorUpdate.Add(name);
        }

    }
}
