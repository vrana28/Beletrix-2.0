using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.ComponentModel;
using System.Data;
using Storage.Implementation.Database;
using SystemOperations.ClientSO;
using SystemOperations.RobaSO;
using SystemOperations.StorekeeperSO;
using SystemOperations.PositionSO;
using SystemOperations.EntranceSO;
using SystemOperations.EntranceItemSO;
using SystemOperations.EntrancePositionSO;

namespace Controller
{
    public class Controler
    {
        private IGenericRepository repository;

        public Storekeeper User { get; set; }

        private static Controler instance;

        private static object _lock = new object();
        public static Controler Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Controler();
                        }
                    }
                }
                return instance;
            }
        }

        private Controler()
        {
            repository = new GenericRepository();
        }

        public DataTable GetAllEntrancecs()
        {
            //**
            GetAllJoinSO so = new GetAllJoinSO();
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public List<Position> GetAllPositions()
        {
            //**
            GetAllPositionsSO so = new GetAllPositionsSO();
            so.ExecuteTemplate(new Position());
            return so.Result;
        }

        public List<Roba> GetAllRoba()
        {
            //**
            GetAllRobaSO so = new GetAllRobaSO();
            so.ExecuteTemplate(new Roba());
            return so.Result;
        }

        public DataTable FindBusyPositions(Client client, Roba roba)
        {
            //**
            GetBusyPositionSO so = new GetBusyPositionSO();
            so.Client = client;
            so.Roba = roba;
            so.ExecuteTemplate(new Position());
            return so.Result;
        }

        public DataTable ShowEntranceItems(string positionId)
        {
            //**
            ShowEntranceItemsSO so = new ShowEntranceItemsSO();
            so.Uslov = positionId;
            so.ExecuteTemplate(new EntranceItems());
            return so.Result;
        }

        public List<Position> FindPositions(string v)
        {
            //**
            SearchSO so = new SearchSO();
            so.Uslov = v;
            so.ExecuteTemplate(new Position());
            return so.Result;
        }

        public List<Storekeeper> GetAllStorekeepers()
        {
            //**
            GetAllStorekeepersSO so = new GetAllStorekeepersSO();
            so.ExecuteTemplate(new Storekeeper());
            return so.Result;
        }

        public EntrancePosition ReturnEntrancePosition(string pozicija)
        {
            //**
            ReturnEntrancePositionSO so = new ReturnEntrancePositionSO();
            so.Uslov = pozicija;
            so.ExecuteTemplate(new EntrancePosition());
            return so.Result;
        }

        public List<EntranceItems> ReturnEntranceItems(int entranceId)
        {
            //**
            SearchEntranceItemsSO so = new SearchEntranceItemsSO();
            so.Uslov = entranceId;
            so.ExecuteTemplate(new EntranceItems());
            return so.Result;
        }

        public List<Client> GetAllClient()
        {
            //***
            GetAllClientsSO so = new GetAllClientsSO();
            so.ExecuteTemplate(new Client());
            return so.Result;
        }

        public bool FindStorekeeper(Storekeeper s) {
            //**
            ExistStorekeeperSO so = new ExistStorekeeperSO();
            so.ExecuteTemplate(s);
            return so.Result;
        }

        public void UpdateRoba(Roba r)
        {
            //**
            UpdateRobaSO so = new UpdateRobaSO();
            so.ExecuteTemplate(r);
        }

        public bool FindRoba(Roba r)
        {
            //**
            ExistRobaSO so = new ExistRobaSO();
            so.ExecuteTemplate(r);
            return so.Result;
        }

        public void AddRoba(Roba r)
        {
            //**
            AddNewRobaSO so = new AddNewRobaSO();
            so.ExecuteTemplate(r);
        }

        public Storekeeper Login(Storekeeper st)
        {
            //**
            LoginSO so = new LoginSO();
            so.ExecuteTemplate(st);
            return so.Result;
        }

        public Entrance FindEntrance(int entranceId)
        {
            //**
            ReturnEntranceSO so = new ReturnEntranceSO();
            so.Uslov = entranceId;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public void LeaveEntrance(Entrance entrance)
        {
            //**
            ExitEntrancePositionSO so = new ExitEntrancePositionSO();
            so.ExecuteTemplate(entrance);
        }

        public DataTable FindBusyPositionsWithPosition(Client client, Roba roba, string v)
        {
            //**
            GetBusyPositionWithPosition so = new GetBusyPositionWithPosition();
            so.Client = client;
            so.Roba = roba;
            so.Uslov = v;
            so.ExecuteTemplate(new Position());
            return so.Result;
        }

        public void DeleteRoba(Roba roba)
        {
            //**
            DeleteRobaSO so = new DeleteRobaSO();
            so.ExecuteTemplate(roba);
        }

        public void UpdateStorekeeper(Storekeeper s)
        {
            //**
            UpdateStorekeeperSO so = new UpdateStorekeeperSO();
            so.ExecuteTemplate(s);
        }

        public void AddStorekeeper(Storekeeper s)
        {
            //**
            AddNewStorekeeperSO so = new AddNewStorekeeperSO();
            so.ExecuteTemplate(s);
        }
        // imamo add entrance !!!!
        public void AddEntrance(Entrance ulaz)
        {
            //**
            AddNewEntranceSO so = new AddNewEntranceSO();
            so.ExecuteTemplate(ulaz);
        }

        public bool FindClient(Client c)
        {
            //**
            ExistClientSO so = new ExistClientSO();
            so.ExecuteTemplate(c);
            return so.Result;
        }

        public void AddClient(Client c)
        {
            //**
            AddNewClientSO so = new AddNewClientSO();
            so.ExecuteTemplate(c);
        }


        public void UpdateClient(Client c)
        {
            //**
            UpdateClientSO so = new UpdateClientSO();
            so.ExecuteTemplate(c);
        }


        public void DeleteClient(Client client)
        {
            //**
            DeleteClientSO so = new DeleteClientSO();
            so.ExecuteTemplate(client);
        }

        public void AddEntrancePosition(EntrancePosition ep)
        {
            //**
            AddNewEntrancePositionSO so = new AddNewEntrancePositionSO();
            so.EntranceId = ep.EntranceId;
            so.PositoinId = ep.PositionId;
            so.ExecuteTemplate(ep);
        }

        public void DeleteStorekeeper(Storekeeper storekeeper)
        {
            //**
            DeleteStorekeeperSO so = new DeleteStorekeeperSO();
            so.ExecuteTemplate(storekeeper);
        }

        public void AddEntranceItem(EntranceItems ei)
        {
            //**
            AddNewEntranceItemSO so = new AddNewEntranceItemSO();
            so.ExecuteTemplate(ei);
        }

        public double GetWeightOfBox(int robaId)
        {
            //**
            GetWeightOfBoxSO so = new GetWeightOfBoxSO();
            so.Uslov = robaId;
            so.ExecuteTemplate(new Roba());
            return so.Result;
        }

        public void UpdateEntranceAndPosition(int requestObject, string requestObject2)
        {
            // NOVO UPDATE v2.1
            UpdateEntranceAndPosition so = new UpdateEntranceAndPosition();
            so.EntranceId = requestObject;
            so.PositionId = requestObject2;
            so.ExecuteTemplate(new Entrance());
        }

        public void RestartDatabase()
        {
            RestartDatabase so = new RestartDatabase();
            so.ExecuteTemplate(new EntrancePosition());
        }

        public object ReturnEntrances(string pozicija)
        {
            ReturnEntranceSO2 so = new ReturnEntranceSO2();
            so.Uslov = pozicija;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public object FindBusyEntrances(Client client, Roba roba)
        {
            //** NOVO UPDATE v2.1
            GetBusyEntrancesSO so = new GetBusyEntrancesSO();
            so.Client = client;
            so.Roba = roba;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public object FindBusyEntrancesWithDate(Client client, Roba roba, DateTime datumOd, DateTime datumDo)
        {
            //** NOVO UPDATE v2.1
            GetBusyEntrancesWithDateSO so = new GetBusyEntrancesWithDateSO();
            so.Client = client;
            so.Roba = roba;
            so.DatumOd = datumOd;
            so.DatumDo = datumDo;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public object FindOutputEntrancesWithDate(Client client, Roba roba, DateTime datumOd, DateTime datumDo)
        {
            //** NOVO UPDATE v2.1
            GetOutputEntrancesWithDateSO so = new GetOutputEntrancesWithDateSO();
            so.Client = client;
            so.Roba = roba;
            so.DatumOd = datumOd;
            so.DatumDo = datumDo;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public object ZauzetaPozicija(string pozicija)
        {
            GetBoolPositionSO so = new GetBoolPositionSO();
            so.Pozicija = pozicija;
            so.ExecuteTemplate(new Position());
            return so.Result;
        }

        public object FindOutputEntrances(Client client, Roba roba)
        {
            //** NOVO UPDATE v2.1
            GetOutputEntrancesSO so = new GetOutputEntrancesSO();
            so.Client = client;
            so.Roba = roba;
            so.ExecuteTemplate(new Entrance());
            return so.Result;
        }

        public void DeleteEntrance(string requestObject)
        {
            // NOVO UPDATE v2.1
            DeleteEntranceSO so = new DeleteEntranceSO();
            so.EntranceId = Int32.Parse(requestObject);
            so.ExecuteTemplate(new Entrance());
        }

        // imamo i SAVE ENTRANCE !!!
        //public void SaveEntrance(Entrance entrance)
        //{
        //    //**
        //    AddNewEntranceSO so = new AddNewEntranceSO();
        //    so.ExecuteTemplateExecuteTemplate(entrance);
        //}

        public void LeavingEntranceItems(List<LeavingItem> listaItemaZaIzlaz, List<EntranceItems> listaItemaZaUpdate)
        {
            //**
            LeavingEntranceItemSO so = new LeavingEntranceItemSO();
            so.LeavingItem = listaItemaZaIzlaz;
            so.EntranceItem = listaItemaZaUpdate;
            so.ExecuteTemplate(new EntranceItems());
        }

        public Client ReturnClient(string requestObject)
        {
            //**
            ReturnClientSO so = new ReturnClientSO();
            so.Uslov = requestObject;
            so.ExecuteTemplate(new Client());
            return so.Result;
        }

        public Roba ReturnRoba(string requestObject)
        {
            //**
            ReturnRobaSO so = new ReturnRobaSO();
            so.Uslov = requestObject;
            so.ExecuteTemplate(new Roba());
            return so.Result;
        }
    }
}
