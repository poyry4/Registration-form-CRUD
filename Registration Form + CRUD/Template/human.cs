using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template
{
    class human
    {
        public human()
        {
            
            Name = "ali";
            Family = "babayi";
            Age = 18;
            National_id = "1111111111";
        }

        #region properties

        public int id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public byte Age { get; set; }

        public string National_id { get; set; }
        

        

        #endregion


        #region CRUD

        public bool exist()
        {
            Db db1 = new Db();

            var q = from i in db1.humen where (i.Name == Name && i.Family == Family && i.National_id==National_id) select i;
            if (q.Count() >= 1)
            {
                return true;
            }

            return false;
        }

        public human register(human form)
        {
            if (exist() != true)
            {
                Db db1 = new Db();
                db1.humen.Add(form);
                db1.SaveChanges();
                return form;
            }
            else
            {
                MessageBox.Show("Already registered");
                return form;
            }

            return form;
        }

        public List<human> readall()
        {
            Db db1 = new Db();
            return db1.humen.ToList();
        }

        public List<human> search(string text)
        {
            Db db1 = new Db();
            var q = from i in db1.humen
                where (i.Name.Contains(text) || i.Family.Contains(text) || i.National_id.Contains(text))
                select i;
            return q.ToList();
        }

        public human searchbyid(int id)
        {
            Db db1 = new Db();
            var q = (from i in db1.humen where (i.id == id) select i);
            if (q.Count()>=1)
            {
                return q.Single();
            }
            else
            {
                MessageBox.Show("didnt find");
                return null;

            }
            
            
        }

        public void update(int id, human newhuman)
        {
            if (exist()!=true)
            {
                Db db1 = new Db();
                var q = from i in db1.humen where i.id == id select i;
                if (q.Count() == 1)
                {
                    human a = new human();
                    a = q.Single();
                    a.Name = newhuman.Name;
                    a.Family = newhuman.Family;
                    a.Age = newhuman.Age;
                    a.National_id = newhuman.National_id;
                    db1.SaveChanges();
                }

            }
            else
            {
                MessageBox.Show("Already registered");
            }

        }

        public void delete(int id)
        {
            Db db1 = new Db();
            var q = from i in db1.humen where i.id == id select i;
            if (q.Count()==1)
            {
                db1.humen.Remove(q.Single());
                db1.SaveChanges();
            }

        }

        #endregion

    }
}