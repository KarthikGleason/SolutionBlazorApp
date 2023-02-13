using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryBlazorApp_Models.LearnBlazorModels
{
    public class ClassFile_Demo_Product_Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public List<String> Color { get; set; }

        public List<ClassFile_Demo_ProductProp_Model> ProductProps { get; set; }
    }
}
