﻿namespace Library_Console.Data
{
    public class DbSettings
    {
        public string ConnectionString { get; set; }

        public DbSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}