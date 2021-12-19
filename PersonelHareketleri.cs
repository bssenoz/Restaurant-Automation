using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE2
{
    class PersonelHareketleri
    {
        FrmGiris giris = new FrmGiris();
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _personelId;
        private int personelId
        {
            get { return _personelId; }
            set { _personelId = value; }
        }
        private string _islem;
        private string islem
        {
            get { return _islem; }
            set { _islem = value; }
        }
        private DateTime _tarih;
        private DateTime tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }
        private bool _durum;
        private bool durum
        {
            get { return _durum; }
            set { _durum = value; }
        }

        public bool PersonelActivationSave(PersonelHareketleri ph)
        {
            bool result = false;
            NpgsqlConnection baglanti = new
            NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=buse8597;Database=Restaurant;");
            NpgsqlCommand command = new NpgsqlCommand("insert into personel_hareketleri(id,islem,tarih)values(@id,@islem,@tarih)",baglanti);
            try
            {
                //if(baglanti.state==)
                command.Parameters.Add("@id", (NpgsqlTypes.NpgsqlDbType)SqlDbType.Int).Value = ph._personelId;
                command.Parameters.Add("@islem", (NpgsqlTypes.NpgsqlDbType)SqlDbType.VarChar).Value = ph._islem;
                command.Parameters.Add("@tarih", (NpgsqlTypes.NpgsqlDbType)SqlDbType.DateTime).Value = ph._tarih;
                result = Convert.ToBoolean(command.ExecuteNonQuery());
            } catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
