﻿using DO;
using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DO;

namespace DLAPI
{

    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL//הצהרה  על פונקציות של הDL
    {
        #region Bus
        IEnumerable<DO.Bus> GetAllBuses();
        IEnumerable<DO.Bus> GetAllBusesBy(Predicate<DO.Bus> predicate);
        IEnumerable<DO.Bus> GetAllDeleteBuses();
        DO.Bus GetBus(int licenseNumber);
        void AddBus(DO.Bus bus);
        void UpdateBus(DO.Bus bus);
        void UpdateBus(int licenseNumber, Action<DO.Bus> update); //method that knows to updt specific fields in Bus
        void DeleteBus(int licenseNumber);
        #endregion

        #region AdjacentStations
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStations();
        IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate);
        DO.AdjacentStations GetAdjacentStations(int stationCode1, int stationCode2);
        void AddAdjacentStations(DO.AdjacentStations adjStations);
        void UpdateAdjacentStations(DO.AdjacentStations adjStations);
        void UpdateAdjacentStations(int stationCode1, int stationCode2, Action<DO.AdjacentStations> update);
        void DeleteAdjacentStations(int stationCode1, int stationCode2);
        bool  ExistAdjacentStations(int stationCode1, int stationCode2);
        void UpdateTandDinAdjacentStation(DO.AdjacentStations adjacentStations);
        #endregion

        #region Station
        IEnumerable<DO.Station> GetAllStations();
        IEnumerable<DO.Station> GetAllDeletedStations();
        IEnumerable<DO.Station> GetAllStationsBy(Predicate<DO.Station> predicate);
        DO.Station GetStation(int code);
        void AddStation(DO.Station station);//?
        void UpdateStation(DO.Station station);
        void UpdateStation(int code, Action<DO.Station> update); //method that knows to updt specific fields in Station
        void DeleteStation(int code);

        #endregion 

        #region Line
        int GetNewLineId();
        IEnumerable<DO.Line> GetAllLines();
        IEnumerable<DO.Line> GetAllLinesInArea(string area);
        IEnumerable<DO.Line> GetAllDeletedLines();

       // IEnumerable<DO.Line> GetAllLinesDelete();
        IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate);
        DO.Line GetLine(int lineId);
        void AddLine(DO.Line line);//?
        void UpdateLine(DO.Line line);
        void UpdateLine(int lineId, Action<DO.Line> update); //method that knows to updt specific fields in Bus
        void DeleteLine(int lineId);
        IEnumerable<DO.LineStation> GetStationInLineList(Predicate<DO.LineStation> predicate);

        #endregion

        #region LineStation
        IEnumerable<DO.LineStation> GetAllLineStations();
        IEnumerable<DO.LineStation> GetAllLineStationsBy(Predicate<DO.LineStation> predicate);
        DO.LineStation GetLineStation(int lineId, int stationCode);
        void AddLineStation(DO.LineStation lineStation);
        void AddStationInLine(int stationID, int busID, int index);
        void DeleteStationInLine(int stationID, int busID);
        void UpdateLineStation(DO.LineStation lineStation);
        void UpdateLineStation(int lineId, int stationCode, Action<DO.LineStation> update);
        void DeleteLineStation(int lineId, int stationCode);
        IEnumerable<DO.Line> GetLinesInStationList(Predicate<DO.LineStation> predicate);

        #endregion

        #region Trip
        IEnumerable<DO.Trip> GetAllTrips();
       IEnumerable<DO.Trip> GetAllTripsBy(Predicate<DO.Trip> predicate);
       DO.Trip GetTrip(int tripId);
       void AddTrip(DO.Trip trip);//?
       void UpdateTrip(DO.Trip trip);
       void UpdateTrip(int tripId, Action<DO.Trip> update); //method that knows to updt specific fields in Trip
       void DeleteTrip(int tripId);
       #endregion

        #region LineTrip
        IEnumerable<DO.LineTrip> GetAllLineTrips();
        IEnumerable<DO.LineTrip> GetAllLineTripsBy(Predicate<DO.LineTrip> predicate);
        DO.LineTrip GetLineTrip(int lineId, TimeSpan time);
        void AddLineTrip(DO.LineTrip lineTrip);//?
        void UpdateLineTrip(DO.LineTrip lineTrip);
        void UpdateLineTrip(int lineId, TimeSpan time, Action<DO.LineTrip> update);
        void DeleteLineTrip(int lineId, TimeSpan time);
        #endregion

        #region User
        IEnumerable<DO.User> GetAllUsers();
        IEnumerable<DO.User> GetAllUsersBy(Predicate<DO.User> predicate);
        DO.User GetUser(string userName);
        void AddUser(DO.User user);
        void UpdateUser(DO.User user);
        void UpdateUser(string userName, Action<DO.User> update);
        void DeleteUser(string userName);
        // void AddStationInLine(LineStation first);
        #endregion
    }
}


