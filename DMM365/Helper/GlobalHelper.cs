using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DMM365.DataContainers;
using static System.Windows.Forms.CheckedListBox;

namespace DMM365.Helper
{
    public static class GlobalHelper
    {

        public static bool isValidString(string source)
        {
            return !string.IsNullOrEmpty(source) && !string.IsNullOrWhiteSpace(source);
        }

        public static void copyObjectProperies<T>(T source, T target)
        {
            var sourceProperties = source.GetType().GetProperties();
            var targetProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var targetProperty in targetProperties)
                {
                    if (sourceProperty.Name == targetProperty.Name && sourceProperty.PropertyType == targetProperty.PropertyType)
                    {
                        targetProperty.SetValue(target, sourceProperty.GetValue(source));
                        break;
                    }
                }
            }
        }

        public static List<T> copyCollection<T>(List<T> source)
        {
            return new List<T>(source);
        }

        public static List<SchemaField> getCommonOOBfileds(List<SchemaEntity> source)
        {
            if (source.Count == 1) return source[0].fields;
            IEnumerable<SchemaField> common = new List<SchemaField>();

            for (int i = 0; i < source.Count; i++)
            {
                if ((i + 1) == source.Count) break;

                common = source[i].fields.Intersect(source[i + 1].fields, new FieldSchemaEqualityComparers());

            }
            return common.ToList();
        }

        public static string checkedListToStringEntity(CheckedItemCollection cbx)
        {
            string result = string.Empty;
            List<SchemaEntity> se = cbx.Cast<SchemaEntity>().ToList();
            se.ForEach(s => {
                result += ("'" + s.name + "',");
            });
            //delete last coma
            return result.Substring(0, result.Length - 1);
        }

        public static string checkedListToStringFields(CheckedItemCollection cbx)
        {
            string result = string.Empty;
            List<SchemaField> se = cbx.Cast<SchemaField>().ToList();
            se.ForEach(s => {
                result += ("'" + s.name + "',");
            });
            //delete last coma
            return result.Substring(0, result.Length - 1);
        }

        public static void setItemChecked(CheckedListBox cbxList, Array selected, bool isSelected)
        {
            foreach (var item in selected)
            {
                int index = cbxList.Items.IndexOf(item);
                if (index != -1) cbxList.SetItemChecked(index, isSelected);
            }
        }

        public static void setCheckEntitiesListItemByName(CheckedListBox cbxList, string[] selected)
        {
            List<SchemaEntity> se = cbxList.Items.Cast<SchemaEntity>().ToList();
            
            foreach (string item in selected)
            {
                SchemaEntity current = se.FirstOrDefault(x => x.name == item);
                if (!ReferenceEquals(current, null))
                    cbxList.SetItemChecked(cbxList.Items.IndexOf(current), true);
            }
            //foreach (object item in cbxList.Items)
            //{
            //    PropertyInfo prop = item.GetType().GetProperty("name");
            //    if (ReferenceEquals(prop, null)) continue;
            //    if( prop.GetValue(item)
            //}
            
        }

        public static void setCheckFieldsListItemByName(CheckedListBox cbxList, string[] selected)
        {
            List<SchemaField> se = cbxList.Items.Cast<SchemaField>().ToList();

            foreach (string item in selected)
            {
                SchemaField current = se.FirstOrDefault(x => x.name == item);
                if (!ReferenceEquals(current, null))
                    cbxList.SetItemChecked(cbxList.Items.IndexOf(current), true);
            }
        }

        public static void clearCkeckedListBox(CheckedListBox cbxList)
        {
            foreach (int i in cbxList.CheckedIndices)
                cbxList.SetItemCheckState(i, CheckState.Unchecked);
        }

        public static string listboxToString(ListBox.ObjectCollection lst)
        {
            string result = string.Empty;
            List<SchemaEntity> se = lst.Cast<SchemaEntity>().ToList();
            se.ForEach(s => {
                result += ("'" + s.name + "',");
            });
            //delete last coma
            return result.Substring(0, result.Length - 1);
        }

        public static SchemaField getFieldFromSchema(SchemaEntities entities, string entityName, string fieldName)
        {
            SchemaEntity entity = entities.entities.FirstOrDefault(e => e.name == entityName);
            if (ReferenceEquals(entity, null)) return null;

            SchemaField field = entity.fields.FirstOrDefault(f => f.name == fieldName);
            if (ReferenceEquals(field, null)) return null;

            return field;
        }
    }
}
