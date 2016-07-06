declare  @staffid int 

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('刘小龙', 'lxl', 'bHhs', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('李虎', 'lh', 'bGg=', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('赵旭明', 'zxm', 'enht', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID) VALUES(0, @staffid)
INSERT StaffRoles(Role, StaffID) VALUES(1, @staffid)

INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('会务电脑', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('单反相机', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('投影仪', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('插座', 0, GETDATE(), 1)

INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(1, 1, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(2, 2, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(3, 3, 1, 0, GETDATE())

INSERT Settings(IdleAssetDescription) VALUES('')

INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(1, 3, '会客', 0, GETDATE())
INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(2, 5, '会客', 0, GETDATE())
INSERT ExternalPersonnelDiningRegisterHistories(StaffID, CardQuantity, Comment, Status, RegisteredOn) VALUES(3, 8, '会客', 0, GETDATE())

INSERT DinnerTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('午宴', 0, GETDATE(), 1)
INSERT DinnerTypes(Type, Status, CreatedOn, CreatedBy) VALUES ('晚宴', 0, GETDATE(), 1)

INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('AAA', 0, GETDATE(), 1)
INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('BBB', 0, GETDATE(), 1)
INSERT DinnerPlaces(Place, Status, CreatedOn, CreatedBy) VALUES ('CCC', 0, GETDATE(), 1)

INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (1, GETDATE(), 4, 1, 1, 0, '会客', GETDATE())
INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (2, GETDATE(), 7, 2, 2, 0, '会客', GETDATE())
INSERT DinnerRegisterHistories(StaffID, DinnerDate, PeopleCount, TypeID, PlaceID, Status, Comment, RegisteredOn)
VALUES (3, GETDATE(), 3, 1, 3, 0, '会客', GETDATE())

INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('无锡办公楼', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('常州售楼处', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('魅力仓库', 0, GETDATE(), 1)
INSERT ItemStorageAreas(Area, Status, CreatedOn, CreatedBy) VALUES('信成道售楼处', 0, GETDATE(), 1)

INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '办公楼司机室', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '商业地库', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(1, '红楼三楼仓库', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(2, '售楼处', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(3, '魅力仓库', 0, GETDATE(), 1)
INSERT ItemStoragePlaces(AreaID, Place, Status, CreatedOn, CreatedBy) VALUES(4, '信成道仓库', 0, GETDATE(), 1)

INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(1, 1, '电风扇', 4, '个', 1, '', 0, GETDATE(), 1)
INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(2, 4, '取暖器', 3, '个', 2, '', 0, GETDATE(), 1)
INSERT IdleAssets(AreaID, PlaceID, Item, Quantity, Unit, ManagerStaffID, Comment, Status, CreatedOn, CreatedBy)
VALUES(3, 5, '空调扇', 8, '个', 3, '', 0, GETDATE(), 1)

INSERT DesignatedDrivers(DriverName, ServiceArea, BusinessRequirement, ContactPhone, PersonalRequirement, DrivingPhone, CustomFirstColumn, CustomSecondColumn, CustomThirdColumn, Status, CreatedOn, CreatedBy)
VALUES ('无锡爱代驾', '无锡市（不含宜兴、江阴）', '联系总经理办公室 朱奕诚', '13801533450', '直拨代驾公司电话', '4006138138', '路程（公里）', '05:00-22:00', '22:00-次日04:59', 0, GETDATE(), 1)
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(1, '0-10', '38元', '58元')
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(1, '10-100', '每5公里加收20元', '每5公里加收20元')

INSERT DesignatedDrivers(DriverName, ServiceArea, BusinessRequirement, ContactPhone, PersonalRequirement, DrivingPhone, CustomFirstColumn, CustomSecondColumn, CustomThirdColumn, Status, CreatedOn, CreatedBy)
VALUES ('常州E代驾', '常州市区（不含金坛、溧阳地区）', '联系常州片区 戴晓慧', '15195005656', '直拨代驾公司电话', '4007676885', '路程（公里）', '8:00-23:59', '00:00-次日07:59', 0, GETDATE(), 1)
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(2, '常州市区（含天宁区、武进区、钟楼区、新北区、戚墅堰）', '100元', '100元')
INSERT DesignatedDriverPrices(DesignatedDriverID, Distance, FirstTimePeriodsPrice, SecondTimePeriodsPrice) VALUES(2, '常州-无锡', '300元', '400元')

INSERT SurroundingServices(Name, Description, UnitPrice, Address, Phone, Recommendation, Status, CreatedOn, CreatedBy)
VALUES ('凯宾斯基芳园中餐厅', '环境较好，菜品清淡', '￥150/人', '无锡南长区永和路18号', '0510-81088288', '脆皮双拼鱼 金蒜 牛柳粒', 0, GETDATE(), 1)
INSERT SurroundingServices(Name, Description, UnitPrice, Address, Phone, Recommendation, Status, CreatedOn, CreatedBy)
VALUES ('金蔷薇', '较安静，环境古朴，菜式精致，粤菜为主', '￥170/人', '无锡运河公园C区5号楼', '0510-83776777', '清蒸鲈鱼 烧纸鹅肝卷', 0, GETDATE(), 1)