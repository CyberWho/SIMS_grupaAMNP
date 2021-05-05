/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.RoomService
 ***********************************************************************/

using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using Hospital.Repository;

namespace Hospital.Service
{
    public class RoomService
    {
        public Room GetRoomById(int id)
        {
            return roomRepository.GetRoomById(id);
        }

        public Room GetRoomByAppointmentId(int appointmentId)
        {
            // TODO: implement
            return null;
        }

        public Room GetRoomByDoctorId(int doctorId)
        {
            return roomRepository.GetRoomByDoctorId(doctorId);
        }

        public ObservableCollection<Room> GetAllRooms()
        {
            return roomRepository.GetAllRooms();
        }

        public System.Collections.ArrayList GetAllRoomsByFloor(int floor)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllRoomsByRoomType(RoomType roomType)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<RoomType> GetAllRoomTypesForEachRoom()
        {
            return roomRepository.GetAllRoomTypes();
        }
        public ObservableCollection<RoomType> GetAllRoomTypes()
        {
            return roomRepository.GetAllRoomTypes();
        }

        public ObservableCollection<Room> GetAllRoomsExceptSource(int id)
        {
            return roomRepository.GetAllRoomsExceptSource(id);
        }

        public Boolean DeleteRoomById(int id)
        {
            return roomRepository.DeleteRoomById(id);
        }

