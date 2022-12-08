using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Professional_Register_form
{
    public class person
    {
        #region Attributes
        public int id { get; set; }
        public string name { get; set; }
        public string fname { get; set; }
        public byte age { get; set; }

        #endregion

        #region Constractor Method
        public person() { }
        #endregion

        #region Methods

        #region Verify 
        public bool verify(person p)
        {
            db db1 = new db();
            if (db1.people.Any(i => i.name == p.name && i.fname == p.fname))
            {
                MessageBox.Show("Duplicate information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (p.age < 18)
            {
                MessageBox.Show("Your age is below the limit!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Register
        public void register(person p)
        {
            db db1 = new db();
            if (verify(p) == true)
            {
                db1.people.Add(p);
                db1.SaveChanges();
                MessageBox.Show("Information saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region search
        public List<person> search(string text)
        {
            db db1 = new db();
            var x = from item in db1.people where item.name.Contains(text) || item.fname.Contains(text) select item;
            return x.ToList();
        }
        #endregion

        #region Search by id
        public person searchbyid(int id)
        {
            person p = new person();
            db db1 = new db();
            var q = from item in db1.people where item.id == id select item;
            if (q.Count() == 1)
            {
                p = q.Single();
                return p;
            }
            return null;

        }
        #endregion

        #region Update
        public void update(int id, person p)
        {
            if (verify(p) == true)
            {
                db db1 = new db();
                var q = db1.people.Where(i => i.id == id);
                if (q.Count() == 1)
                {
                    person p1 = new person();
                    p1 = q.Single();
                    p1.name = p.name;
                    p1.fname = p.fname;
                    p1.age = p.age;
                    db1.SaveChanges();
                }
            }
        }
        #endregion

        #region Delete
        public void delete(int id)
        {
            db db1 = new db();
            var q = db1.people.Where(i => i.id == id);
            if (q.Count() == 1)
            {
                person p = new person();
                db1.people.Remove(q.Single());
                db1.SaveChanges();
            }
        }
        #endregion

        #region Read All
        public List<person> readall()
        {
            return (new db()).people.ToList();
        }
        #endregion

        #endregion
    }
}