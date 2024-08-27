using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Comenzi
{
    public class SettingsModel
    {
        public enum UpdateType
        {
            /// <summary>
            /// Actualizare oprită
            /// </summary>
            Off = 1,

            /// <summary>
            /// Actualizare independentă
            /// </summary>
            Default,

            /// <summary>
            /// Actualizare din rețeaua locală
            /// </summary>
            Local,

            /// <summary>
            /// Actualizare de pe site web
            /// </summary>
            Network
        }

        /// <summary>
        /// Tip actualizare
        /// </summary>
        public UpdateType Update { get; set; }

        /// <summary>
        /// Actualizare aplicație
        /// </summary>
        public bool UpdateApplication { get; set; }

        /// <summary>
        /// Actualizare baza de date
        /// </summary>
        public bool UpdateDatabase { get; set; }

        /// <summary>
        /// Oglindire locală
        /// </summary>
        public bool UpdateMirror { get; set; }

        /// <summary>
        /// Actualizare prin acțiune externă
        /// </summary>
        public bool UpdateTask { get; set; }

        /// <summary>
        /// Actualizare asistată de utilizator
        /// </summary>
        public bool UpdateInteractive { get; set; }

        /// <summary>
        /// Conexiune baza de date actualizare
        /// </summary>
        public string UpdateConnection { get; set; }

        /// <summary>
        /// Adresa URL a serviciului web
        /// </summary>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Indica utilizarea unui server proxy pentru accesul la serviciul web
        /// </summary>
        public bool ServiceUseProxy { get; set; }

        /// <summary>
        /// Adresa URL a serverului proxy
        /// </summary>
        public string ServiceProxyUrl { get; set; }

        /// <summary>
        /// Utilizatorul pentru serverul proxy
        /// </summary>
        public string ServiceProxyUsername { get; set; }

        /// <summary>
        /// Parola pentru serverul proxy
        /// </summary>
        public string ServiceProxyPassword { get; set; }

        /// <summary>
        /// Notificare actualizare
        /// </summary>
        public bool Notify { get; set; }

        /// <summary>
        /// Codul de client utilizat la notificare
        /// </summary>
        public string ClientDescriptor { get; set; }

        /// <summary>
        /// Numele clientului
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Conexiunile catre bazele de date ale aplicatiei
        /// </summary>
        public List<string> DatabaseConnections { get; set; }

        /// <summary>
        /// Tipurile bazelor de date ale aplicatiei
        /// </summary>
        public List<string> DatabaseTypes { get; set; }

        /// <summary>
        /// Indica faptul ca setarile sunt sugerate de catre aplicatia tinta.
        /// </summary>
        public bool SuggestedSettings { get; set; }

        private const string STOREFILE = "update.dat";

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsModel()
        {
            Update = UpdateType.Off;
            UpdateApplication = false;
            UpdateDatabase = false;
            UpdateMirror = false;
            UpdateTask = false;
            UpdateInteractive = false;
            UpdateConnection = "";
            ServiceUrl = "";
            ServiceUseProxy = false;
            ServiceProxyUrl = "";
            ServiceProxyUsername = "";
            ServiceProxyPassword = "";
            Notify = false;
            ClientDescriptor = "";
            ClientName = "";
            DatabaseConnections = new List<string>();
            DatabaseTypes = new List<string>();
            SuggestedSettings = false;
        }

        #region Methods

        /// <summary>
        /// Verifica daca fisierul in care sunt pastrate setarile exista.
        /// </summary>
        public static bool SettingsStoreExists()
        {
            return File.Exists(Path.Combine(Application.StartupPath, STOREFILE));
        }

        /// <summary>
        /// Initializeaza obiectul intern care lucreaza cu fisierul pentru setari.
        /// </summary>
        public static SettingsStore InitStore()
        {
            return new SettingsStore()
            {
                SettingsPath = Application.StartupPath,
                SettingsFile = STOREFILE
            };
        }

        /// <summary>
        /// Salveaza setarile in fisier.
        /// </summary>
        public static bool SaveData(SettingsModel model)
        {
            SettingsStore store = InitStore();

            store.Set("UpdateType", (int)model.Update);
            store.Set("UpdateApplication", model.UpdateApplication);
            store.Set("UpdateDatabase", model.UpdateDatabase);
            store.Set("UpdateMirror", model.UpdateMirror);
            store.Set("UpdateTask", model.UpdateTask);
            store.Set("UpdateInteractive", model.UpdateInteractive);
            store.Set("UpdateConnection", model.UpdateConnection);
            store.Set("ServiceUrl", model.ServiceUrl);
            store.Set("ServiceUseProxy", model.ServiceUseProxy);
            store.Set("ServiceProxyUrl", model.ServiceProxyUrl);
            store.Set("ServiceProxyUsername", model.ServiceProxyUsername);
            store.Set("ServiceProxyPassword", model.ServiceProxyPassword);
            store.Set("Notify", model.Notify);
            store.Set("ClientDescriptor", model.ClientDescriptor);
            store.Set("ClientName", model.ClientName);

            int length = 0;
            if (model.DatabaseConnections.Count > 0)
            {
                for (int index = 0; index < model.DatabaseConnections.Count; index++)
                {
                    string connection = model.DatabaseConnections[index];
                    if (String.IsNullOrEmpty(connection)) continue;
                    length++;
                    store.Set("DatabaseConnection" + length, connection);

                    string dbtype = index < model.DatabaseTypes.Count ? (model.DatabaseTypes[index] ?? "") : "";
                    store.Set("DatabaseType" + length, dbtype);
                }
            }
            store.Set("DatabaseConnectionsLength", length);

            store.Set("SuggestedSettings", model.SuggestedSettings);

            return store.Save();
        }

        /// <summary>
        /// Incarca setarile din fisier.
        /// </summary>
        public static SettingsModel LoadData()
        {
            SettingsModel model = new SettingsModel();
            SettingsStore store = InitStore();

            if (!store.Load())
            {
                return model;
            }

            int updateType = ModelUtil.GetAsInt(store, "UpdateType", 0);
            switch (updateType)
            {
                case 1: model.Update = SettingsModel.UpdateType.Off;
                    break;
                case 2: model.Update = SettingsModel.UpdateType.Default;
                    break;
                case 3: model.Update = SettingsModel.UpdateType.Local;
                    break;
                case 4: model.Update = SettingsModel.UpdateType.Network;
                    break;
                default: model.Update = SettingsModel.UpdateType.Off;
                    break;
            }

            model.UpdateApplication = ModelUtil.GetAsBool(store, "UpdateApplication", false);
            model.UpdateDatabase = ModelUtil.GetAsBool(store, "UpdateDatabase", false);
            model.UpdateMirror = ModelUtil.GetAsBool(store, "UpdateMirror", false);
            model.UpdateTask = ModelUtil.GetAsBool(store, "UpdateTask", false);
            model.UpdateInteractive = ModelUtil.GetAsBool(store, "UpdateInteractive", false);
            model.UpdateConnection = ModelUtil.GetAsString(store, "UpdateConnection", "");
            model.ServiceUrl = ModelUtil.GetAsString(store, "ServiceUrl", "");
            model.ServiceUseProxy = ModelUtil.GetAsBool(store, "ServiceUseProxy", false);
            model.ServiceProxyUrl = ModelUtil.GetAsString(store, "ServiceProxyUrl", "");
            model.ServiceProxyUsername = ModelUtil.GetAsString(store, "ServiceProxyUsername", "");
            model.ServiceProxyPassword = ModelUtil.GetAsString(store, "ServiceProxyPassword", "");
            model.Notify = ModelUtil.GetAsBool(store, "Notify", false);
            model.ClientDescriptor = ModelUtil.GetAsString(store, "ClientDescriptor", "");
            model.ClientName = ModelUtil.GetAsString(store, "ClientName", "");

            int length = ModelUtil.GetAsInt(store, "DatabaseConnectionsLength", 0);

            model.DatabaseConnections = new List<string>();
            model.DatabaseTypes = new List<string>();
            for (int index = 1; index <= length; index++)
            {
                string connection = ModelUtil.GetAsString(store, "DatabaseConnection" + index, "");
                string dbtype = ModelUtil.GetAsString(store, "DatabaseType" + index, "");
                if (!String.IsNullOrEmpty(connection))
                {
                    model.DatabaseConnections.Add(connection);
                    model.DatabaseTypes.Add(dbtype);
                }
            }

            model.SuggestedSettings = ModelUtil.GetAsBool(store, "SuggestedSettings", false);

            return model;
        }

        #endregion
    }
}
