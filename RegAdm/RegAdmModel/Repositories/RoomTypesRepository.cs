using Model.DTOs;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RegAdmModel.RegistrationSettings;
using RegAdmModel.Helpers;

namespace RegAdmModel.Repositories
{
    internal class RoomTypesRepository : IRoomTypesRepository
    {
        public event EntityChangeHandler<RoomTypeDto> EntityChanged = delegate { };

        public RoomTypeDto? Get(int id)
        {
            using var context = new RegAdmContext(CONNECTION);
            var roomType = context.RoomTypes.Find(id);
            return roomType?.ToDto();
        }

        public IEnumerable<RoomTypeDto> GetAll()
        {
            using var context = new RegAdmContext(CONNECTION);
            return context.RoomTypes.ToList().Select(ConvertHelper.ToDto);
        }

        public RoomTypeDto? GetTypeForRoom(int roomId)
        {
            using var context = new RegAdmContext(CONNECTION);
            var room = context.Rooms.Find(roomId);
            if (room != null)
            {
                context.Rooms.Entry(room).Reference(r => r.RoomType).Load();
                return room.RoomType.ToDto();
            }
            return null;
        }

        public bool Add(RoomTypeDto _) => throw Exceptions.NotImplemented;
        public bool Remove(RoomTypeDto _) => Add(_);
        public bool Update(RoomTypeDto _) => Add(_);
    }
}
