using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJMediaBazaar.Logic
{
    public class Specification
    {
        String name;
        List<String> specTitle;
        List<String> spec;
        public Specification(String name)
        {
            this.name = name;
            specTitle = new List<String>();
            spec = new List<String>();
        }
        public void AddSpecification(String title,String text)
        {
            specTitle.Add(title);
            spec.Add(text);
        }
        public List<String> GetSpecifications()
        {
            List<String> temp = new List<String>();
            for (int i=0;i<spec.Count;i++)
            {
                temp.Add(specTitle[i] + " : " + spec[i]);
            }
            return temp;
        }
    }
}
