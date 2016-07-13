declare  @staffid int 

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('��С��', 'lxl', 'bHhs', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('�', 'lh', 'bGg=', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('������', 'zxm', 'enht', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('�������', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('�������', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('ͶӰ��', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('����', 0, GETDATE(), 1)

INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(1, 1, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(2, 2, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(3, 3, 1, 0, GETDATE())

INSERT Settings(IdleAssetDescription) VALUES('')

INSERT DinnerTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('����', 0, GETDATE(), 1)
INSERT DinnerTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('����', 0, GETDATE(), 1)

INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('AAA', 0, GETDATE(), 1)
INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('BBB', 0, GETDATE(), 1)
INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('CCC', 0, GETDATE(), 1)

INSERT MealTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('���', 0, GETDATE(), 1)
INSERT MealTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('���', 0, GETDATE(), 1)
INSERT MealTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('���', 0, GETDATE(), 1)

INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('�����칫¥', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('������¥��', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('�����ֿ�', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('�ųɵ���¥��', 0, GETDATE(), 1)

INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '�칫¥˾����', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '��ҵ�ؿ�', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '��¥��¥�ֿ�', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(2, '��¥��', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(3, '�����ֿ�', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(4, '�ųɵ��ֿ�', 0, GETDATE(), 1)

INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(1, 3, '���', 0, GETDATE())
INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(2, 5, '���', 0, GETDATE())
INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(3, 8, '���', 0, GETDATE())

INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (1, GETDATE(), 4, 1, 1, 0, '���', GETDATE())
INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (2, GETDATE(), 7, 2, 2, 0, '���', GETDATE())
INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (3, GETDATE(), 3, 1, 3, 0, '���', GETDATE())

INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(1, 1, '�����', 4, '��', 1, '', 0, GETDATE(), 1)
INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(2, 4, 'ȡů��', 3, '��', 2, '', 0, GETDATE(), 1)
INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(3, 5, '�յ���', 8, '��', 3, '', 0, GETDATE(), 1)

INSERT DesignatedDrivers(DriverName, ServiceArea, BusinessRequirement, ContactPhone, PersonalRequirement, DrivingPhone, CustomFirstColumn, CustomSecondColumn, CustomThirdColumn, Status, CreatedOn, CreatedBy)
VALUES ('����������', '�����У��������ˡ�������', '��ϵ�ܾ���칫�� ���ȳ�', '13801533450', 'ֱ�����ݹ�˾�绰', '4006138138', '·�̣����', '05:00-22:00', '22:00-����04:59', 0, GETDATE(), 1)
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(1, '0-10', '38Ԫ', '58Ԫ')
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(1, '10-100', 'ÿ5�������20Ԫ', 'ÿ5�������20Ԫ')

INSERT DesignatedDrivers(DriverName, ServiceArea, BusinessRequirement, ContactPhone, PersonalRequirement, DrivingPhone, CustomFirstColumn, CustomSecondColumn, CustomThirdColumn, Status, CreatedOn, CreatedBy)
VALUES ('����E����', '����������������̳������������', '��ϵ����Ƭ�� ������', '15195005656', 'ֱ�����ݹ�˾�绰', '4007676885', '·�̣����', '8:00-23:59', '00:00-����07:59', 0, GETDATE(), 1)
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(2, '�����������������������������¥�����±����������ߣ�', '100Ԫ', '100Ԫ')
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(2, '����-����', '300Ԫ', '400Ԫ')

INSERT SurroundingServices(Name, Description, UnitPrice, Address, Phone, Recommendation, Status, CreatedOn, CreatedBy)
VALUES ('����˹����԰�в���', '�����Ϻã���Ʒ�嵭', '��150/��', '�����ϳ�������·18��', '0510-81088288', '��Ƥ˫ƴ�� ���� ţ����', 0, GETDATE(), 1)
INSERT SurroundingServices(Name, Description, UnitPrice, Address, Phone, Recommendation, Status, CreatedOn, CreatedBy)
VALUES ('��Ǿޱ', '�ϰ������������ӣ���ʽ���£�����Ϊ��', '��170/��', '�����˺ӹ�԰C��5��¥', '0510-83776777', '�������� ��ֽ��ξ�', 0, GETDATE(), 1)