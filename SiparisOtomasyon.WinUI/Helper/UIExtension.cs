using SiparisOtomasyon.WinUI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyon.WinUI.Helper
{
    public static class UIExtension
    {
        public static void SetDataSourceFirstItem<Tvalue, TData>(this ComboBox combo,IEnumerable<TData> dataSource,string DisplayMember, string ValueMember, string FirstItemText) where Tvalue : struct where TData : class
        {
            
            
            List < KeyValue <Tvalue,TData > > newDataSource= new List<KeyValue< Tvalue, TData>> ();
            newDataSource.Add(new KeyValue<Tvalue, TData>() { Key = FirstItemText, Value = null, Data = null });

            foreach (var item in dataSource)
            {
                var key = (string)item.GetType().GetProperty(DisplayMember).GetValue(item);
                var value = (Tvalue)item.GetType().GetProperty(ValueMember).GetValue(item);
                //reflection yapıldı. Sadece ismi olan propertynin tüm özelliklerine erişmek. Araştır!!
                //Elimde nesne var hangi tipte olduğunu ve nerde olduğunu bilmiyorum. Önce tipi bul sonra nesnedeki propertyi bul ve onun değerini bul.
                //Ram de elimde bir nesne var ama sadece referans adresini biliyorum. Bu referans adresinden nesneyle ilgili herşeye erişilebilir.
                newDataSource.Add(new KeyValue<Tvalue,TData>() { Key = key, Value = value, Data = item });
                
            }
            
            combo.DataSource= newDataSource;
            combo.DisplayMember = "Key";
            combo.ValueMember = "Value";

             
        }
         public static void SetSelectedValue(this ComboBox combo,object value)
        {
            if (value != null)
            {
                combo.SelectedValue=value;
            }
        }


        /// <summary>
        /// combobox üzerinde eğer bir datasource atanmış ise bu metod ile unboxing yapılmadan değeri geri okunabilir.
        /// </summary>
        /// <typeparam name="Tvalue"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="combo"></param>
        /// <returns></returns>
        public static Tvalue? GetValue<Tvalue, TData>(this ComboBox combo) where Tvalue : struct where TData:class
        {
            return ((combo.DataSource as List<KeyValue<Tvalue, TData>>)[combo.SelectedIndex]).Value;
        }

    }
}
