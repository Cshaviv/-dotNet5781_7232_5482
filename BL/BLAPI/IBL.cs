﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BLAPI
{
   public interface IBL
    {
        #region Bus
        BO.Bus GetBus(int licenseNum);//ll
        IEnumerable<BO.Bus> GetAllBuses();
        IEnumerable<BO.Bus> GetBusesBy(Predicate<BO.Bus> predicate);
        void UpdateBusDetails(BO.Bus bus);
        void DeleteBus(int licenseNum);
        void AddBus(BO.Bus bus);
        void BusException(BO.Bus busBO);

        #endregion
        #region Line
        void AddNewLine(BO.Line lineBo);
        BO.Line GetLine(int lineId);
        IEnumerable<BO.Line> GetAllLines();
        //IEnumerable<BO.ListedPerson> GetStudentIDNameList();
        IEnumerable<BO.Line> GelAllLinesBy(Predicate<BO.Line> predicate);
        void UpdateLineDetails(BO.Line line);
        void DeleteLine(int LineId);
        
        #endregion
        #region LineStation
        void AddLineStation(BO.LineStation s);
        void DeleteLineStation(int lineId, int stationCode);
        #endregion
        #region AdjacentStations
        bool IsExistAdjacentStations(int stationCode1, int stationCode2);
        //void AddAdjacentStations(BO.AdjacentStation adjBO);
        #endregion
        #region Station
        IEnumerable<BO.Station> GetAllStations();
        BO.Station GetStation(int code);
        void AddStation(BO.Station station);
        void DeleteStation(int code);
         void UpdateStation(BO.Station station);

        #endregion
        #region StationInLine
        void UpdateTimeAndDistance(BO.StationInLine first, BO.StationInLine second);
        void AddStationInLine(int stationCode, int busID, int index, int indexNextCode, int indexPrevCode, double distanceNext, TimeSpan timeNext, double distancePrev, TimeSpan timePrev);
        void DeleteStationInLine(int code, int lineID);

        #endregion

        #region user
        BO.User SignIn(string username, string passcode);
        void addNewUser(BO.User userBo);


        #endregion

    }
}