        public Boolean DeleteRoomByAppointmentId(int appointmentId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteRoomByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Room ChangeRoomArea(Room room, double newArea)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Room AddRoom(Hospital.Model.Room room)
        {
            return roomRepository.NewRoom(room);
        }

        public Hospital.Model.Room UpdateRoom(Hospital.Model.Room room)
        {
            return roomRepository.UpdateRoom(room);
        }
        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public RoomType GetRoomTypeByType(string Type)
        {
            return roomRepository.GetRoomTypeByType(Type);
        }

        public ObservableCollection<TimeSlot> findSuitableTimeSlotsForOperation(int id_room, int id_doc, int id_patient, DateTime startTime)
        {
            //time slots where doc patient and room are free
            ObservableCollection<TimeSlot> ret = new ObservableCollection<TimeSlot>();

            int num_of_time_slots_needed = 4;
            int time_slot_duration = 30;

            ObservableCollection<Appointment> takenAppointments =
                new ObservableCollection<Appointment>(from i in
                    appointmentRepository.getOccupiedDateTimesForDoctorPatienRoom(id_doc, id_patient, id_room)
                                                      orderby i.StartTime
                                                      select i);


            ObservableCollection<DateTime> takeDateTimes = new ObservableCollection<DateTime>();
            foreach (Appointment appointment in takenAppointments)
                for (int i = 0; i < appointment.DurationInMinutes / 30; i++)
                    if (!takeDateTimes.Contains(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30))))
                        takeDateTimes.Add(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30)));




            ObservableCollection<TimeSlot> doctorTimeSlots =
            new ObservableCollection<TimeSlot>(from i in
                timeSlotRepository.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(startTime, id_doc)
                                               orderby i.StartTime
                                               select i);
            for (int i = 0; i < doctorTimeSlots.Count - 3; i++)
            {
                bool valid_time_slot_set = true;
                for (int j = 0; j < num_of_time_slots_needed - 1; j++)
                {
                    if (doctorTimeSlots[i + j].StartTime.Add(TimeSpan.FromMinutes(30)) !=
                        doctorTimeSlots[i + j + 1].StartTime ||
                        takeDateTimes.Contains(doctorTimeSlots[i + j].StartTime))
                    {
                        valid_time_slot_set = false;
                        break;
                    }
                }

                if (valid_time_slot_set)
                    ret.Add(doctorTimeSlots[i]);
            }
            return ret;
        }

        public string findSuitableTimeSlotsForOperation1(int id_room, int id_doc, int id_patient, DateTime startTime)
        {
            //time slots where doc patient and room are free
            string s = "";
            ObservableCollection<TimeSlot> ret = new ObservableCollection<TimeSlot>();

            int num_of_time_slots_needed = 4;
            int time_slot_duration = 30;

            ObservableCollection<Appointment> takenAppointments =
                new ObservableCollection<Appointment>(from i in
                    appointmentRepository.getOccupiedDateTimesForDoctorPatienRoom(id_doc, id_patient, id_room)
                                                      orderby i.StartTime
                                                      select i);


            ObservableCollection<DateTime> takeDateTimes = new ObservableCollection<DateTime>();
            foreach (Appointment appointment in takenAppointments)
                for (int i = 0; i < appointment.DurationInMinutes / 30; i++)
                    if (!takeDateTimes.Contains(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30))))
                        takeDateTimes.Add(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30)));




            ObservableCollection<TimeSlot> doctorTimeSlots =
            new ObservableCollection<TimeSlot>(from i in
                timeSlotRepository.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(startTime, id_doc)
                                               orderby i.StartTime
                                               select i);
            for (int i = 0; i < doctorTimeSlots.Count - 3; i++)
            {
                bool valid_time_slot_set = true;
                for (int j = 0; j < num_of_time_slots_needed - 1; j++)
                {
                    if (doctorTimeSlots[i + j].StartTime.Add(TimeSpan.FromMinutes(30)) !=
                        doctorTimeSlots[i + j + 1].StartTime ||
                        takeDateTimes.Contains(doctorTimeSlots[i + j].StartTime))
                    {
                        valid_time_slot_set = false;
                        break;
                    }
                }

                if (valid_time_slot_set)
                    ret.Add(doctorTimeSlots[i]);
            }
            return s;
        }

        public ObservableCollection<Room> findSuitableRoomsForOperation(DateTime fromFuture, DateTime toFuture,
            ObservableCollection<InventoryItem> items_needed)
        {
            ObservableCollection<Room> currentRooms = GetAllRoomInFutureState(fromFuture);
            ObservableCollection<Room> futureRooms = GetAllRoomInFutureState(toFuture);

            ObservableCollection<Room> ret = new ObservableCollection<Room>();

            for (int i = 0; i < currentRooms.Count; i++)
            {
                bool hasAllNeeded = true;

                foreach (InventoryItem inventoryItemNeeded in items_needed)
                {
                    bool hasThisItem = false;
                    foreach (ItemInRoom itemInRoom in currentRooms[i].itemInRoom)
                    {
                        if (itemInRoom.inventoryItem_id == inventoryItemNeeded.Id)
                            hasThisItem = true;
                    }

                    if (!hasThisItem)
                        hasAllNeeded = false;
                }

                foreach (InventoryItem inventoryItemNeeded in items_needed)
                {
                    bool hasThisItem = false;
                    foreach (ItemInRoom itemInRoom in futureRooms[i].itemInRoom)
                    {
                        if (itemInRoom.inventoryItem_id == inventoryItemNeeded.Id)
                            hasThisItem = true;
                    }

                    if (!hasThisItem)
                        hasAllNeeded = false;
                }
                if (hasAllNeeded)
                    ret.Add(currentRooms[i]);
            }


            return ret;
        }



        public ObservableCollection<Room> GetAllRoomInFutureState(DateTime future)
        {
            //string test = "";
            int max_item_in_room_id = 0;
            ObservableCollection<Room> rooms = GetAllRooms(); //rooms with roomType only

            foreach (Room room in rooms)//get item in room
            {
                room.itemInRoom = itemInRoomRepository.GetAllItemsInRoomByRoomId(room.Id);
                foreach (ItemInRoom itemInRoom in room.itemInRoom)
                {
                    //test += "U sobi " + room.Id + " ima: " + itemInRoom.inventoryItem.Name + "\n";
                    if (max_item_in_room_id < itemInRoom.Id)
                        max_item_in_room_id = itemInRoom.Id;
                }
            }
            ObservableCollection<ReservedItem> reservedItems =
                new ObservableCollection<ReservedItem>(from i in reservedItemRepository.GetAllReservedItems() orderby i.ReservedDate select i);
            foreach (ReservedItem reservedItem in reservedItems)
            {
                if (reservedItem.ReservedDate < future)
                {
                    //test += reservedItem.ReservedDate + "\n";
                    ItemInRoom inputItem = null;
                    ItemInRoom outputItem = null;
                    Room outputRoom = null;
                    Room inputRoom = null;



                    foreach (Room room in rooms)
                    {
                        if (inputItem != null)
                            break;
                        foreach (ItemInRoom itemInRoom in room.itemInRoom)
                        {
                            if (itemInRoom.Id == reservedItem.item_in_room_id)
                            {
                                inputItem = itemInRoom;
                                inputRoom = room;
                                break;
                            }
                        }
                    }

                    if (inputItem != null)
                        foreach (Room room in rooms)
                        {
                            if (reservedItem.room_id == room.Id)
                            {
                                outputRoom = room;
                                foreach (ItemInRoom itemInRoom in outputRoom.itemInRoom)
                                {
                                    if (itemInRoom.inventoryItem_id == inputItem.inventoryItem_id)
                                        outputItem = itemInRoom;
                                }

                            }
                        }

                    if (inputItem != null)
                        regulateItemFromRooms(ref inputRoom, ref inputItem,
                        outputRoom: ref outputRoom, ref outputItem, ref max_item_in_room_id);

                }
            }

            return rooms;
        }


        void regulateItemFromRooms(ref Room inputRoom, ref ItemInRoom inputItem, ref Room outputRoom, ref ItemInRoom outputItem, ref int max_item_in_room_id)
        {
            if (inputItem.Quantity == 1 && outputItem == null)
            {
                outputRoom.itemInRoom.Add(inputItem);
                inputRoom.itemInRoom.Remove(inputItem);
                //test += "premesteno: " + toSwitch.inventoryItem.Name + " u " + outputRoom.Id + " iz " + inputRoom.Id + "\n";
            }
            else if (outputItem == null)
            {
                inputItem.Quantity -= 1;
                ItemInRoom split = new ItemInRoom();
                max_item_in_room_id += 1;
                split.Id = max_item_in_room_id;
                split.Quantity = 1;
                split.inventoryItem = inputItem.inventoryItem;
                split.inventoryItem_id = inputItem.inventoryItem_id;
                split.room = inputItem.room;
                split.room_id = inputItem.room_id;
                outputRoom.itemInRoom.Add(split);
            }
            else if (inputItem.Quantity != 1)
            {
                inputItem.Quantity -= 1;
                outputItem.Quantity += 1;
            }
            else
            {
                inputRoom.itemInRoom.Remove(inputItem);
                outputItem.Quantity += 1;
            }


        }

        public Hospital.Repository.RoomRepository roomRepository = new Repository.RoomRepository();
        private Hospital.Repository.ItemInRoomRepository itemInRoomRepository = new ItemInRoomRepository();
        private Hospital.Repository.ReservedItemRepository reservedItemRepository = new ReservedItemRepository();
        private Hospital.Repository.AppointmentRepository appointmentRepository = new AppointmentRepository();
        private Hospital.Repository.TimeSlotRepository timeSlotRepository = new TimeSlotRepository();
    }
}