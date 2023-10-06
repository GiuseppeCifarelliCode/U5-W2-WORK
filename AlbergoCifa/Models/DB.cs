using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AlbergoCifa.Models
{
    public static class DB
    {
        public static User getUserByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from [User] where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            User user = new User();
            while (sqlDataReader.Read())
            {
                user.Id = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Username = sqlDataReader["Username"].ToString();
                user.Password = sqlDataReader["Password"].ToString();
                user.Role = sqlDataReader["Role"].ToString();
            }

            conn.Close();
            return user;
        }
        public static List<Camera> getAllFreeRooms()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Camera where Occupata = 'false'", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Camera> camere = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera c = new Camera();
                c.Id = Convert.ToInt32(sqlDataReader["IdCamera"]);
                c.Descrizione = sqlDataReader["Descrizione"].ToString();
                c.Singola = Convert.ToBoolean(sqlDataReader["Singola"]);
                c.Occupata = Convert.ToBoolean(sqlDataReader["Occupata"]);
                c.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                camere.Add(c);
            }

            conn.Close();
            return camere;
        }
        public static List<Camera> getAllBusyRooms()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Camera where Occupata = 'true'", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Camera> camere = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera c = new Camera();
                c.Id = Convert.ToInt32(sqlDataReader["IdCamera"]);
                c.Descrizione = sqlDataReader["Descrizione"].ToString();
                c.Singola = Convert.ToBoolean(sqlDataReader["Singola"]);
                c.Occupata = Convert.ToBoolean(sqlDataReader["Occupata"]);
                c.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                camere.Add(c);
            }

            conn.Close();
            return camere;
        }

        public static void AddCliente(string cognome,string nome,string cf,string provincia,string citta,string email,string telefono, string cellulare)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Cliente] (Cognome,Nome,CF,Provincia,Citta,Email,Telefono,Cellulare)" +
                    " VALUES(@cognome,@nome,@cf,@provincia,@citta,@email,@telefono,@cellulare)";
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cf", cf);
                cmd.Parameters.AddWithValue("provincia", provincia);
                cmd.Parameters.AddWithValue("citta", citta);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("cellulare", cellulare);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch(Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
        public static void AddServizio(string descrizione, double prezzo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Servizio] (Descrizione, Prezzo)" +
                    " VALUES(@descrizione,@prezzo)";
                cmd.Parameters.AddWithValue("descrizione", descrizione);
                cmd.Parameters.AddWithValue("prezzo", prezzo);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
        public static Cliente getClienteByCF(string cf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Cliente where CF = @cf", conn);
            cmd.Parameters.AddWithValue("cf", cf);
            SqlDataReader sqlDataReader;

            conn.Open();

            Cliente c = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.Cognome = sqlDataReader["Cognome"].ToString();
                c.Nome = sqlDataReader["Nome"].ToString();
                c.CF = sqlDataReader["CF"].ToString();
                c.Provincia = sqlDataReader["Provincia"].ToString();
                c.Citta = sqlDataReader["Citta"].ToString();
                c.Email = sqlDataReader["Email"].ToString();
                c.Telefono = sqlDataReader["Telefono"].ToString();
                c.Cellulare = sqlDataReader["Cellulare"].ToString();
            }

            conn.Close();
            return c;
        }

        public static void AddPrenotazione(DateTime dataPrenotazione, string anno, DateTime dataInizio, DateTime dataFine, double caparra,
            double tariffa, bool mezzaPensione,bool primaColazione, int idCliente, int idCamera)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Prenotazione] (DataPrenotazione,Anno,DataInizio,DataFine,Caparra,Tariffa,MezzaPensione,PrimaColazione,Conclusa,IdCliente,IdCamera)" +
                    " VALUES(@dataPrenotazione,@anno,@dataInizio,@dataFine,@caparra,@tariffa,@mezzaPensione,@primaColazione,@conclusa,@idCliente,@idCamera)";
                cmd.Parameters.AddWithValue("dataPrenotazione", dataPrenotazione);
                cmd.Parameters.AddWithValue("anno", anno);
                cmd.Parameters.AddWithValue("dataInizio", dataInizio);
                cmd.Parameters.AddWithValue("dataFine", dataFine);
                cmd.Parameters.AddWithValue("caparra", caparra);
                cmd.Parameters.AddWithValue("tariffa", tariffa);
                cmd.Parameters.AddWithValue("mezzaPensione", mezzaPensione);
                cmd.Parameters.AddWithValue("primaColazione", primaColazione);
                cmd.Parameters.AddWithValue("conclusa", false);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                cmd.Parameters.AddWithValue("idCamera", idCamera);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch(Exception ex) { }
            finally
            {
                conn.Close();
            }
        }

        public static Camera getCameraById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Camera where IdCamera = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Camera c = new Camera();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.Id = Convert.ToInt32(sqlDataReader["IdCamera"]);
                c.Descrizione = sqlDataReader["Descrizione"].ToString();
                c.Singola = Convert.ToBoolean(sqlDataReader["Singola"]);
                c.Occupata = Convert.ToBoolean(sqlDataReader["Occupata"]);
                c.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
            }

            conn.Close();
            return c;
        }

        public static void changeCameraState(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Camera SET Occupata = ~Occupata WHERE IdCamera = @id";
                cmd.Parameters.AddWithValue("id", id);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static List<Servizio> getAllServizi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Servizio", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Servizio> servizi = new List<Servizio>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Servizio s = new Servizio();
                s.Id = Convert.ToInt32(sqlDataReader["IdServizio"]);
                s.Descrizione = sqlDataReader["Descrizione"].ToString();
                s.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                servizi.Add(s);
            }

            conn.Close();
            return servizi;
        }
        public static Prenotazione getPrenotazioneByIdCamera(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione where IdCamera = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Prenotazione p = new Prenotazione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
            }

            conn.Close();
            return p;
        }
        public static Prenotazione getPrenotazioneById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione where IdPrenotazione = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Prenotazione p = new Prenotazione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
            }

            conn.Close();
            return p;
        }
        public static void AddRichiestaServizio(DateTime data, int quantita, int idPrenotazione, int idServizio )
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [RichiestaServizio] (Data,Quantita,IdPrenotazione,IdServizio)" +
                    " VALUES(@data,@quantita,@idPrenotazione,@idServizio)";
                cmd.Parameters.AddWithValue("data", data);
                cmd.Parameters.AddWithValue("quantita", quantita);
                cmd.Parameters.AddWithValue("idPrenotazione", idPrenotazione);
                cmd.Parameters.AddWithValue("idServizio", idServizio);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }
        }
        public static Servizio getServizioByIdServizio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Servizio where IdServizio = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Servizio s = new Servizio();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                s.Id = Convert.ToInt32(sqlDataReader["IdServizio"]);
                s.Descrizione = sqlDataReader["Descrizione"].ToString();
                s.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
            }

            conn.Close();
            return s;
        }
        public static List<RichiestaServizio> getAllServiziRichiestiByIdPrenotazione(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from RichiestaServizio where IdPrenotazione = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<RichiestaServizio> servizi = new List<RichiestaServizio>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                RichiestaServizio r = new RichiestaServizio();
                r.Id = Convert.ToInt32(sqlDataReader["IdRichiestaServizio"]);
                r.Data = Convert.ToDateTime(sqlDataReader["Data"]);
                r.Quantita = Convert.ToInt32(sqlDataReader["Quantita"]);
                r.IdPrenotazione = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                r.IdServizio = Convert.ToInt32(sqlDataReader["IdServizio"]);
                servizi.Add(r);
            }

            conn.Close();
            return servizi;
        }
        public static double getPrezzoServizioByIdServizio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select Prezzo from Servizio where IdServizio = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            sqlDataReader = cmd.ExecuteReader();
            double prezzo = 0;
            while (sqlDataReader.Read())
            {
               prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
            }
      

            conn.Close();
            return prezzo;
        }

        public static List<Prenotazione> getPrenotazioniByCF(string cf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione INNER JOIN Cliente ON " +
                "Prenotazione.IdCliente = Cliente.IdCLiente where Cliente.CF = @cf", conn);
            cmd.Parameters.AddWithValue("cf", cf);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione p = new Prenotazione();
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                prenotazioni.Add(p);
            }

            conn.Close();
            return prenotazioni;
        }

        public static int getTotPrenotazioniPerPensioneCompleta()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select COUNT(*) FROM Prenotazione where MezzaPensione = 'false'", conn);

            conn.Open();

            int tot = (int)cmd.ExecuteScalar();

            conn.Close();
            return tot;
        }

        public static List<Cliente> getAllClienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Cliente", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> clienti = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();
                c.Id = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.Cognome = sqlDataReader["Cognome"].ToString();
                c.Nome = sqlDataReader["Nome"].ToString();
                c.CF = sqlDataReader["CF"].ToString();
                c.Provincia = sqlDataReader["Provincia"].ToString();
                c.Citta = sqlDataReader["Citta"].ToString();
                c.Email = sqlDataReader["Email"].ToString();
                c.Telefono = sqlDataReader["Telefono"].ToString();
                c.Cellulare = sqlDataReader["Cellulare"].ToString();
                clienti.Add(c);
            }

            conn.Close();
            return clienti;
        }

        public static List<Prenotazione> getAllPrenotazioni()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione p = new Prenotazione();
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                prenotazioni.Add(p);
            }

            conn.Close();
            return prenotazioni;
        }

        public static List<Prenotazione> getAllPrenotazioniAttive()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione where Conclusa = 'false'", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione p = new Prenotazione();
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                prenotazioni.Add(p);
            }

            conn.Close();
            return prenotazioni;
        }
        public static List<Prenotazione> getAllPrenotazioniConcluse()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prenotazione where Conclusa = 'true'", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione p = new Prenotazione();
                p.Id = Convert.ToInt32(sqlDataReader["IdPrenotazione"]);
                p.DataPrenotazione = Convert.ToDateTime(sqlDataReader["DataPrenotazione"]);
                p.Anno = sqlDataReader["Anno"].ToString();
                p.DataInizio = Convert.ToDateTime(sqlDataReader["DataInizio"]);
                p.DataFine = Convert.ToDateTime(sqlDataReader["DataFine"]);
                p.Caparra = Convert.ToDouble(sqlDataReader["Caparra"]);
                p.Tariffa = Convert.ToDouble(sqlDataReader["Tariffa"]);
                p.MezzaPensione = Convert.ToBoolean(sqlDataReader["MezzaPensione"]);
                p.PrimaColazione = Convert.ToBoolean(sqlDataReader["PrimaColazione"]);
                p.Conclusa = Convert.ToBoolean(sqlDataReader["Conclusa"]);
                p.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                p.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                prenotazioni.Add(p);
            }

            conn.Close();
            return prenotazioni;
        }
        public static void changePrenotazioneState(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Prenotazione SET Conclusa = ~Conclusa WHERE IdPrenotazione = @id";
                cmd.Parameters.AddWithValue("id", id);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void editServizio(string descrizione, double prezzo, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Servizio SET Descrizione = @descrizione, Prezzo = @prezzo WHERE IdServizio = @id";
                cmd.Parameters.AddWithValue("descrizione", descrizione);
                cmd.Parameters.AddWithValue("prezzo", prezzo);
                cmd.Parameters.AddWithValue("id", id);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void deleteServizio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Servizio where IdServizio=@id";
            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}