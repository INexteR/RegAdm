using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Mapping;
using RegAdmModel.Entities;

namespace RegAdmModel.Testing
{
    internal static class Data
    {
        private static User[] users = null!;
        public static IEnumerable<User> Users =>
            users ??= usersData.ParseToArray<User>(nameof(User.Id),
                                                   nameof(User.FullName),
                                                   nameof(User.BirthDate),
                                                   nameof(User.Role),
                                                   nameof(User.Login),
                                                   nameof(User.Password));
        private const string usersData = @"1	Морозов Владимир Артурович	1997-12-08	Администратор	adillon@outlook.com	9+DSDUS2
2	Андреева Александра Георгиевна	1984-04-28	Администратор	jgoerz7n@live.com	0k038%4$
3	Евсеева Вероника Матвеевна	1979-03-25	Администратор	citadel3@outlook.com	232@048F
4	Блинов Даниил Романович	1999-08-21	Старший администратор	Dan323x021@yandex.com	dns73bhs3";

        private static RoomType[] roomTypes = null!;
        public static IEnumerable<RoomType> RoomTypes =>
            roomTypes ??= roomTypesData.ParseToArray<RoomType>(nameof(RoomType.Id),
                                                    nameof(RoomType.Name),
                                                    nameof(RoomType.Places),
                                                    nameof(RoomType.PricePerDay));
        private const string roomTypesData = @"1	Номер стандартный	1	2550
2	Номер стандартный (вариант 1)	2	2550
3	Номер стандартный (вариант 2)	2	2760
4	Номер стандартный (вариант 1)	3	2100
5	Номер стандартный (вариант 2)	3	2500
6	Полулюкс	2	3100
7	Полулюкс	3	3100
8	Люкс	1	3500
9	Люкс 2-х этажный	2	3500";
        private static Room[] rooms = null!;
        public static IEnumerable<Room> Rooms =>
            rooms ??= roomsData.ParseToArray<Room>(nameof(Room.Id),
                                                    nameof(Room.Number),
                                                    nameof(Room.RoomTypeId));
        private const string roomsData = @"1	100	1
2	101	2
3	102	3
4	103	2
5	104	2
6	105	3
7	106	2
8	107	1
9	108	3
10	109	2
11	200	4
12	201	4
13	203	5
14	204	4
15	205	5
16	206	4
17	207	4
18	208	5
19	209	4
20	300	6
21	301	7
22	302	6
23	303	5
24	304	6
25	305	7
26	306	6
27	307	6
28	308	7
29	309	7
30	400	7
31	401	8
32	402	9
33	403	7
34	404	6
35	405	5
36	406	1
37	407	9
38	408	8";
    }
}
