using AADLDataAccess;
using System.Data;

namespace AADLBusiness
{
    public class clsCompanyAim
    {
        public enum enMode { add, update }
        public enMode Mode { get; set; }    

        public int? Id { get; set; }
        public string Name { get; set; }

        public clsCompanyAim() 
        {
            Mode = enMode.add;
        }

        private clsCompanyAim(int id, string name)
        {
            Id = id;
            Name = name;
            Mode = enMode.update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.add:
                    if(_Add())
                    {
                        this.Mode = enMode.update;
                        return true;
                    }
                    return false;

                case enMode.update:
                    return this._Update();

                default:
                    return false;
            }
        }

        public static clsCompanyAim Find(int id)
        {
            string name = string.Empty;

            if(clsCompanyAimData.GetInfoByAimID(id, ref name)) 
                return new clsCompanyAim(id, name);

            return null;
        }

        public static bool Delete(int id)
            => clsCompanyAimData.Delete(id);

        public static bool Exists(string name)
            => clsCompanyAimData.Exists(name);

        public static DataTable All() 
            => clsCompanyAimData.All();

        private bool _Add()
        {
            this.Id = clsCompanyAimData.Add(this.Name);
            return this.Id.HasValue;
        }

        public bool _Update()
            => clsCompanyAimData.Update(this.Id.Value, this.Name);
    }
}
