using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace apptest
{

    internal class Queries
    {

        public NpgsqlConnection conn;

        public String hostname, port, database, userID, password;

        public Queries(String hostname, String port, String database, String userID, String password)
        {
            this.hostname = hostname;
            this.port = port;
            this.database = database;
            this.userID = userID;
            this.password = password;
            connect();
        }

        public bool connect()
        {
            try
            {
                conn = new NpgsqlConnection("Host = " + hostname + "; Port = " + port + "; Database = " + database + "; User id = " + userID + "; Password = " + password + ";");
                return true;
            } catch
            {
                return false;
            }
        }



        // records

        public bool createRecord(String lastname, String firstname, String middlename, String email, String phone, String department, String face, String image_profile, String status)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO records (lastname, firstname, middlename, email, phone, department, face, image_profile, status) VALUES (@lastname, @firstname, @middlename, @email, @phone, @department, @face, @image_profile, @status)";
                comm.Parameters.AddWithValue("@lastname", lastname);
                comm.Parameters.AddWithValue("@firstname", firstname);
                comm.Parameters.AddWithValue("@middlename", middlename);
                comm.Parameters.AddWithValue("@email", email);
                comm.Parameters.AddWithValue("@phone", phone);
                comm.Parameters.AddWithValue("@department", department);
                comm.Parameters.AddWithValue("@face", face);
                comm.Parameters.AddWithValue("@image_profile", image_profile);
                comm.Parameters.AddWithValue("@status", status);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public NpgsqlDataReader getRecord(int record_id)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT record_id, CONCAT(lastname, ', ', firstname, ' ', middlename) AS fullname, email, phone, department, status FROM records WHERE record_id = @record_id ORDER BY lastname ASC, firstname ASC, middlename ASC";
            comm.Parameters.AddWithValue("@record_id", record_id);
            NpgsqlDataReader dr = comm.ExecuteReader();
            comm.Dispose();
            return dr;
        }

        public NpgsqlDataReader getRecords()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT record_id, CONCAT(lastname, ', ', firstname, ' ', middlename) AS fullname, email, phone, department, status FROM records ORDER BY lastname ASC, firstname ASC, middlename ASC";
            NpgsqlDataReader dr = comm.ExecuteReader();
            comm.Dispose();
            return dr;
        }

        public NpgsqlDataReader getRecords(String key)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT record_id, CONCAT(lastname, ', ', firstname, ' ', middlename) AS fullname, email, phone, department, status FROM records WHERE lastname = @key OR firstname = @key OR middlename = @key ORDER BY lastname ASC, firstname ASC, middlename ASC";
            NpgsqlDataReader dr = comm.ExecuteReader();
            comm.Parameters.AddWithValue("@" + "key", key);
            comm.Dispose();
            return dr;
        }



        // fingerprints

        public bool createFingerprint(int id_record, String type, String data)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO fingerprints (id_record, type, data, status) VALUES (@id_record, @type, @data, 'active')";
                comm.Parameters.AddWithValue("@id_record", id_record);
                comm.Parameters.AddWithValue("@type", type);
                comm.Parameters.AddWithValue("@data", data);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool isFingerprintExists(int id_record, String type)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host = localhost; Port = 5432; Database = postgres; User id = postgres; Password = donjake;");
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "SELECT fingerprint_id FROM fingerprints WHERE id_record = @id_record AND type = @type";
            comm.Parameters.AddWithValue("@" + "id_record", id_record);
            comm.Parameters.AddWithValue("@" + "type", type);
            NpgsqlDataReader dr = comm.ExecuteReader();
            comm.Dispose();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeFingerprint(int id_record, String type)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM fingerprints WHERE id_record = @id_record AND type = @type";
                comm.Parameters.AddWithValue("@id_record", id_record);
                comm.Parameters.AddWithValue("@type", type);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool updateRecord(int record_id, String lastname, String firstname, String middlename, String suffix, String gender, String birthdate, String department)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                NpgsqlCommand comm = new NpgsqlCommand();
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE records SET lastname = @lastname, firstname = @firstname, middlename = @middlename, suffix = @suffix, gender = @gender, birthdate = TO_DATE(@birthdate, 'YYYY-MM-DD'), department = @department WHERE record_id = @record_id";
                comm.Parameters.AddWithValue("@lastname", lastname);
                comm.Parameters.AddWithValue("@firstname", firstname);
                comm.Parameters.AddWithValue("@middlename", middlename);
                comm.Parameters.AddWithValue("@suffix", suffix);
                comm.Parameters.AddWithValue("@gender", gender);
                comm.Parameters.AddWithValue("@birthdate", birthdate);
                comm.Parameters.AddWithValue("@department", department);
                comm.Parameters.AddWithValue("@record_id", record_id);
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

}

// SELECT records.* FROM records JOIN fingerprints ON records.record_id = fingerprints.id_record WHERE fingerprints.data = '0001' AND fingerprints.status = 'active'